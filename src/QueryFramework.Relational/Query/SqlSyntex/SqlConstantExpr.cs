// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlConstantExpr : SqlOperableExpr
   {

      #region [ Constructors ]


      public SqlConstantExpr(object value)
      {
         Value = value;
      }


      #endregion


      #region [ Properties ]


      public virtual object Value { get; }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitConstant(this);


      #endregion

   }

}
