using System;
using System.Linq.Expressions;

namespace Symber.Data.DBStruct
{

	public class SByteColumnDef<TModel> : NumericTypeColumnDef<TModel>
	{
		
		#region [ Constructors ]


		public SByteColumnDef(Expression<Func<TModel, sbyte>> expression)
		{
			ResolveColumnInfo(expression);
		}


		public SByteColumnDef(Expression<Func<TModel, sbyte?>> expression)
		{
			ResolveColumnInfo(expression);
		}


		public SByteColumnDef(Expression<Func<TModel, byte>> expression)
		{
			ResolveColumnInfo(expression);
		}


		public SByteColumnDef(Expression<Func<TModel, byte?>> expression)
		{
			ResolveColumnInfo(expression);
		}


		#endregion

	}

}
