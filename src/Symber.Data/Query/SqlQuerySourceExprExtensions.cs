using Symber.Data.SqlSyntex;

namespace Symber.Data.Query
{

	public static class SqlQuerySourceExprExtensions
	{

		public static SqlInnerJoinExpr InnerJoin(this SqlQuerySourceExpr source, SqlPredicateExpr predicate)
			=> SqlExpr.InnerJoin(source, predicate );


		public static SqlLeftOuterJoinExpr LeftJoin(this SqlQuerySourceExpr source, SqlPredicateExpr predicate)
			=> SqlExpr.LeftJoin(source, predicate );


		public static SqlRightOuterJoinExpr RightJoin(this SqlQuerySourceExpr source, SqlPredicateExpr predicate)
			=> SqlExpr.RightJoin(source, predicate);


		public static SqlFullOuterJoinExpr FullJoin(this SqlQuerySourceExpr source, SqlPredicateExpr predicate)
			=> SqlExpr.FullJoin(source, predicate);


		public static SqlCrossJoinExpr CrossJoin(this SqlQuerySourceExpr source)
			=> SqlExpr.CrossJoin(source);

	}

}
