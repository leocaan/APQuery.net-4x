// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Utilities;
using System.Collections.Generic;

namespace QueryFramework.Query.SqlSyntex
{

   public abstract class SqlFunctionExprBase : SqlOperableExpr
   {

      #region [ Fields ]


      private readonly List<SqlOperableExpr> _parameters = new List<SqlOperableExpr>();


      #endregion


      #region [ Constructors ]


      protected SqlFunctionExprBase(string name)
      {
         Check.NotNull(name, nameof(name));


         Name = name;
      }


      #endregion


      #region [ Properties ]


      public virtual string Name { get; }


      public virtual IReadOnlyList<SqlOperableExpr> Parameters
         => _parameters;


      #endregion


      #region [ Methods ]


      public virtual SqlFunctionExprBase AddParameter(SqlOperableExpr expr)
      {
         _parameters.Add(Check.NotNull(expr, nameof(expr)));


         return this;
      }


      public virtual SqlFunctionExprBase AddParameter(IEnumerable<SqlOperableExpr> exprs)
      {
         _parameters.AddRange(Check.NotNull(exprs, nameof(exprs)));


         return this;
      }


      public virtual SqlFunctionExprBase AddParameter(params SqlOperableExpr[] exprs)
      {
         _parameters.AddRange(Check.NotNull(exprs, nameof(exprs)));


         return this;
      }


      public virtual SqlFunctionExprBase ClearParameters()
      {
         _parameters.Clear();


         return this;
      }


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitSqlFunction(this);


      #endregion

   }

}
