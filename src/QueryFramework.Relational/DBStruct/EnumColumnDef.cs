using System;
using System.Linq.Expressions;

namespace QueryFramework.Relational.DBStruct
{

	public class EnumColumnDef<TModel, TEnum> : ColumnDef<TModel>
	{

		#region [ Constructors ]


		public EnumColumnDef(Expression<Func<TModel, TEnum>> expression)
		{
			ResolveColumnInfo(expression);
		}


		#endregion

	}

}
