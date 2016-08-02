using System;
using System.Linq.Expressions;

namespace QueryFramework.Relational.DBStruct
{

	public class DateTimeOffsetColumnDef<TModel> : ColumnDef<TModel>
	{

		#region [ Constructors ]


		public DateTimeOffsetColumnDef(Expression<Func<TModel, DateTimeOffset>> expression)
		{
			ResolveColumnInfo(expression);
		}


		public DateTimeOffsetColumnDef(Expression<Func<TModel, DateTimeOffset?>> expression)
		{
			ResolveColumnInfo(expression);
		}


		#endregion

	}

}
