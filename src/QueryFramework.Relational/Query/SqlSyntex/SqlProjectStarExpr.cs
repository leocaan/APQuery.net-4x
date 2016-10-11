// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlProjectStarExpr : SqlProjectableExpr
   {

      #region [ Constructors ]


      public SqlProjectStarExpr(SqlQuerySourceExpr tableExpr)
         : base(null)
      {
         Table = tableExpr;
      }


      #endregion


      #region [ Properties ]


      public virtual SqlQuerySourceExpr Table { get; }


      public override string ResultName
         => null;


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitProjectStar(this);


      #endregion

   }

}
