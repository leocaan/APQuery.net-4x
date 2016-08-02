using System;
using System.Linq.Expressions;

namespace QueryFramework.Relational.DBStruct
{

	public class Int64ColumnDef<TModel> : NumericTypeColumnDef<TModel>
	{

		#region [ Constructors ]


		public Int64ColumnDef(Expression<Func<TModel, long>> expression)
		{
			ResolveColumnInfo(expression);
		}


		public Int64ColumnDef(Expression<Func<TModel, long?>> expression)
		{
			ResolveColumnInfo(expression);
		}


		public Int64ColumnDef(Expression<Func<TModel, ulong>> expression)
		{
			ResolveColumnInfo(expression);
		}


		public Int64ColumnDef(Expression<Func<TModel, ulong?>> expression)
		{
			ResolveColumnInfo(expression);
		}


		#endregion

	}

}
