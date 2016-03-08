using Symber.Data.SqlSyntex;
using Symber.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Symber.Data.DBStruct
{

	public class Int32ColumnDef<TModel> : NumericTypeColumnDef<TModel>
	{

		#region [ Constructors ]


		public Int32ColumnDef(Expression<Func<TModel, int>> expression)
		{
			ResolveColumnInfo(expression);
		}


		public Int32ColumnDef(Expression<Func<TModel, int?>> expression)
		{
			ResolveColumnInfo(expression);
		}


		public Int32ColumnDef(Expression<Func<TModel, uint>> expression)
		{
			ResolveColumnInfo(expression);
		}


		public Int32ColumnDef(Expression<Func<TModel, uint?>> expression)
		{
			ResolveColumnInfo(expression);
		}


		#endregion


		#region [ Override Implementation of Operator ]


		public static SqlPredicateExpr operator ==(Int32ColumnDef<TModel> column, int value)
			=> SqlExpr.Equal(column, SqlExpr.Parameter(value));

		public static SqlPredicateExpr operator !=(Int32ColumnDef<TModel> column, int value)
			=> SqlExpr.NotEqual(column, SqlExpr.Parameter(value));


		public static SqlPredicateExpr operator ==(int value, Int32ColumnDef<TModel> column)
			=> SqlExpr.Equal(SqlExpr.Parameter(value), column);

		public static SqlPredicateExpr operator !=(int value, Int32ColumnDef<TModel> column)
			=> SqlExpr.NotEqual(SqlExpr.Parameter(value), column);


		public static SqlPredicateExpr operator ==(Int32ColumnDef<TModel> column, int? value)
			=> value == null
				? SqlExpr.IsNull(column) as SqlPredicateExpr
				: SqlExpr.Equal(column, SqlExpr.Parameter(value.Value));

		public static SqlPredicateExpr operator !=(Int32ColumnDef<TModel> column, int? value)
			=> value == null
				? SqlExpr.IsNotNull(column) as SqlPredicateExpr
				: SqlExpr.NotEqual(column, SqlExpr.Parameter(value.Value));


		public static SqlPredicateExpr operator ==(int? value, Int32ColumnDef<TModel> column)
			=> value == null
				? SqlExpr.IsNull(column) as SqlPredicateExpr
				: SqlExpr.Equal(SqlExpr.Parameter(value.Value), column);

		public static SqlPredicateExpr operator !=(int? value, Int32ColumnDef<TModel> column)
			=> value == null
				? SqlExpr.IsNotNull(column) as SqlPredicateExpr
				: SqlExpr.NotEqual(column, SqlExpr.Parameter(value.Value));


		public static SqlPredicateExpr operator >(Int32ColumnDef<TModel> column, int value)
			=> SqlExpr.GreaterThan(column, SqlExpr.Parameter(value));

		public static SqlPredicateExpr operator <(Int32ColumnDef<TModel> column, int value)
			=> SqlExpr.LessThan(column, SqlExpr.Parameter(value));


		public static SqlPredicateExpr operator >(int value, Int32ColumnDef<TModel> column)
			=> SqlExpr.GreaterThan(SqlExpr.Parameter(value), column);

		public static SqlPredicateExpr operator <(int value, Int32ColumnDef<TModel> column)
			=> SqlExpr.LessThan(SqlExpr.Parameter(value), column);


		public static SqlPredicateExpr operator >=(Int32ColumnDef<TModel> column, int value)
			=> SqlExpr.GreaterThanOrEqual(column, SqlExpr.Parameter(value));

		public static SqlPredicateExpr operator <=(Int32ColumnDef<TModel> column, int value)
			=> SqlExpr.LessThanOrEqual(column, SqlExpr.Parameter(value));


		public static SqlPredicateExpr operator >=(int value, Int32ColumnDef<TModel> column)
			=> SqlExpr.GreaterThanOrEqual(SqlExpr.Parameter(value), column);

		public static SqlPredicateExpr operator <=(int value, Int32ColumnDef<TModel> column)
			=> SqlExpr.LessThanOrEqual(SqlExpr.Parameter(value), column);


		public override bool Equals(object obj)
			=> object.ReferenceEquals(this, obj);

		public override int GetHashCode()
			=> base.GetHashCode();


		#endregion


		#region [ SqlExpr Operator ]


		public SqlInExpr In(params int[] values)
			=> SqlExpr.In(this, Check.NotNull(values, nameof(values)).Cast<object>().Select(SqlExpr.Constant));

		public SqlNotExpr NotIn(params int[] values)
			=> SqlExpr.NotIn(this, Check.NotNull(values, nameof(values)).Cast<object>().Select(SqlExpr.Constant));


		public SqlInExpr In(IEnumerable<int> values)
			=> SqlExpr.In(this, Check.NotNull(values, nameof(values)).Cast<object>().Select(SqlExpr.Constant));

		public SqlNotExpr NotIn(IEnumerable<int> values)
			=> SqlExpr.NotIn(this, Check.NotNull(values, nameof(values)).Cast<object>().Select(SqlExpr.Constant));


		public SqlBetweenExpr Between(int begin, int end)
			=> SqlExpr.Between(this, SqlExpr.Parameter(begin), SqlExpr.Parameter(end));

		public SqlNotExpr NotBetween(int begin, int end)
			=> SqlExpr.NotBetween(this, SqlExpr.Parameter(begin), SqlExpr.Parameter(end));


		#endregion

	}

}
