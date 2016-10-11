// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Utilities;

namespace QueryFramework.Query.SqlSyntex
{

   public abstract class SqlCombineResultExprBase : SqlExpr
   {

      #region [ Constructors ]


      protected SqlCombineResultExprBase(SqlSelectExpr nextQuery, string @operator)
      {
         Check.NotNull(nextQuery, nameof(nextQuery));
         Check.NotEmpty(@operator, nameof(@operator));


         NextQuery = nextQuery;
         Operator = @operator;
      }


      #endregion


      #region [ Properties ]


      public virtual string Operator { get; }


      public SqlSelectExpr NextQuery { get; }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitCombineResult(this);


      #endregion

   }

}
