// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.SqlSyntex;
using QueryFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QueryFramework.DBStruct
{

   public class StringColumnDef<TModel> : ColumnDef<TModel>
   {

      #region [ Constructors ]


      public StringColumnDef(Expression<Func<TModel, String>> expression)
      {
         ResolveColumnInfo(expression);
      }


      #endregion


      #region [ Override Implementation of Operator ]


      public static SqlPredicateExpr operator ==(StringColumnDef<TModel> column, string value)
         => value == null
            ? SqlExpr.IsNull(column) as SqlPredicateExpr
            : SqlExpr.Equal(column, SqlExpr.Parameter(value));

      public static SqlPredicateExpr operator !=(StringColumnDef<TModel> column, string value)
         => value == null
            ? SqlExpr.IsNotNull(column) as SqlPredicateExpr
            : SqlExpr.NotEqual(column, SqlExpr.Parameter(value));


      public static SqlPredicateExpr operator ==(string value, StringColumnDef<TModel> column)
         => value == null
            ? SqlExpr.IsNull(column) as SqlPredicateExpr
            : SqlExpr.Equal(SqlExpr.Parameter(value), column);

      public static SqlPredicateExpr operator !=(string value, StringColumnDef<TModel> column)
         => value == null
            ? SqlExpr.IsNotNull(column) as SqlPredicateExpr
            : SqlExpr.NotEqual(column, SqlExpr.Parameter(value));


      public static SqlPredicateExpr operator >(StringColumnDef<TModel> column, string value)
         => SqlExpr.GreaterThan(column, SqlExpr.Parameter(value));

      public static SqlPredicateExpr operator <(StringColumnDef<TModel> column, string value)
         => SqlExpr.LessThan(column, SqlExpr.Parameter(value));


      public static SqlPredicateExpr operator >(string value, StringColumnDef<TModel> column)
         => SqlExpr.GreaterThan(SqlExpr.Parameter(value), column);

      public static SqlPredicateExpr operator <(string value, StringColumnDef<TModel> column)
         => SqlExpr.LessThan(SqlExpr.Parameter(value), column);


      public static SqlPredicateExpr operator >=(StringColumnDef<TModel> column, string value)
         => SqlExpr.GreaterThanOrEqual(column, SqlExpr.Parameter(value));

      public static SqlPredicateExpr operator <=(StringColumnDef<TModel> column, string value)
         => SqlExpr.LessThanOrEqual(column, SqlExpr.Parameter(value));


      public static SqlPredicateExpr operator >=(string value, StringColumnDef<TModel> column)
         => SqlExpr.GreaterThanOrEqual(SqlExpr.Parameter(value), column);

      public static SqlPredicateExpr operator <=(string value, StringColumnDef<TModel> column)
         => SqlExpr.LessThanOrEqual(SqlExpr.Parameter(value), column);


      public override bool Equals(object obj)
         => object.ReferenceEquals(this, obj);

      public override int GetHashCode()
         => base.GetHashCode();


      #endregion


      #region [ SqlExpr Operator ]


      public SqlInExpr In(params string[] values)
         => SqlExpr.In(this, Check.NotNull(values, nameof(values)).Cast<object>().Select(SqlExpr.Constant));

      public SqlNotExpr NotIn(params string[] values)
         => SqlExpr.NotIn(this, Check.NotNull(values, nameof(values)).Cast<object>().Select(SqlExpr.Constant));


      public SqlInExpr In(IEnumerable<string> values)
         => SqlExpr.In(this, Check.NotNull(values, nameof(values)).Cast<object>().Select(SqlExpr.Constant));

      public SqlNotExpr NotIn(IEnumerable<string> values)
         => SqlExpr.NotIn(this, Check.NotNull(values, nameof(values)).Cast<object>().Select(SqlExpr.Constant));


      public SqlBetweenExpr Between(string begin, string end)
         => SqlExpr.Between(this, SqlExpr.Parameter(begin), SqlExpr.Parameter(end));

      public SqlNotExpr NotBetween(string begin, string end)
         => SqlExpr.NotBetween(this, SqlExpr.Parameter(begin), SqlExpr.Parameter(end));


      public SqlLikeExpr Like(string pattern)
         => SqlExpr.Like(this, SqlExpr.Constant(pattern));

      public SqlNotExpr NotLike(string pattern)
         => SqlExpr.NotLike(this, SqlExpr.Constant(pattern));


      public SqlLikeExpr StartWith(string pattern)
         => SqlExpr.Like(this, SqlExpr.Constant(pattern + "%"));

      public SqlLikeExpr EndWith(string pattern)
         => SqlExpr.Like(this, SqlExpr.Constant("%" + pattern));

      public SqlLikeExpr Contains(string pattern)
         => SqlExpr.Like(this, SqlExpr.Constant("%" + pattern + "%"));


      #endregion

   }

}
