// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Utilities;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlLateralJoinExpr : SqlQuerySourceExpr
   {

      #region [ Constructors ]


      public SqlLateralJoinExpr(SqlQuerySourceExpr tableExpr)
         : base(Check.NotNull(tableExpr, nameof(tableExpr)).QuerySource, tableExpr.Alias)
      {
         TableExpr = tableExpr;
      }


      #endregion


      #region [ Properties ]


      public SqlQuerySourceExpr TableExpr { get; }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitLateralJoin(this);


      #endregion

   }

}
