// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq.Expressions;

namespace QueryFramework.DBStruct
{

   public class Int64ColumnDef<TModel> : NumericTypeColumnDef<TModel>
   {

      #region [ Constructors ]


      public Int64ColumnDef(Expression<Func<TModel, long>> expression)
      {
         ResolveColumnInfo(expression);
      }


      public Int64ColumnDef(Expression<Func<TModel, long?>> expression)
      {
         ResolveColumnInfo(expression);
      }


      public Int64ColumnDef(Expression<Func<TModel, ulong>> expression)
      {
         ResolveColumnInfo(expression);
      }


      public Int64ColumnDef(Expression<Func<TModel, ulong?>> expression)
      {
         ResolveColumnInfo(expression);
      }


      #endregion

   }

}
