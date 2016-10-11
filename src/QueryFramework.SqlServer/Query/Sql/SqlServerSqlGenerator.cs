// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.SqlSyntex;
using QueryFramework.Storage;
using QueryFramework.Utilities;
using System;
using System.Linq;

namespace QueryFramework.Query.Sql
{

   public class SqlServerSqlGenerator : DefaultSqlGenerator
   {

      #region [ Constructors ]


      public SqlServerSqlGenerator(
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


      #region [ Methods ]


      public override SqlExpr VisitSelect(SqlSelectExpr selectExpr)
      {
         if (!ExprIsNull(selectExpr.Offset))
         {
            var subQuery = PushDownSubQuery(selectExpr, 0);
            var keepQuery = KeepQuery(selectExpr, subQuery);

            VisitSelect(keepQuery);

            return selectExpr;
         }

         return base.VisitSelect(selectExpr);
      }


      public override SqlExpr VisitLateralJoin(SqlLateralJoinExpr lateralJoinExpr)
      {
         Check.NotNull(lateralJoinExpr, nameof(lateralJoinExpr));


         Sql.Append("CROSS APPLY ");

         Visit(lateralJoinExpr.TableExpr);


         return lateralJoinExpr;
      }


      #endregion


      #region [ Private Methods ]


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
         if (!ExprIsNull(sourceQuery.Limit))
         {
            subQuery.Limit = OptimizeAdd(sourceQuery.Limit, sourceQuery.Offset);
         }


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

         query.WhereClause = SqlExpr.AsReference("ROWID") > sourceQuery.Offset;


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
