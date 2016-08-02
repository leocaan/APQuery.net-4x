using System;
using System.Linq.Expressions;

namespace QueryFramework.Relational.DBStruct
{

	public class BooleanColumnDef<TModel> : ColumnDef<TModel>
	{

		#region [ Constructors ]


		public BooleanColumnDef(Expression<Func<TModel, Boolean>> expression)
		{
			ResolveColumnInfo(expression);
		}


		public BooleanColumnDef(Expression<Func<TModel, Boolean?>> expression)
		{
			ResolveColumnInfo(expression);
		}


		#endregion

	}

}
