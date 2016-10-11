// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq.Expressions;

namespace QueryFramework.DBStruct
{

   public class TimeSpanColumnDef<TModel> : ColumnDef<TModel>
   {
      
      #region [ Constructors ]


      public TimeSpanColumnDef(Expression<Func<TModel, TimeSpan>> expression)
      {
         ResolveColumnInfo(expression);
      }


      public TimeSpanColumnDef(Expression<Func<TModel, TimeSpan?>> expression)
      {
         ResolveColumnInfo(expression);
      }


      #endregion
      
   }

}
