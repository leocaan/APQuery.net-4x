// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq.Expressions;

namespace QueryFramework.DBStruct
{

   public class Int16ColumnDef<TModel> : NumericTypeColumnDef<TModel>
   {

      #region [ Constructors ]


      public Int16ColumnDef(Expression<Func<TModel, short>> expression)
      {
         ResolveColumnInfo(expression);
      }


      public Int16ColumnDef(Expression<Func<TModel, short?>> expression)
      {
         ResolveColumnInfo(expression);
      }


      public Int16ColumnDef(Expression<Func<TModel, ushort>> expression)
      {
         ResolveColumnInfo(expression);
      }


      public Int16ColumnDef(Expression<Func<TModel, ushort?>> expression)
      {
         ResolveColumnInfo(expression);
      }


      #endregion

   }

}
