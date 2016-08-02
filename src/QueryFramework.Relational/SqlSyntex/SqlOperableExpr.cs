using System;
using System.Collections.Generic;

namespace QueryFramework.Relational.SqlSyntex
{

	public abstract class SqlOperableExpr : SqlExpr
	{

		#region [ 'AS' ]


		public SqlAliasExpr As( string alias)
			=> SqlExpr.As(this, alias);


		#endregion


		#region [ 'Ordering' ]


		public new SqlOrderingExpr Asc
			=> SqlExpr.Asc(this);


		public new SqlOrderingExpr Desc
			=> SqlExpr.Desc(this);


		#endregion


		#region [ Predicate Methods ]


		public SqlInExpr In(params SqlOperableExpr[] exprs)
			=> SqlExpr.In(this, exprs);

		public SqlNotExpr NotIn(params SqlOperableExpr[] exprs)
			=> SqlExpr.NotIn(this, exprs);


		public SqlInExpr In(IEnumerable<SqlOperableExpr> exprs)
			=> SqlExpr.In(this, exprs);

		public SqlNotExpr NotIn(IEnumerable<SqlOperableExpr> exprs)
			=> SqlExpr.NotIn(this, exprs);


		public SqlBetweenExpr Between(SqlOperableExpr begin, SqlOperableExpr end)
			=> SqlExpr.Between(this, begin, end);

		public SqlNotExpr NotBetween(SqlOperableExpr begin, SqlOperableExpr end)
			=> SqlExpr.NotBetween(this, begin, end);


		public SqlLikeExpr Like(SqlOperableExpr pattern)
			=> SqlExpr.Like(this, pattern);

		public SqlNotExpr NotLike(SqlOperableExpr pattern)
			=> SqlExpr.NotLike(this, pattern);


		public SqlInSubQueryExpr In(SqlSelectExpr subQuery)
			=> SqlExpr.In(this, subQuery);

		public SqlNotExpr NotIn(SqlSelectExpr subQuery)
			=> SqlExpr.NotIn(this, subQuery);


		#endregion


		#region [ Override Implementation of Implicit Operator ]


		public static implicit operator SqlOperableExpr(bool value)
			=> SqlExpr.Constant(value);


		public static implicit operator SqlOperableExpr(short value)
			=> SqlExpr.Constant(value);


		public static implicit operator SqlOperableExpr(int value)
			=> SqlExpr.Constant(value);


		public static implicit operator SqlOperableExpr(long value)
			=> SqlExpr.Constant(value);


		public static implicit operator SqlOperableExpr(ushort value)
			=> SqlExpr.Constant(value);


		public static implicit operator SqlOperableExpr(uint value)
			=> SqlExpr.Constant(value);


		public static implicit operator SqlOperableExpr(ulong value)
			=> SqlExpr.Constant(value);


		public static implicit operator SqlOperableExpr(byte value)
			=> SqlExpr.Constant(value);


		public static implicit operator SqlOperableExpr(sbyte value)
			=> SqlExpr.Constant(value);


		public static implicit operator SqlOperableExpr(char value)
			=> SqlExpr.Constant(value);


		public static implicit operator SqlOperableExpr(string value)
			=> SqlExpr.Constant(value);


		public static implicit operator SqlOperableExpr(byte[] value)
			=> SqlExpr.Constant(value);


		public static implicit operator SqlOperableExpr(decimal value)
			=> SqlExpr.Constant(value);


		public static implicit operator SqlOperableExpr(double value)
			=> SqlExpr.Constant(value);


		public static implicit operator SqlOperableExpr(float value)
			=> SqlExpr.Constant(value);


		public static implicit operator SqlOperableExpr(Guid value)
			=> SqlExpr.Constant(value);


		public static implicit operator SqlOperableExpr(DateTime value)
			=> SqlExpr.Constant(value);


		public static implicit operator SqlOperableExpr(DateTimeOffset value)
			=> SqlExpr.Constant(value);


		public static implicit operator SqlOperableExpr(TimeSpan value)
			=> SqlExpr.Constant(value);


		#endregion


		#region [ Override Implementation of Operator ]


		public static SqlPredicateExpr operator ==(SqlOperableExpr left, SqlOperableExpr right)
			=> SqlExpr.Equal(left, right);

		public static SqlPredicateExpr operator !=(SqlOperableExpr left, SqlOperableExpr right)
			=> SqlExpr.NotEqual(left, right);


		public static SqlPredicateExpr operator >(SqlOperableExpr left, SqlOperableExpr right)
			=> SqlExpr.GreaterThan(left, right);

		public static SqlPredicateExpr operator <(SqlOperableExpr left, SqlOperableExpr right)
			=> SqlExpr.LessThan(left, right);


		public static SqlPredicateExpr operator >=(SqlOperableExpr left, SqlOperableExpr right)
			=> SqlExpr.GreaterThanOrEqual(left, right);

		public static SqlPredicateExpr operator <=(SqlOperableExpr left, SqlOperableExpr right)
			=> SqlExpr.LessThanOrEqual(left, right);


		public static SqlPredicateExpr operator ==(SqlOperableExpr left, SqlScalarSubQueryExpr right)
			=> SqlExpr.Equal(left, right);

		public static SqlPredicateExpr operator !=(SqlOperableExpr left, SqlScalarSubQueryExpr right)
			=> SqlExpr.NotEqual(left, right);


		public static SqlPredicateExpr operator >(SqlOperableExpr left, SqlScalarSubQueryExpr right)
			=> SqlExpr.GreaterThan(left, right);

		public static SqlPredicateExpr operator <(SqlOperableExpr left, SqlScalarSubQueryExpr right)
			=> SqlExpr.LessThan(left, right);


		public static SqlPredicateExpr operator >=(SqlOperableExpr left, SqlScalarSubQueryExpr right)
			=> SqlExpr.GreaterThanOrEqual(left, right);

		public static SqlPredicateExpr operator <=(SqlOperableExpr left, SqlScalarSubQueryExpr right)
			=> SqlExpr.LessThanOrEqual(left, right);


		public override bool Equals(object obj)
			=> object.ReferenceEquals(this, obj);

		public override int GetHashCode()
			=> base.GetHashCode();


		#endregion

	}

}
