using System;
using System.Linq.Expressions;

namespace QueryFramework.Relational.DBStruct
{

	public class TimeSpanColumnDef<TModel> : ColumnDef<TModel>
	{
		
		#region [ Constructors ]


		public TimeSpanColumnDef(Expression<Func<TModel, TimeSpan>> expression)
		{
			ResolveColumnInfo(expression);
		}


		public TimeSpanColumnDef(Expression<Func<TModel, TimeSpan?>> expression)
		{
			ResolveColumnInfo(expression);
		}


		#endregion
		
	}

}
