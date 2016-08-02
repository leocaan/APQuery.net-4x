using System;
using System.Linq.Expressions;

namespace QueryFramework.Relational.DBStruct
{

	public class BytesColumnDef<TModel> : ColumnDef<TModel>
	{

		#region [ Constructors ]


		public BytesColumnDef(Expression<Func<TModel, Byte[]>> expression)
		{
			ResolveColumnInfo(expression);
		}


		#endregion

	}

}
