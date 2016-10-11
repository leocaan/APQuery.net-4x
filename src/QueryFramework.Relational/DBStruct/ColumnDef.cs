// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.SqlSyntex;
using System;
using System.Linq.Expressions;

namespace QueryFramework.DBStruct
{

   public abstract class ColumnDef<TModel> : SqlColumnExpr
   {

      #region [ Constructors ]


      protected ColumnDef()
      {

      }


      #endregion


      #region [ Properties ]


      public TableDef<TModel> TableDef
      {
         get { return Table as TableDef<TModel>; }
         set { Table = value; }
      }


      public bool Nullable { get; set; }


      #endregion


      #region [ Internal Memthods ]


      internal void ResolveColumnInfo<TProperty>(Expression<Func<TModel, TProperty>> expression)
      {
         if (expression == null)
            throw new ArgumentNullException(nameof(expression));
         if (expression.Body.NodeType != ExpressionType.MemberAccess)
            throw new ArgumentException(nameof(expression));

         MemberExpression memberExpression = expression.Body as MemberExpression;

         string propertyName = memberExpression.Member?.Name;
         Type containerType = memberExpression.Expression.Type;

         Name = propertyName;

         if (expression.ReturnType.IsGenericType && expression.ReturnType.IsValueType)
         {
            Nullable = true;
         }
      }


      #endregion

   }

}
