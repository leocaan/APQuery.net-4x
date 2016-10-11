// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq.Expressions;

namespace QueryFramework.DBStruct
{

   public class DecimalColumnDef<TModel> : NumericTypeColumnDef<TModel>
   {

      #region [ Constructors ]


      public DecimalColumnDef(Expression<Func<TModel, Decimal>> expression)
      {
         ResolveColumnInfo(expression);
      }


      public DecimalColumnDef(Expression<Func<TModel, Decimal?>> expression)
      {
         ResolveColumnInfo(expression);
      }


      #endregion

   }

}
