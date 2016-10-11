// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Utilities;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlIsNullExpr : SqlPredicateExpr
   {

      #region [ Consturctors ]


      public SqlIsNullExpr(SqlOperableExpr operand)
      {
         Check.NotNull(operand, nameof(operand));


         Operand = operand;
      }


      #endregion

      
      #region [ Properties ]


      public SqlOperableExpr Operand { get; }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitIsNull(this);


      #endregion

   }

}
