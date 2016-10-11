// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Utilities;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlNotExpr : SqlPredicateExpr
   {

      #region [ Consturctors ]


      public SqlNotExpr(SqlPredicateExpr operand)
      {
         Check.NotNull(operand, nameof(operand));


         Operand = operand;
      }


      #endregion

      
      #region [ Properties ]


      public SqlPredicateExpr Operand { get; }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitNot(this);


      #endregion

   }

}
