// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Utilities;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlExistsExpr : SqlPredicateExpr
   {

      #region [ Constructors ]


      public SqlExistsExpr(SqlSelectExpr subQueryExpr)
      {
         Check.NotNull(subQueryExpr, nameof(subQueryExpr));


         SubQuery = subQueryExpr;
      }


      #endregion


      #region [ Properties ]


      public SqlSelectExpr SubQuery { get; }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitExists(this);


      #endregion

   }

}
