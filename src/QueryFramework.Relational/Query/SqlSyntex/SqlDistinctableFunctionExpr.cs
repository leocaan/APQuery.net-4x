// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlDistinctableFunctionExpr : SqlFunctionExprBase
   {

      #region [ Constructors ]


      public SqlDistinctableFunctionExpr(string name)
         : base(name)
      {
      }


      #endregion


      #region [ Properties ]


      public virtual bool IsDistinct { get; private set; }


      #endregion


      #region [ Methods ]


      public virtual SqlDistinctableFunctionExpr Distinct()
      {
         IsDistinct = true;


         return this;
      }


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitSqlDistinctableFunction(this);


      #endregion

   }

}
