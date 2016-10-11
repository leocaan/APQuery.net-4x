// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.SqlSyntex;

namespace QueryFramework.DBStruct
{

   public abstract class NumericTypeColumnDef<TModel> : IdentifiableColumnDef<TModel>
   {

      #region [ SqlExpr Operator ]


      public SqlAvgExpr Avg()
         => SqlExpr.Avg(this);


      public SqlSumExpr Sum()
         => SqlExpr.Sum(this);


      public SqlMaxExpr Max()
         => SqlExpr.Max(this);


      public SqlMinExpr Min()
         => SqlExpr.Min(this);


      public SqlCountExpr Count()
         => SqlExpr.Count(this);


      #endregion

   }

}
