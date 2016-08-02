using QueryFramework.Relational.SqlSyntex;

namespace QueryFramework.Relational.DBStruct
{

	public abstract class NumericTypeColumnDef<TModel> : IdentifiableColumnDef<TModel>
	{

		#region [ SqlExpr Operator ]


		public SqlAvgExpr Avg()
			=> SqlExpr.Avg(this);


		public SqlSumExpr Sum()
			=> SqlExpr.Sum(this);


		public SqlMaxExpr Max()
			=> SqlExpr.Max(this);


		public SqlMinExpr Min()
			=> SqlExpr.Min(this);


		public SqlCountExpr Count()
			=> SqlExpr.Count(this);


		#endregion

	}

}
