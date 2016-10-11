// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq.Expressions;

namespace QueryFramework.DBStruct
{

   public class EnumColumnDef<TModel, TEnum> : ColumnDef<TModel>
   {

      #region [ Constructors ]


      public EnumColumnDef(Expression<Func<TModel, TEnum>> expression)
      {
         ResolveColumnInfo(expression);
      }


      #endregion

   }

}
