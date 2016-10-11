// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Internal;
using QueryFramework.Query.SqlSyntex;
using QueryFramework.Storage;
using QueryFramework.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QueryFramework.Query.Sql
{

   public class DefaultSqlGenerator : ISqlExprVisitor, ISqlGenerator
   {

      #region [ Fields ]


      private readonly IRelationalCommandBuilderFactory _relationalCommandBuilderFactory;
      private readonly ISqlGenerationHelper _helper;
      private readonly IParameterNameGeneratorFactory _parameterNameGeneratorFactory;
      private readonly IQuerySourceAliasGeneratorFactory _querySourceAliasGeneratorFactory;
      private readonly IRelationalTypeMapper _relationalTypeMapper;

      private IRelationalCommandBuilder _sql;
      private ParameterNameGenerator _parameterNameGenerator;
      private QuerySourceAliasGenerator _querySourceAliasGenerator;

      private static readonly Dictionary<SqlBinaryOperator, string> _binaryOperatorMap = new Dictionary<SqlBinaryOperator, string>
         {
            { SqlBinaryOperator.Add, " + " },
            { SqlBinaryOperator.Subtract, " - " },
            { SqlBinaryOperator.Multiply, " * " },
            { SqlBinaryOperator.Divide, " / " },
            { SqlBinaryOperator.Modulo, " % " },
         };


      #endregion


      #region [ Constructors ]


      public DefaultSqlGenerator(
         IRelationalCommandBuilderFactory relationalCommandBuilderFactory,
         ISqlGenerationHelper sqlGenerationHelper,
         IParameterNameGeneratorFactory parameterNameGeneratorFactory,
         IQuerySourceAliasGeneratorFactory querySourceAliasGeneratorFactory,
         IRelationalTypeMapper relationalTypeMapper)
      {
         Check.NotNull(relationalCommandBuilderFactory, nameof(relationalCommandBuilderFactory));
         Check.NotNull(sqlGenerationHelper, nameof(sqlGenerationHelper));
         Check.NotNull(parameterNameGeneratorFactory, nameof(parameterNameGeneratorFactory));
         Check.NotNull(querySourceAliasGeneratorFactory, nameof(querySourceAliasGeneratorFactory));
         Check.NotNull(relationalTypeMapper, nameof(relationalTypeMapper));


         _relationalCommandBuilderFactory = relationalCommandBuilderFactory;
         _helper = sqlGenerationHelper;
         _parameterNameGeneratorFactory = parameterNameGeneratorFactory;
         _querySourceAliasGeneratorFactory = querySourceAliasGeneratorFactory;
         _relationalTypeMapper = relationalTypeMapper;
      }


      #endregion


      #region [ Properties ]


      public virtual string SqlString
         => _sql.ToString();


      public virtual IReadOnlyList<IRelationalParameter> Parameters
         => _sql.ParameterBuilder.Parameters;


      #endregion


      #region [ Methods ]


      public virtual void GenerateSelect(SqlSelectExpr selectExpr)
      {
         Check.NotNull(selectExpr, nameof(selectExpr));


         _sql = _relationalCommandBuilderFactory.Create();
         _parameterNameGenerator = _parameterNameGeneratorFactory.Create();
         _querySourceAliasGenerator = _querySourceAliasGeneratorFactory.Create();


         Visit(selectExpr);
      }


      public virtual void GenerateInsert(SqlInsertCommand insertCommand)
      {
         Check.NotNull(insertCommand, nameof(insertCommand));
      }


      public virtual void GenerateUpdate(SqlUpdateCommand updateCommand)
      {
         Check.NotNull(updateCommand, nameof(updateCommand));
      }


      public virtual void GenerateDelete(SqlDeleteCommand deleteCommand)
      {
         Check.NotNull(deleteCommand, nameof(deleteCommand));
      }


      #endregion


      #region [ Protected Properties ]


      protected virtual string ParameterPrefix => "@";


      protected virtual ISqlGenerationHelper SqlGenerator
         => _helper;


      protected virtual IRelationalCommandBuilder Sql
         => _sql;


      protected virtual ParameterNameGenerator ParameterNameGenerator
         => _parameterNameGenerator;


      protected virtual QuerySourceAliasGenerator QuerySourceAliasGenerator
         => _querySourceAliasGenerator;


      protected virtual string ConcatOperator
         => "+";


      protected virtual string TypedTrueLiteral
         => "CAST(1 AS BIT)";


      protected virtual string TypedFalseLiteral
         => "CAST(0 AS BIT)";


      #endregion


      #region [ Protected Methods ]


      protected SqlExpr Visit(SqlExpr expr)
         => expr.Accept(this);


      protected virtual IReadOnlyList<SqlOperableExpr> ProcessInExprValues(IReadOnlyList<SqlOperableExpr> inExprValues)
      {
         var inConstants = new List<SqlOperableExpr>();

         foreach (var expr in inExprValues)
         {
            var constantExpr = expr as SqlConstantExpr;
            if (!ExprIsNull(constantExpr))
            {
               inConstants.Add(constantExpr);
               continue;
            }

            var parameterExpr = expr as SqlParameterExpr;
            if (!ExprIsNull(parameterExpr))
            {
               var parameterValue = parameterExpr.Value;
               var valuesCollection = parameterValue as IEnumerable;

               if (valuesCollection != null
                   && parameterValue.GetType() != typeof(string)
                   && parameterValue.GetType() != typeof(byte[]))
               {
                  inConstants.AddRange(valuesCollection.Cast<object>().Select(SqlExpr.Constant));
               }
               else
               {
                  inConstants.Add(parameterExpr);
               }
            }
         }


         return inConstants;
      }


      protected virtual IReadOnlyList<SqlOperableExpr> ExtractNonNullExprValues(IReadOnlyList<SqlOperableExpr> inExprValues)
      {
         var inValuesNotNull = new List<SqlOperableExpr>();

         foreach (var expr in inExprValues)
         {
            var constantExpr = expr as SqlConstantExpr;
            if (constantExpr?.Value != null)
            {
               inValuesNotNull.Add(expr);
               continue;
            }

            var parameterExpr = expr as SqlParameterExpr;
            if (parameterExpr?.Value != null)
            {
               inValuesNotNull.Add(expr);
            }
         }


         return inValuesNotNull;
      }


      protected virtual void GenerateTop(SqlSelectExpr selectExpr)
      {
         Check.NotNull(selectExpr, nameof(selectExpr));


         if (!ExprIsNull(selectExpr.Limit)
            && ExprIsNull(selectExpr.Offset))
         {
            _sql.Append("TOP(");

            Visit(selectExpr.Limit);

            _sql.Append(") ");
         }
      }


      protected virtual void GenerateLimitOffset(SqlSelectExpr selectExpr)
      {
         Check.NotNull(selectExpr, nameof(selectExpr));


         if (!ExprIsNull(selectExpr.Offset))
         {
            _sql.AppendLine()
                .Append("OFFSET ");

            Visit(selectExpr.Offset);

            _sql.Append(" ROWS");

            if (!ExprIsNull(selectExpr.Limit))
            {
               _sql.Append(" FETCH NEXT ");

               Visit(selectExpr.Limit);

               _sql.Append(" ROWS ONLY");
            }
         }
      }


      protected bool ExprIsNull(SqlExpr expr)
         => object.ReferenceEquals(expr, null);


      #endregion


      #region [ Visits ]


      public virtual SqlExpr VisitSelect(SqlSelectExpr selectExpr)
      {
         Check.NotNull(selectExpr, nameof(selectExpr));


         IDisposable subQueryIndent = null;

         if (selectExpr.Alias != null)
         {
            _sql.AppendLine("(");

            subQueryIndent = _sql.Indent();
         }


         // SELECT <select_list>

         _sql.Append("SELECT ");

         if (selectExpr.IsDistinct)
         {
            _sql.Append("DISTINCT ");
         }

         GenerateTop(selectExpr);

         var projectionAdded = false;

         if (selectExpr.SelectClause.Any())
         {
            VisitJoin(selectExpr.SelectClause);

            projectionAdded = true;
         }

         if (!projectionAdded)
         {
            _sql.Append("1");
         }


         // [ FROM { <table_source> } [ ,...n ] ]

         if (selectExpr.FromClause.Any())
         {
            _sql.AppendLine()
                .Append("FROM ");

            VisitJoin(selectExpr.FromClause, sql => sql.AppendLine());
         }


         // [ WHERE <search_condition> ]

         if (selectExpr.WhereClause != null)
         {
            _sql.AppendLine()
                .Append("WHERE ");

            Visit(selectExpr.WhereClause);
         }


         // [ GROUP BY <group by spec> ]

         if (selectExpr.GroupByClause.Any())
         {
            _sql.AppendLine()
                .Append("GROUP BY ");

            VisitJoin(selectExpr.GroupByClause);
         }


         // [ HAVING <search_condition> ]

         if (selectExpr.HavingClause != null)
         {
            _sql.AppendLine()
                .Append("HAVING ");

            Visit(selectExpr.HavingClause);
         }


         // [ ORDER BY { order_by_expression [ASC | DESC] } [ ,...n] ]

         if (selectExpr.OrderByClause.Any())
         {
            _sql.AppendLine()
                .Append("ORDER BY ");

            VisitJoin(selectExpr.OrderByClause);
         }

         GenerateLimitOffset(selectExpr);

         if (subQueryIndent != null)
         {
            subQueryIndent.Dispose();

            _sql.AppendLine()
                .Append(") AS ")
                .Append(_helper.DelimitIdentifier(_querySourceAliasGenerator.GetUniqueTableAlias(selectExpr)));
         }


         // [ UNION ... ]

         if (selectExpr.CombineResults.Any())
         {
            _sql.AppendLine();

            VisitJoin(selectExpr.CombineResults, sql => sql.AppendLine());
         }


         return selectExpr;
      }


      public virtual SqlExpr VisitTable(SqlTableExpr tableExpr)
      {
         Check.NotNull(tableExpr, nameof(tableExpr));


         if (tableExpr.Schema != null)
         {
            _sql.Append(_helper.DelimitIdentifier(tableExpr.Schema))
                .Append(".");
         }

         _sql.Append(_helper.DelimitIdentifier(tableExpr.Name))
             .Append(" AS ")
             .Append(_helper.DelimitIdentifier(_querySourceAliasGenerator.GetUniqueTableAlias(tableExpr)));


         return tableExpr;
      }


      public virtual SqlExpr VisitInnerJoin(SqlInnerJoinExpr innerJoinExpr)
      {
         Check.NotNull(innerJoinExpr, nameof(innerJoinExpr));


         _sql.Append("INNER JOIN ");

         Visit(innerJoinExpr.TableExpr);

         _sql.Append(" ON ");

         Visit(innerJoinExpr.Predicate);


         return innerJoinExpr;
      }


      public virtual SqlExpr VisitLeftOuterJoin(SqlLeftOuterJoinExpr leftOuterJoinExpr)
      {
         Check.NotNull(leftOuterJoinExpr, nameof(leftOuterJoinExpr));


         _sql.Append("LEFT JOIN ");

         Visit(leftOuterJoinExpr.TableExpr);

         _sql.Append(" ON ");

         Visit(leftOuterJoinExpr.Predicate);


         return leftOuterJoinExpr;
      }


      public virtual SqlExpr VisitRightOuterJoin(SqlRightOuterJoinExpr rightOuterJoinExpr)
      {
         Check.NotNull(rightOuterJoinExpr, nameof(rightOuterJoinExpr));


         _sql.Append("RIGHT JOIN ");

         Visit(rightOuterJoinExpr.TableExpr);

         _sql.Append(" ON ");

         Visit(rightOuterJoinExpr.Predicate);


         return rightOuterJoinExpr;
      }


      public virtual SqlExpr VisitFullOuterJoin(SqlFullOuterJoinExpr fullOuterJoinExpr)
      {
         Check.NotNull(fullOuterJoinExpr, nameof(fullOuterJoinExpr));


         _sql.Append("FULL JOIN ");

         Visit(fullOuterJoinExpr.TableExpr);

         _sql.Append(" ON ");

         Visit(fullOuterJoinExpr.Predicate);


         return fullOuterJoinExpr;
      }


      public virtual SqlExpr VisitCrossJoin(SqlCrossJoinExpr crossJoinExpr)
      {
         Check.NotNull(crossJoinExpr, nameof(crossJoinExpr));


         _sql.Append("CROSS JOIN ");

         Visit(crossJoinExpr.TableExpr);


         return crossJoinExpr;
      }


      public virtual SqlExpr VisitLateralJoin(SqlLateralJoinExpr lateralJoinExpr)
      {
         Check.NotNull(lateralJoinExpr, nameof(lateralJoinExpr));


         _sql.Append("CROSS JOIN LATERAL ");

         Visit(lateralJoinExpr.TableExpr);


         return lateralJoinExpr;
      }


      public virtual SqlExpr VisitProjectStar(SqlProjectStarExpr starExpr)
      {
         Check.NotNull(starExpr, nameof(starExpr));


         if (starExpr.Table != null)
         {
            _sql.Append(_helper.DelimitIdentifier(_querySourceAliasGenerator.GetUniqueTableAlias(starExpr.Table)))
                .Append(".");
         }
         _sql.Append("*");


         return starExpr;
      }


      public virtual SqlExpr VisitColumn(SqlColumnExpr columnExpr)
      {
         Check.NotNull(columnExpr, nameof(columnExpr));


         _sql.Append(_helper.DelimitIdentifier(_querySourceAliasGenerator.GetUniqueTableAlias(columnExpr.Table)))
             .Append(".")
             .Append(_helper.DelimitIdentifier(columnExpr.Name));


         return columnExpr;
      }


      public virtual SqlExpr VisitAlias(SqlAliasExpr aliasExpr)
      {
         Check.NotNull(aliasExpr, nameof(aliasExpr));


         Visit(aliasExpr.Operand);
         _sql.Append(" AS ")
             .Append(_helper.DelimitIdentifier(aliasExpr.Alias));


         return aliasExpr;
      }


      public virtual SqlExpr VisitConstant(SqlConstantExpr constantExpr)
      {
         Check.NotNull(constantExpr, nameof(constantExpr));


         var value = constantExpr.Value;
         _sql.Append(value == null
            ? "NULL"
            : _helper.GenerateLiteral(value, _relationalTypeMapper.GetMappingForValue(value)));


         return constantExpr;
      }


      public virtual SqlExpr VisitRawSql(SqlRawSqlExpr rawSqlExpr)
      {
         Check.NotNull(rawSqlExpr, nameof(rawSqlExpr));


         _sql.Append(rawSqlExpr.Sql);


         return rawSqlExpr;
      }


      public virtual SqlExpr VisitBinary(SqlBinaryExpr binaryExpr)
      {
         Check.NotNull(binaryExpr, nameof(binaryExpr));


         var needParens = binaryExpr.Left is SqlBinaryExpr;

         if (needParens)
         {
            _sql.Append("(");
         }

         Visit(binaryExpr.Left);

         if (needParens)
         {
            _sql.Append(")");
         }

         VisitBinaryOperator(binaryExpr);

         needParens = binaryExpr.Right is SqlBinaryExpr;

         if (needParens)
         {
            _sql.Append("(");
         }

         Visit(binaryExpr.Right);

         if (needParens)
         {
            _sql.Append(")");
         }


         return binaryExpr;
      }


      public virtual SqlExpr VisitParameter(SqlParameterExpr parameterExpr)
      {
         Check.NotNull(parameterExpr, nameof(parameterExpr));


         string parameterName = _parameterNameGenerator.GenerateNext(parameterExpr.Name);

         _sql.AddParameter(parameterExpr.Name, parameterName, parameterExpr.Value);

         _sql.Append(_helper.GenerateParameterName(parameterName));


         return parameterExpr;
      }


      public virtual SqlExpr VisitNot(SqlNotExpr notExpr)
      {
         Check.NotNull(notExpr, nameof(notExpr));


         var isNullExpr = notExpr.Operand as SqlIsNullExpr;
         if (isNullExpr != null)
         {
            return VisitIsNotNull(isNullExpr);
         }

         var inExpr = notExpr.Operand as SqlInExpr;
         if (inExpr != null)
         {
            return VisitNotIn(inExpr);
         }

         var betweenExpr = notExpr.Operand as SqlBetweenExpr;
         if (betweenExpr != null)
         {
            return VisitNotBetween(betweenExpr);
         }

         var likeExpr = notExpr.Operand as SqlLikeExpr;
         if (likeExpr != null)
         {
            return VisitNotLike(likeExpr);
         }

         var existsExpr = notExpr.Operand as SqlExistsExpr;
         if (existsExpr != null)
         {
            return VisitNotExists(existsExpr);
         }

         var inSubQueryExpr = notExpr.Operand as SqlInSubQueryExpr;
         if (inSubQueryExpr != null)
         {
            return VisitNotInSubQuery(inSubQueryExpr);
         }

         _sql.Append("NOT (");

         Visit(notExpr.Operand);

         _sql.Append(")");


         return notExpr;
      }


      public virtual SqlExpr VisitAnd(SqlAndExpr andExpr)
      {
         Check.NotNull(andExpr, nameof(andExpr));


         if (andExpr.Left is SqlOrExpr)
         {
            _sql.Append("(");
            Visit(andExpr.Left);
            _sql.Append(")");
         }
         else
         {
            Visit(andExpr.Left);
         }

         _sql.Append(" AND ");

         if (andExpr.Right is SqlOrExpr)
         {
            _sql.Append("(");
            Visit(andExpr.Right);
            _sql.Append(")");
         }
         else
         {
            Visit(andExpr.Right);
         }


         return andExpr;
      }


      public virtual SqlExpr VisitOr(SqlOrExpr orExpr)
      {
         Check.NotNull(orExpr, nameof(orExpr));


         if (orExpr.Left is SqlAndExpr)
         {
            _sql.Append("(");
            Visit(orExpr.Left);
            _sql.Append(")");
         }
         else
         {
            Visit(orExpr.Left);
         }

         _sql.Append(" OR ");

         if (orExpr.Right is SqlAndExpr)
         {
            _sql.Append("(");
            Visit(orExpr.Right);
            _sql.Append(")");
         }
         else
         {
            Visit(orExpr.Right);
         }


         return orExpr;
      }


      public virtual SqlExpr VisitIsNull(SqlIsNullExpr isNullExpr)
      {
         Check.NotNull(isNullExpr, nameof(isNullExpr));


         Visit(isNullExpr.Operand);

         _sql.Append(" IS NULL");


         return isNullExpr;
      }


      public virtual SqlExpr VisitIsNotNull(SqlIsNullExpr isNullExpr)
      {
         Check.NotNull(isNullExpr, nameof(isNullExpr));


         Visit(isNullExpr.Operand);

         _sql.Append(" IS NOT NULL");


         return isNullExpr;
      }


      public virtual SqlExpr VisitComparison(SqlComparisonExpr comparisonExpr)
      {
         Check.NotNull(comparisonExpr, nameof(comparisonExpr));


         Visit(comparisonExpr.Left);

         VisitComparisonOperator(comparisonExpr.Operator);

         Visit(comparisonExpr.Right);


         return comparisonExpr;
      }


      public virtual SqlExpr VisitIn(SqlInExpr inExpr)
      {
         Check.NotNull(inExpr, nameof(inExpr));


         var inValues = ProcessInExprValues(inExpr.Values);
         var inValuesNotNull = ExtractNonNullExprValues(inValues);

         if (inValues.Count != inValuesNotNull.Count)
         {
            var nullSemanticsInExpression = SqlExpr.OrElse(
               SqlExpr.In(inExpr.Operand, inValuesNotNull),
               SqlExpr.IsNull(inExpr.Operand)
               );

            return Visit(nullSemanticsInExpression);
         }

         if (inValuesNotNull.Count > 0)
         {
            Visit(inExpr.Operand);

            _sql.Append(" IN (");

            VisitJoin(inValuesNotNull);

            _sql.Append(")");
         }
         else
         {
            _sql.Append("0 = 1");
         }


         return inExpr;
      }


      public virtual SqlExpr VisitNotIn(SqlInExpr inExpr)
      {
         Check.NotNull(inExpr, nameof(inExpr));


         var inValues = ProcessInExprValues(inExpr.Values);
         var inValuesNotNull = ExtractNonNullExprValues(inValues);

         if (inValues.Count != inValuesNotNull.Count)
         {
            var nullSemanticsInExpression = SqlExpr.AndAlso(
               SqlExpr.NotIn(inExpr.Operand, inValuesNotNull),
               SqlExpr.IsNotNull(inExpr.Operand)
               );

            return Visit(nullSemanticsInExpression);
         }

         if (inValuesNotNull.Count > 0)
         {
            Visit(inExpr.Operand);

            _sql.Append(" NOT IN (");

            VisitJoin(inValuesNotNull);

            _sql.Append(")");
         }
         else
         {
            _sql.Append("1 = 1");
         }


         return inExpr;
      }


      public virtual SqlExpr VisitBetween(SqlBetweenExpr betweenExpr)
      {
         Check.NotNull(betweenExpr, nameof(betweenExpr));


         Visit(betweenExpr.Operand);

         _sql.Append(" BETWEEN ");

         Visit(betweenExpr.Begin);

         _sql.Append(" AND ");

         Visit(betweenExpr.End);


         return betweenExpr;
      }


      public virtual SqlExpr VisitNotBetween(SqlBetweenExpr betweenExpr)
      {
         Check.NotNull(betweenExpr, nameof(betweenExpr));


         Visit(betweenExpr.Operand);

         _sql.Append(" NOT BETWEEN ");

         Visit(betweenExpr.Begin);

         _sql.Append(" AND ");

         Visit(betweenExpr.End);


         return betweenExpr;
      }


      public virtual SqlExpr VisitLike(SqlLikeExpr likeExpr)
      {
         Check.NotNull(likeExpr, nameof(likeExpr));


         Visit(likeExpr.Match);

         _sql.Append(" LIKE ");

         Visit(likeExpr.Pattern);


         return likeExpr;
      }


      public virtual SqlExpr VisitNotLike(SqlLikeExpr likeExpr)
      {
         Check.NotNull(likeExpr, nameof(likeExpr));


         Visit(likeExpr.Match);

         _sql.Append(" NOT LIKE ");

         Visit(likeExpr.Pattern);


         return likeExpr;
      }


      public virtual SqlExpr VisitExists(SqlExistsExpr existsExpr)
      {
         Check.NotNull(existsExpr, nameof(existsExpr));


         _sql.AppendLine("EXISTS (");

         using (_sql.Indent())
         {
            Visit(existsExpr.SubQuery);
         }

         _sql.AppendLine(")");


         return existsExpr;
      }


      public virtual SqlExpr VisitNotExists(SqlExistsExpr existsExpr)
      {
         Check.NotNull(existsExpr, nameof(existsExpr));


         _sql.AppendLine("NOT EXISTS (");

         using (_sql.Indent())
         {
            Visit(existsExpr.SubQuery);
         }

         _sql.AppendLine(")");


         return existsExpr;
      }


      public virtual SqlExpr VisitInSubQuery(SqlInSubQueryExpr inSubQueryExpr)
      {
         Check.NotNull(inSubQueryExpr, nameof(inSubQueryExpr));


         Visit(inSubQueryExpr.Operand);

         _sql.AppendLine(" IN (");

         using (_sql.Indent())
         {
            Visit(inSubQueryExpr.SubQuery);
         }

         _sql.AppendLine(")");


         return inSubQueryExpr;
      }


      public virtual SqlExpr VisitNotInSubQuery(SqlInSubQueryExpr inSubQueryExpr)
      {
         Check.NotNull(inSubQueryExpr, nameof(inSubQueryExpr));


         Visit(inSubQueryExpr.Operand);

         _sql.AppendLine(" NOT IN (");

         using (_sql.Indent())
         {
            Visit(inSubQueryExpr.SubQuery);
         }

         _sql.AppendLine(")");


         return inSubQueryExpr;
      }


      public virtual SqlExpr VisitComparisonSubQuery(SqlComparisonSubQueryExpr comparisonSubQueryExpr)
      {
         Check.NotNull(comparisonSubQueryExpr, nameof(comparisonSubQueryExpr));


         Visit(comparisonSubQueryExpr.Operand);

         VisitComparisonOperator(comparisonSubQueryExpr.Operator);

         Visit(comparisonSubQueryExpr.SubQuery);


         return comparisonSubQueryExpr;
      }


      public virtual SqlExpr VisitScalarSubQuery(SqlScalarSubQueryExpr scalarSubQueryExpr)
      {
         Check.NotNull(scalarSubQueryExpr, nameof(scalarSubQueryExpr));


         _sql.AppendLine(" (");

         using (_sql.Indent())
         {
            Visit(scalarSubQueryExpr.SubQuery);
         }

         _sql.AppendLine(")");


         return scalarSubQueryExpr;
      }


      public virtual SqlExpr VisitAny(SqlAnyExpr anyExpr)
      {
         Check.NotNull(anyExpr, nameof(anyExpr));


         _sql.AppendLine(" ANY (");

         using (_sql.Indent())
         {
            Visit(anyExpr.SubQuery);
         }

         _sql.AppendLine(")");


         return anyExpr;
      }


      public virtual SqlExpr VisitAll(SqlAllExpr allExpr)
      {
         Check.NotNull(allExpr, nameof(allExpr));


         _sql.AppendLine(" ALL (");

         using (_sql.Indent())
         {
            Visit(allExpr.SubQuery);
         }

         _sql.AppendLine(")");


         return allExpr;
      }


      public virtual SqlExpr VisitOrdering(SqlOrderingExpr orderingExpr)
      {
         Check.NotNull(orderingExpr, nameof(orderingExpr));


         var aliasExpr = orderingExpr.Operand as SqlAliasExpr;

         if (aliasExpr != null)
         {
            if (aliasExpr.Alias != null)
            {
               _sql.Append(_helper.DelimitIdentifier(aliasExpr.Alias));
            }
            else
            {
               Visit(aliasExpr.Operand);
            }
         }
         else
         {
            Visit(orderingExpr.Operand);
         }

         if (orderingExpr.OrderingDirection == SqlOrderingDirection.Desc)
         {
            _sql.Append(" DESC");
         }


         return orderingExpr;
      }


      public virtual SqlExpr VisitAliasReference(SqlAliasReferenceExpr aliasReferenceExpr)
      {
         Check.NotNull(aliasReferenceExpr, nameof(aliasReferenceExpr));


         _sql.Append(_helper.DelimitIdentifier(aliasReferenceExpr.Alias));


         return aliasReferenceExpr;
      }


      public virtual SqlExpr VisitCombineResult(SqlCombineResultExprBase combineResultExpr)
      {
         Check.NotNull(combineResultExpr, nameof(combineResultExpr));


         _sql.AppendLine(combineResultExpr.Operator);

         if (combineResultExpr.NextQuery.CombineResults.Any())
         {
            _sql.AppendLine("(");
         }

         Visit(combineResultExpr.NextQuery);

         if (combineResultExpr.NextQuery.CombineResults.Any())
         {
            _sql.AppendLine()
                .AppendLine(")");
         }


         return combineResultExpr;
      }


      public virtual SqlExpr VisitGroupingSets(SqlMultipleGroupingSetsExprBase groupingSetsExpr)
      {
         Check.NotNull(groupingSetsExpr, nameof(groupingSetsExpr));


         _sql.Append(groupingSetsExpr.Operator)
             .Append(" (");

         VisitJoin(groupingSetsExpr.Exprs);

         _sql.Append(")");


         return groupingSetsExpr;
      }


      public virtual SqlExpr VisitOver(SqlOverExpr overExpr)
      {
         Check.NotNull(overExpr, nameof(overExpr));


         Visit(overExpr.Function);

         _sql.Append(" OVER(");

         if (overExpr.PartitionByClause.Any())
         {
            _sql.Append("PARTITION BY ");

            VisitJoin(overExpr.PartitionByClause);
         }

         if (overExpr.OrderByClause.Any())
         {
            if (overExpr.PartitionByClause.Any())
            {
               _sql.Append(" ");
            }

            _sql.Append("ORDER BY ");

            VisitJoin(overExpr.OrderByClause);
         }

         _sql.Append(")");


         return overExpr;
      }


      public virtual SqlExpr VisitSqlFunction(SqlFunctionExprBase functionExpr)
      {
         Check.NotNull(functionExpr, nameof(functionExpr));


         _sql.Append(functionExpr.Name)
             .Append("(");

         VisitJoin(functionExpr.Parameters);

         _sql.Append(")");


         return functionExpr;
      }


      public virtual SqlExpr VisitSqlDistinctableFunction(SqlDistinctableFunctionExpr functionExpr)
      {
         Check.NotNull(functionExpr, nameof(functionExpr));


         _sql.Append(functionExpr.Name)
             .Append(functionExpr.IsDistinct ? "(DISTINCT " : "(");

         VisitJoin(functionExpr.Parameters);

         _sql.Append(")");


         return functionExpr;
      }


      public virtual SqlExpr VisitCount(SqlCountExpr countExpr)
      {
         Check.NotNull(countExpr, nameof(countExpr));


         if (countExpr.Parameters.Any())
         {
            VisitSqlDistinctableFunction(countExpr);
         }
         else
         {
            _sql.Append("COUNT(*)");
         }


         return countExpr;
      }


      public virtual SqlExpr VisitExplicitCast(SqlExplicitCastExpr explicitCastExpr)
      {
         Check.NotNull(explicitCastExpr, nameof(explicitCastExpr));


         _sql.Append("CAST(");

         Visit(explicitCastExpr.Operand);

         _sql.Append(" AS ");

         var typeMapping = _relationalTypeMapper.FindMapping(explicitCastExpr.Type);

         if (typeMapping == null)
         {
            throw new InvalidOperationException(RelationalStrings.Mapping_UnsupportedType(explicitCastExpr.Type.Name));
         }

         _sql.Append(typeMapping.StoreType);

         _sql.Append(")");


         return explicitCastExpr;
      }


      #endregion


      #region [ Private Methods ]


      private void VisitJoin(
         IEnumerable<SqlExpr> expressions, Action<IRelationalCommandBuilder> joinAction = null)
         => VisitJoin(expressions, e => Visit(e), joinAction);


      private void VisitJoin<T>(
         IEnumerable<T> items, Action<T> itemAction, Action<IRelationalCommandBuilder> joinAction = null)
      {
         joinAction = joinAction ?? (rcb => rcb.Append(", "));

         bool first = true;
         foreach (var item in items)
         {
            if (!first)
            {
               joinAction(Sql);
            }

            itemAction(item);

            first = false;
         }
      }


      private void VisitComparisonOperator(SqlComparisonOperator @operator)
      {
         string op;

         switch (@operator)
         {
            case SqlComparisonOperator.Equal:
               op = " = ";
               break;
            case SqlComparisonOperator.NotEqual:
               op = " <> ";
               break;
            case SqlComparisonOperator.GreaterThan:
               op = " > ";
               break;
            case SqlComparisonOperator.GreaterThanOrEqual:
               op = " >= ";
               break;
            case SqlComparisonOperator.LessThan:
               op = " < ";
               break;
            case SqlComparisonOperator.LessThanOrEqual:
               op = " <= ";
               break;
            default:
               throw new ArgumentOutOfRangeException();
         }

         _sql.Append(op);
      }


      private void VisitBinaryOperator(SqlBinaryExpr binaryExpr)
      {
         string op = _binaryOperatorMap[binaryExpr.Operator];

         _sql.Append(op);
      }


      #endregion

   }

}
