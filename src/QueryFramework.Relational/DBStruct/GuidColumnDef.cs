using System;
using System.Linq.Expressions;

namespace QueryFramework.Relational.DBStruct
{

	public class GuidColumnDef<TModel> : IdentifiableColumnDef<TModel>
	{

		#region [ Constructors ]


		public GuidColumnDef(Expression<Func<TModel, Guid>> expression)
		{
			ResolveColumnInfo(expression);
		}


		public GuidColumnDef(Expression<Func<TModel, Guid?>> expression)
		{
			ResolveColumnInfo(expression);
		}


		#endregion

	}

}
