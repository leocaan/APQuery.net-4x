// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq.Expressions;

namespace QueryFramework.DBStruct
{

   public class SByteColumnDef<TModel> : NumericTypeColumnDef<TModel>
   {
      
      #region [ Constructors ]


      public SByteColumnDef(Expression<Func<TModel, sbyte>> expression)
      {
         ResolveColumnInfo(expression);
      }


      public SByteColumnDef(Expression<Func<TModel, sbyte?>> expression)
      {
         ResolveColumnInfo(expression);
      }


      public SByteColumnDef(Expression<Func<TModel, byte>> expression)
      {
         ResolveColumnInfo(expression);
      }


      public SByteColumnDef(Expression<Func<TModel, byte?>> expression)
      {
         ResolveColumnInfo(expression);
      }


      #endregion

   }

}
