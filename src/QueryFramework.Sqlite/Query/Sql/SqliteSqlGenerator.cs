// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Internal;
using QueryFramework.Query.SqlSyntex;
using QueryFramework.Storage;
using QueryFramework.Utilities;

namespace QueryFramework.Query.Sql
{

   public class SqliteSqlGenerator : DefaultSqlGenerator
   {

      #region [ Constructors ]


      public SqliteSqlGenerator(
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


      protected override string ConcatOperator => "||";


      protected override string ParameterPrefix => "$";


      #endregion


      #region [ Methods ]


      public override SqlExpr VisitRightOuterJoin(SqlRightOuterJoinExpr rightOuterJoinExpr)
      {
         throw new System.NotSupportedException(SqliteStrings.SqlSyntex_NotSupported_RightOutJoin_Expr("Sqlite"));
      }


      public override SqlExpr VisitLateralJoin(SqlLateralJoinExpr lateralJoinExpr)
      {
         throw new System.NotSupportedException(SqliteStrings.SqlSyntex_NotSupported_LateralJoin_Expr("MySql"));
      }


      public override SqlExpr VisitGroupingSets(SqlMultipleGroupingSetsExprBase groupingSetsExpr)
      {
         throw new System.NotSupportedException(SqliteStrings.SqlSyntex_NotSupported_MultipleGroupingSets_Expr("Sqlite"));
      }


      public override SqlExpr VisitCombineResult(SqlCombineResultExprBase combineResultExpr)
      {
         if (combineResultExpr is SqlIntersectExpr || combineResultExpr is SqlExceptExpr)
         {
            throw new System.NotSupportedException(SqliteStrings.SqlSyntex_NotSupported_CombineResult_Expr_Part("Sqlite"));
         }


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
                  .Append("LIMIT -1");
            }
            Sql.Append(" OFFSET ");
            Visit(selectExpr.Offset);
         }
      }


      #endregion

   }

}
