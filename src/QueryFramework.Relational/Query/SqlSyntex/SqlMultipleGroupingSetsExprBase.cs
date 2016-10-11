// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Utilities;
using System.Collections.Generic;

namespace QueryFramework.Query.SqlSyntex
{

   public abstract class SqlMultipleGroupingSetsExprBase : SqlGroupableExpr
   {

      #region [ Fields ]


      private readonly List<SqlGroupableExpr> _exprs = new List<SqlGroupableExpr>();


      #endregion


      #region [ Constructors ]


      internal SqlMultipleGroupingSetsExprBase(string @operator)
         : base(null)
      {
         Check.NotEmpty(@operator, nameof(@operator));


         Operator = @operator;
      }


      #endregion


      #region [ Properties ]


      public virtual string Operator { get; }


      public IReadOnlyList<SqlGroupableExpr> Exprs
         => _exprs;


      #endregion


      #region [ Methods ]


      public void AddExpr(SqlGroupableExpr expr)
         => _exprs.Add(Check.NotNull(expr, nameof(expr)));


      public void AddExpr(IEnumerable<SqlGroupableExpr> exprs)
         => _exprs.AddRange(Check.NotNull(exprs, nameof(exprs)));


      public void AddExpr(params SqlGroupableExpr[] exprs)
         => _exprs.AddRange(Check.NotNull(exprs, nameof(exprs)));


      public void ClearExpr()
         => _exprs.Clear();


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitGroupingSets(this);


      #endregion

   }

}
