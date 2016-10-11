// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Utilities;
using System;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlExplicitCastExpr: SqlOperableExpr
   {

      #region [ Constructors ]


      public SqlExplicitCastExpr(SqlOperableExpr operand, Type type)
      {
         Check.NotNull(operand, nameof(operand));
         Check.NotNull(type, nameof(type));


         Operand = operand;
         Type = type;
      }


      #endregion


      #region [ Properties ]


      public SqlOperableExpr Operand { get; }


      public Type Type { get; }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitExplicitCast(this);


      #endregion

   }

}
