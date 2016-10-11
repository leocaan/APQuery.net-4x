// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlUnionExpr : SqlCombineResultExprBase
   {

      #region [ Constructors ]


      public SqlUnionExpr(SqlSelectExpr nextQuery, bool isAll)
         :base(nextQuery, isAll ? "UNION ALL" : "UNION")
      {
      }


      #endregion


      #region [ Properties ]


      public virtual bool IsAll { get; }


      #endregion

   }

}
