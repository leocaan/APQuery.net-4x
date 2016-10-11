// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlGroupableExpr : SqlExpr
   {

      #region [ Constructors ]


      public SqlGroupableExpr(SqlOperableExpr operand)
      {
         Operand = operand;
      }


      #endregion


      #region [ Properties ]


      public virtual SqlOperableExpr Operand { get; }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
      {
         Operand.Accept(visitor);
         return this;
      }


      #endregion


      #region [ Override Implementation of Implicit Operator ]


      public static implicit operator SqlGroupableExpr(SqlOperableExpr expr)
         => new SqlGroupableExpr(expr);


      #endregion

   }

}
