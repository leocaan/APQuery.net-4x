// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlInnerJoinExpr : SqlJoinExprBase
   {

      #region [ Constructors ]


      public SqlInnerJoinExpr(SqlQuerySourceExpr tableExpr)
         : base(tableExpr)
      {
      }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitInnerJoin(this);


      #endregion

   }

}
