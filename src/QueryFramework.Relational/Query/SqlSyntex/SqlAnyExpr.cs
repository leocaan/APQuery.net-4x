// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlAnyExpr : SqlScalarSubQueryExpr
   {

      #region [ Consturctors ]


      public SqlAnyExpr(SqlSelectExpr subQuery)
         : base(subQuery)
      {
      }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitAny(this);


      #endregion

   }

}
