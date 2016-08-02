using System;
using System.Linq.Expressions;

namespace QueryFramework.Relational.DBStruct
{

	public class Int16ColumnDef<TModel> : NumericTypeColumnDef<TModel>
	{

		#region [ Constructors ]


		public Int16ColumnDef(Expression<Func<TModel, short>> expression)
		{
			ResolveColumnInfo(expression);
		}


		public Int16ColumnDef(Expression<Func<TModel, short?>> expression)
		{
			ResolveColumnInfo(expression);
		}


		public Int16ColumnDef(Expression<Func<TModel, ushort>> expression)
		{
			ResolveColumnInfo(expression);
		}


		public Int16ColumnDef(Expression<Func<TModel, ushort?>> expression)
		{
			ResolveColumnInfo(expression);
		}


		#endregion

	}

}
