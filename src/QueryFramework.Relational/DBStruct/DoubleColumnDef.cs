// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq.Expressions;

namespace QueryFramework.DBStruct
{

   public class DoubleColumnDef<TModel> : ColumnDef<TModel>
   {

      #region [ Constructors ]


      public DoubleColumnDef(Expression<Func<TModel, double>> expression)
      {
         ResolveColumnInfo(expression);
      }


      public DoubleColumnDef(Expression<Func<TModel, double?>> expression)
      {
         ResolveColumnInfo(expression);
      }


      #endregion

   }

}
