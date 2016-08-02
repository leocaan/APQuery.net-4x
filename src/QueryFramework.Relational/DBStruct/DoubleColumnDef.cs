using System;
using System.Linq.Expressions;

namespace QueryFramework.Relational.DBStruct
{

	public class DoubleColumnDef<TModel> : ColumnDef<TModel>
	{

		#region [ Constructors ]


		public DoubleColumnDef(Expression<Func<TModel, double>> expression)
		{
			ResolveColumnInfo(expression);
		}


		public DoubleColumnDef(Expression<Func<TModel, double?>> expression)
		{
			ResolveColumnInfo(expression);
		}


		#endregion

	}

}
