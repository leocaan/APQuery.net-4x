using System;
using System.Linq.Expressions;

namespace QueryFramework.Relational.DBStruct
{

	public class SingleColumnDef<TModel> : ColumnDef<TModel>
	{

		#region [ Constructors ]


		public SingleColumnDef(Expression<Func<TModel, float>> expression)
		{
			ResolveColumnInfo(expression);
		}


		public SingleColumnDef(Expression<Func<TModel, float?>> expression)
		{
			ResolveColumnInfo(expression);
		}


		#endregion

	}

}
