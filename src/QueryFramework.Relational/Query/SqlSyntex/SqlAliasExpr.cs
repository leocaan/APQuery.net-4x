// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Utilities;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlAliasExpr : SqlProjectableExpr
   {

      #region [ Constructors ]


      public SqlAliasExpr(SqlOperableExpr operand, string alias)
         : base(Check.NotNull(operand, nameof(operand)))
      {
         Check.NotEmpty(alias, nameof(alias));


         Operand = operand;
         Alias = alias;
      }


      #endregion


      #region [ Properties ]


      public override SqlOperableExpr Operand { get; }


      public virtual string Alias { get; }


      public override string ResultName
         => Alias;


      #endregion


      #region [ 'Ordering' ]


      public new SqlOrderingExpr Asc
         => SqlExpr.Asc(this);


      public new SqlOrderingExpr Desc
         => SqlExpr.Desc(this);


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitAlias(this);


      #endregion

   }

}
