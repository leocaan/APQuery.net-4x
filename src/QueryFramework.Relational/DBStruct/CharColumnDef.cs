using System;
using System.Linq.Expressions;

namespace QueryFramework.Relational.DBStruct
{

	public class CharColumnDef<TModel> : ColumnDef<TModel>
	{

		#region [ Constructors ]


		public CharColumnDef(Expression<Func<TModel, Char>> expression)
		{
			ResolveColumnInfo(expression);
		}


		public CharColumnDef(Expression<Func<TModel, Char?>> expression)
		{
			ResolveColumnInfo(expression);
		}


		#endregion

	}

}
