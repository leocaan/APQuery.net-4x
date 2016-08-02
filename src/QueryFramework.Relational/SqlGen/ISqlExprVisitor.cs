using QueryFramework.Relational.SqlSyntex;

namespace QueryFramework.Relational.SqlGen
{

	public interface ISqlExprVisitor
	{

		SqlExpr VisitSelect(SqlSelectExpr selectExpr);

		SqlExpr VisitTable(SqlTableExpr tableExpr);
		SqlExpr VisitInnerJoin(SqlInnerJoinExpr innerJoinExpr);
		SqlExpr VisitLeftOuterJoin(SqlLeftOuterJoinExpr leftOuterJoinExpr);
		SqlExpr VisitRightOuterJoin(SqlRightOuterJoinExpr rightOuterJoinExpr);
		SqlExpr VisitFullOuterJoin(SqlFullOuterJoinExpr fullOuterJoinExpr);
		SqlExpr VisitCrossJoin(SqlCrossJoinExpr crossJoinExpr);

		SqlExpr VisitStar(SqlProjectStarExpr starExpr);
		SqlExpr VisitColumn(SqlColumnExpr columnExpr);
		SqlExpr VisitAlias(SqlAliasExpr aliasExpr);
		SqlExpr VisitConstant(SqlConstantExpr constantExpr);
		SqlExpr VisitLiteral(SqlLiteralExpr literalExpr);
		SqlExpr VisitRawSql(SqlRawSqlExpr rawSqlExpr);

		SqlExpr VisitParameter(SqlParameterExpr parameterExpr);

		SqlExpr VisitNot(SqlNotExpr notExpr);
		SqlExpr VisitAnd(SqlAndExpr notExpr);
		SqlExpr VisitOr(SqlOrExpr notExpr);

		SqlExpr VisitIsNull(SqlIsNullExpr isNullExpr);
		SqlExpr VisitIsNotNull(SqlIsNullExpr isNullExpr);
		SqlExpr VisitComparison(SqlComparisonExpr comparisonExpr);
		SqlExpr VisitIn(SqlInExpr inExpr);
		SqlExpr VisitNotIn(SqlInExpr inExpr);
		SqlExpr VisitBetween(SqlBetweenExpr betweenExpr);
		SqlExpr VisitNotBetween(SqlBetweenExpr betweenExpr);
		SqlExpr VisitLike(SqlLikeExpr likeExpr);
		SqlExpr VisitNotLike(SqlLikeExpr likeExpr);
		SqlExpr VisitExists(SqlExistsExpr existsExpr);
		SqlExpr VisitNotExists(SqlExistsExpr existsExpr);
		SqlExpr VisitInSubQuery(SqlInSubQueryExpr inSubQueryExpr);
		SqlExpr VisitNotInSubQuery(SqlInSubQueryExpr inSubQueryExpr);
		SqlExpr VisitComparisonSubQuery(SqlComparisonSubQueryExpr comparisonSubQueryExpr);
		SqlExpr VisitScalarSubQuery(SqlScalarSubQueryExpr scalarSubQueryExpr);
		SqlExpr VisitAny(SqlAnyExpr anyExpr);
		SqlExpr VisitAll(SqlAllExpr allExpr);

		SqlExpr VisitOrdering(SqlOrderingExpr orderingExpr);

		SqlExpr VisitCombineResult(SqlCombineResultExprBase combineResultExpr);

		SqlExpr VisitGroupingSets(SqlMultipleGroupingSetsExprBase groupingSetsExpr);

		SqlExpr VisitOver(SqlOverExpr overExpr);
		SqlExpr VisitSqlFunction(SqlFunctionExprBase functionExpr);
		SqlExpr VisitSqlDistinctableFunction(SqlDistinctableFunctionExpr functionExpr);
		SqlExpr VisitCount(SqlCountExpr countExpr);

	}

}
