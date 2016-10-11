// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq.Expressions;

namespace QueryFramework.DBStruct
{

   public class BytesColumnDef<TModel> : ColumnDef<TModel>
   {

      #region [ Constructors ]


      public BytesColumnDef(Expression<Func<TModel, Byte[]>> expression)
      {
         ResolveColumnInfo(expression);
      }


      #endregion

   }

}
