using System;
using System.Linq.Expressions;

namespace Symber.Data.DBStruct
{

	public class DateTimeColumnDef<TModel> : ColumnDef<TModel>
	{

		#region [ Constructors ]


		public DateTimeColumnDef(Expression<Func<TModel, DateTime>> expression)
		{
			ResolveColumnInfo(expression);
		}


		public DateTimeColumnDef(Expression<Func<TModel, DateTime?>> expression)
		{
			ResolveColumnInfo(expression);
		}


		#endregion

	}

}
