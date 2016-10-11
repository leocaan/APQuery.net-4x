// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.SqlSyntex;
using QueryFramework.Storage;
using QueryFramework.Utilities;
using System.Linq;

namespace QueryFramework.Query.Sql
{

   public class Oracle12SqlGenerator : DefaultSqlGenerator
   {

      #region [ Constructors ]


      public Oracle12SqlGenerator(
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


      protected override void GenerateTop(SqlSelectExpr selectExpr)
      {
         // Handled by GenerateLimitOffset
      }


      protected override void GenerateLimitOffset(SqlSelectExpr selectExpr)
      {
         Check.NotNull(selectExpr, nameof(selectExpr));


         if (!ExprIsNull(selectExpr.Limit)
            || !ExprIsNull(selectExpr.Offset))
         {
            if (!selectExpr.OrderByClause.Any())
            {
               Sql.AppendLine()
                  .Append("ORDER BY @@ROWCOUNT");
            }

            if (!ExprIsNull(selectExpr.Offset))
            {
               Sql.AppendLine()
                  .Append("OFFSET ")
                  .Append(selectExpr.Offset)
                  .Append(" ROWS");

               if (!ExprIsNull(selectExpr.Limit))
               {
                  Sql.Append(" FETCH NEXT ")
                     .Append(selectExpr.Limit)
                     .Append(" ROWS ONLY");
               }
            }
            else if (!ExprIsNull(selectExpr.Limit))
            {
               Sql.Append(" FETCH FIRST ")
                  .Append(selectExpr.Limit)
                  .Append(" ROWS ONLY");
            }
         }
      }


      #endregion

   }

}
