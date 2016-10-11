// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Utilities;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlBinaryExpr : SqlOperableExpr
   {

      #region [ Constructors ]


      public SqlBinaryExpr(SqlOperableExpr left, SqlOperableExpr right, SqlBinaryOperator @operator)
      {
         Check.NotNull(left, nameof(left));
         Check.NotNull(right, nameof(right));


         Left = left;
         Right = right;
         Operator = @operator;
      }


      #endregion


      #region [ Properties ]


      public SqlOperableExpr Left { get; }


      public SqlOperableExpr Right { get; }


      public SqlBinaryOperator Operator { get; }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitBinary(this);


      #endregion

   }

}
