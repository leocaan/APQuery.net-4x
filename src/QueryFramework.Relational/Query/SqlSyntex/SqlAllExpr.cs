// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlAllExpr : SqlScalarSubQueryExpr
   {

      #region [ Consturctors ]


      public SqlAllExpr(SqlSelectExpr subQuery)
         : base(subQuery)
      {
      }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitAll(this);


      #endregion

   }

}
