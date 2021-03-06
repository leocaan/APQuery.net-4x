﻿// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Utilities;
using System.Collections.Generic;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlInExpr : SqlPredicateExpr
   {

      #region [ Fields ]


      private readonly List<SqlOperableExpr> _values = new List<SqlOperableExpr>();


      #endregion


      #region [ Constructors ]


      public SqlInExpr(SqlOperableExpr operand, IEnumerable<SqlOperableExpr> values)
      {
         Check.NotNull(operand, nameof(operand));
         Check.NotNull(values, nameof(values));


         Operand = operand;
         _values.AddRange(values);
      }


      #endregion


      #region [ Properties ]


      public SqlOperableExpr Operand { get; }


      public IReadOnlyList<SqlOperableExpr> Values
         => _values;


      #endregion


      #region [ Methods ]


      public void AddExpr(SqlOperableExpr expr)
         => _values.Add(Check.NotNull(expr, nameof(expr)));


      public void AddExpr(IEnumerable<SqlOperableExpr> exprs)
         => _values.AddRange(Check.NotNull(exprs, nameof(exprs)));


      public void AddExpr(params SqlOperableExpr[] exprs)
         => _values.AddRange(Check.NotNull(exprs, nameof(exprs)));


      public void ClearExpr()
         => _values.Clear();


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitIn(this);


      #endregion

   }

}
