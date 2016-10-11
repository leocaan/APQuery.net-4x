// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq.Expressions;

namespace QueryFramework.DBStruct
{

   public class BooleanColumnDef<TModel> : ColumnDef<TModel>
   {

      #region [ Constructors ]


      public BooleanColumnDef(Expression<Func<TModel, Boolean>> expression)
      {
         ResolveColumnInfo(expression);
      }


      public BooleanColumnDef(Expression<Func<TModel, Boolean?>> expression)
      {
         ResolveColumnInfo(expression);
      }


      #endregion

   }

}
