// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.SqlSyntex;
using QueryFramework.Storage;
using QueryFramework.Utilities;
using System.Linq;

namespace QueryFramework.Query.Sql
{

   public class SqlServer2012SqlGenerator : DefaultSqlGenerator
   {

      #region [ Constructors ]


      public SqlServer2012SqlGenerator(
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


      public override SqlExpr VisitLateralJoin(SqlLateralJoinExpr lateralJoinExpr)
      {
         Check.NotNull(lateralJoinExpr, nameof(lateralJoinExpr));


         Sql.Append("CROSS APPLY ");

         Visit(lateralJoinExpr.TableExpr);


         return lateralJoinExpr;
      }


      protected override void GenerateLimitOffset(SqlSelectExpr selectExpr)
      {
         if (!ExprIsNull(selectExpr.Offset) && !selectExpr.OrderByClause.Any())
         {
            Sql.AppendLine()
               .Append("ORDER BY @@ROWCOUNT");
         }

         base.GenerateLimitOffset(selectExpr);
      }


      #endregion

   }

}
