﻿using System;
using System.Linq.Expressions;

namespace Symber.Data.DBStruct
{

	public class DecimalColumnDef<TModel> : NumericTypeColumnDef<TModel>
	{

		#region [ Constructors ]


		public DecimalColumnDef(Expression<Func<TModel, Decimal>> expression)
		{
			ResolveColumnInfo(expression);
		}


		public DecimalColumnDef(Expression<Func<TModel, Decimal?>> expression)
		{
			ResolveColumnInfo(expression);
		}


		#endregion

	}

}
