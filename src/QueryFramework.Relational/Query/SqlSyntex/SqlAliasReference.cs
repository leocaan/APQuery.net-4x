// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Utilities;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlAliasReferenceExpr : SqlOperableExpr
   {

      #region [ Constructors ]


      public SqlAliasReferenceExpr(string alias)
      {
         Check.NotEmpty(alias, nameof(alias));


         Alias = alias;
      }


      #endregion


      #region [ Properties ]


      public virtual string Alias { get; }


      #endregion


      #region [ 'Ordering' ]


      public new SqlOrderingExpr Asc
         => SqlExpr.Asc(this);


      public new SqlOrderingExpr Desc
         => SqlExpr.Desc(this);


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitAliasReference(this);


      #endregion

   }

}
