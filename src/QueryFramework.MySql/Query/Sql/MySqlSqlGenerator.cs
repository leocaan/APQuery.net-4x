// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Internal;
using QueryFramework.Query.SqlSyntex;
using QueryFramework.Storage;
using QueryFramework.Utilities;

namespace QueryFramework.Query.Sql
{

   public class MySqlSqlGenerator : DefaultSqlGenerator
   {

      #region [ Constructors ]


      public MySqlSqlGenerator(
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


      public override SqlExpr VisitTable(SqlTableExpr tableExpr)
      {
         Check.NotNull(tableExpr, nameof(tableExpr));


         Sql.Append(SqlGenerator.DelimitIdentifier(tableExpr.Name))
             .Append(" AS ")
             .Append(SqlGenerator.DelimitIdentifier(QuerySourceAliasGenerator.GetUniqueTableAlias(tableExpr)));


         return tableExpr;
      }


      public override SqlExpr VisitLateralJoin(SqlLateralJoinExpr lateralJoinExpr)
      {
         throw new System.NotSupportedException(MySqlStrings.SqlSyntex_NotSupported_LateralJoin_Expr("MySql"));
      }


      public override SqlExpr VisitGroupingSets(SqlMultipleGroupingSetsExprBase groupingSetsExpr)
      {
         throw new System.NotSupportedException(MySqlStrings.SqlSyntex_NotSupported_MultipleGroupingSets_Expr("MySql"));
      }


      public override SqlExpr VisitCombineResult(SqlCombineResultExprBase combineResultExpr)
      {
         if (combineResultExpr is SqlIntersectExpr || combineResultExpr is SqlExceptExpr)
            throw new System.NotSupportedException(MySqlStrings.SqlSyntex_NotSupported_CombineResult_Expr_Part("MySql"));

         return base.VisitCombineResult(combineResultExpr);
      }


      protected override void GenerateTop(SqlSelectExpr selectExpr)
      {
         // Handled by GenerateLimitOffset
      }


      protected override void GenerateLimitOffset(SqlSelectExpr selectExpr)
      {
         Check.NotNull(selectExpr, nameof(selectExpr));


         if (!ExprIsNull(selectExpr.Limit))
         {
            Sql.AppendLine()
               .Append("LIMIT ");
            Visit(selectExpr.Limit);
         }

         if (!ExprIsNull(selectExpr.Offset))
         {
            if (ExprIsNull(selectExpr.Limit))
            {
               Sql.AppendLine()
                  .Append("LIMIT 18446744073709551610");
            }
            Sql.Append(" OFFSET ");
            Visit(selectExpr.Offset);
         }
      }


      #endregion

   }

}
