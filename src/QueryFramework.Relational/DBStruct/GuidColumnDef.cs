// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq.Expressions;

namespace QueryFramework.DBStruct
{

   public class GuidColumnDef<TModel> : IdentifiableColumnDef<TModel>
   {

      #region [ Constructors ]


      public GuidColumnDef(Expression<Func<TModel, Guid>> expression)
      {
         ResolveColumnInfo(expression);
      }


      public GuidColumnDef(Expression<Func<TModel, Guid?>> expression)
      {
         ResolveColumnInfo(expression);
      }


      #endregion

   }

}
