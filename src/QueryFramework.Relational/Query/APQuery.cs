// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.SqlSyntex;
using System.Collections.Generic;

namespace QueryFramework.Query
{

   public static class APQuery
   {

      #region [ 'SELECT ']


      public static SqlSelectExpr select(SqlProjectableExpr expr)
         => new SqlSelectExpr().AddToSelectClause(expr);


      public static SqlSelectExpr select(IEnumerable<SqlProjectableExpr> exprs)
         => new SqlSelectExpr().AddToSelectClause(exprs);


      public static SqlSelectExpr select(params SqlProjectableExpr[] exprs)
         => new SqlSelectExpr().AddToSelectClause(exprs);


      #endregion

   }

}
