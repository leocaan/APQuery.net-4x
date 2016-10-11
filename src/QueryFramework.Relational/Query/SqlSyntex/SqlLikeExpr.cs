// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Utilities;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlLikeExpr : SqlPredicateExpr
   {

      #region [ Constructors ]


      public SqlLikeExpr(SqlOperableExpr match, SqlOperableExpr pattern)
      {
         Check.NotNull(match, nameof(match));
         Check.NotNull(pattern, nameof(pattern));


         Match = match;
         Pattern = pattern;
      }


      #endregion


      #region [ Properties ]


      public SqlOperableExpr Match { get; }


      public SqlOperableExpr Pattern { get; }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitLike(this);


      #endregion

   }

}
