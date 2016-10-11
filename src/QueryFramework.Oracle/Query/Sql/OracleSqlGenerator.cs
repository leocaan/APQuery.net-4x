// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.SqlSyntex;
using QueryFramework.Storage;
using QueryFramework.Utilities;
using System;
using System.Linq;

namespace QueryFramework.Query.Sql
{

   public class OracleSqlGenerator : DefaultSqlGenerator
   {

      #region [ Constructors ]


      public OracleSqlGenerator(
         IRelationalCommandBuilderFactory relationalCommandBuilderFactory,
         ISqlGenerationHelper sqlGenerationHelper,
         IParameterNameGeneratorFactory parameterNameGeneratorFactory,
         IQuerySourceAliasGeneratorFactory querySourceAliasGeneratorFactory,
         IRelationalTypeMapper relationalTypeMapper)
         : base(
              relationalCommandBuilderFactory,
              sqlGenerationHelper,
              parameterNameGeneratorFactory,
              querySourceAliasGeneratorFactory,
              relationalTypeMapper)
      {

      }


      #endregion


      #region [ Properties ]


      protected override string ParameterPrefix => ":";


      #endregion


      #region [ Methods ]


      public override SqlExpr VisitCombineResult(SqlCombineResultExprBase combineResultExpr)
      {
         Check.NotNull(combineResultExpr, nameof(combineResultExpr));


         if (!(combineResultExpr is SqlExceptExpr))
         {
            return base.VisitCombineResult(combineResultExpr);
         }

         Sql.AppendLine("MINUS");

         if (combineResultExpr.NextQuery.CombineResults.Any())
         {
            Sql.AppendLine("(");
         }

         Visit(combineResultExpr.NextQuery);

         if (combineResultExpr.NextQuery.CombineResults.Any())
         {
            Sql.AppendLine()
                .AppendLine(")");
         }


         return combineResultExpr;
      }


      public override SqlExpr VisitSelect(SqlSelectExpr selectExpr)
      {
         if (!ExprIsNull(selectExpr.Limit)
            && ExprIsNull(selectExpr.Offset))
         {
            var cloneQuery = CloneQuery(selectExpr);

            base.VisitSelect(cloneQuery);

            return selectExpr;
         }

         if (!ExprIsNull(selectExpr.Offset))
         {
            var subQuery = PushDownSubQuery(selectExpr, 0);
            var keepQuery = KeepQuery(selectExpr, subQuery);

            VisitSelect(keepQuery);

            return selectExpr;
         }


         return base.VisitSelect(selectExpr);
      }


      #endregion


      #region [ Private Methods ]


      private SqlSelectExpr CloneQuery(SqlSelectExpr sourceQuery)
      {
         var query = new SqlSelectExpr();


         query.AddToSelectClause(sourceQuery.SelectClause);
         query.AddToFromClause(sourceQuery.FromClause);
         query.AddToGroupByClause(sourceQuery.GroupByClause);
         query.AddToOrderByClause(sourceQuery.OrderByClause);
         query.HavingClause = sourceQuery.HavingClause;

         var limitExpr = SqlExpr.RawSql("ROWNUM") <= sourceQuery.Limit;
         query.WhereClause = sourceQuery.WhereClause != null
            ? sourceQuery.WhereClause & limitExpr
            : limitExpr;

         query.IsDistinct = sourceQuery.IsDistinct;


         return query;
      }


      private SqlSelectExpr PushDownSubQuery(SqlSelectExpr sourceQuery, int depth)
      {
         var subQuery = new SqlSelectExpr("t_" + depth);

         subQuery.AddToSelectClause(sourceQuery.SelectClause);

         var overExpr = SqlExpr.Over(SqlExpr.RowNumber());
         if (sourceQuery.OrderByClause.Any())
         {
            foreach (var order in sourceQuery.OrderByClause)
            {
               var aliasExpr = order.Operand as SqlAliasExpr;

               if (aliasExpr != null)
               {
                  overExpr.AddToOrderByClause(new SqlOrderingExpr(aliasExpr.Operand, order.OrderingDirection));
               }
               else
               {
                  overExpr.AddToOrderByClause(order);
               }
            }
         }
         else
         {
            overExpr.AddToOrderByClause(SqlExpr.RawSql("@@ROWCOUNT").Asc);
         }
         subQuery.AddToSelectClause(overExpr.As("ROWID"));

         subQuery.AddToFromClause(sourceQuery.FromClause);
         subQuery.WhereClause = sourceQuery.WhereClause;
         subQuery.AddToGroupByClause(sourceQuery.GroupByClause);
         subQuery.HavingClause = sourceQuery.HavingClause;

         subQuery.IsDistinct = sourceQuery.IsDistinct;


         return subQuery;
      }


      private SqlSelectExpr KeepQuery(SqlSelectExpr sourceQuery, SqlSelectExpr subQuery)
      {
         var query = new SqlSelectExpr();


         foreach (var expr in sourceQuery.SelectClause)
         {
            if (expr.ResultName != null)
            {
               query.AddToSelectClause(new SqlColumnExpr(subQuery, expr.ResultName));
            }
            else
            {
               query.ClearSelectClause()
                    .AddToSelectClause(SqlExpr.Star);
               break;
            }
         }

         query.AddToFromClause(subQuery);

         if (ExprIsNull(sourceQuery.Limit))
         {
            query.WhereClause = SqlExpr.RawSql("ROWID") > sourceQuery.Offset;
         }
         else
         {
            query.WhereClause = SqlExpr.RawSql("ROWID").Between(
               OptimizeAdd(sourceQuery.Offset, SqlExpr.Constant(1)),
               OptimizeAdd(sourceQuery.Offset, sourceQuery.Limit));
         }


         return query;
      }


      private SqlOperableExpr OptimizeAdd(SqlOperableExpr leftExpr, SqlOperableExpr rightExpr)
      {
         SqlConstantExpr leftConstExpr = leftExpr as SqlConstantExpr;
         SqlConstantExpr rightConstExpr = rightExpr as SqlConstantExpr;

         if (!ExprIsNull(leftConstExpr) && !ExprIsNull(rightConstExpr))
         {
            if (leftConstExpr.Value.GetType().IsInteger() && rightConstExpr.Value.GetType().IsInteger())
            {
               long value = Convert.ToInt32(leftConstExpr.Value)
                  + Convert.ToInt32(rightConstExpr.Value);

               return SqlExpr.Constant(value);
            }
         }


         return SqlExpr.Add(leftExpr, rightExpr);
      }


      #endregion

   }

}
