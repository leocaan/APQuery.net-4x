// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.SqlSyntex;

namespace QueryFramework.Query.Sql
{

   public interface ISqlExprVisitor
   {

      #region [ Methods ]


      SqlExpr VisitSelect(SqlSelectExpr selectExpr);

      SqlExpr VisitTable(SqlTableExpr tableExpr);
      SqlExpr VisitInnerJoin(SqlInnerJoinExpr innerJoinExpr);
      SqlExpr VisitLeftOuterJoin(SqlLeftOuterJoinExpr leftOuterJoinExpr);
      SqlExpr VisitRightOuterJoin(SqlRightOuterJoinExpr rightOuterJoinExpr);
      SqlExpr VisitFullOuterJoin(SqlFullOuterJoinExpr fullOuterJoinExpr);
      SqlExpr VisitCrossJoin(SqlCrossJoinExpr crossJoinExpr);
      SqlExpr VisitLateralJoin(SqlLateralJoinExpr lateralJoinExpr);

      SqlExpr VisitProjectStar(SqlProjectStarExpr starExpr);
      SqlExpr VisitColumn(SqlColumnExpr columnExpr);
      SqlExpr VisitAlias(SqlAliasExpr aliasExpr);
      SqlExpr VisitConstant(SqlConstantExpr constantExpr);
      SqlExpr VisitRawSql(SqlRawSqlExpr rawSqlExpr);
      SqlExpr VisitBinary(SqlBinaryExpr binaryExpr);

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
      SqlExpr VisitAliasReference(SqlAliasReferenceExpr aliasReferenceExpr);

      SqlExpr VisitCombineResult(SqlCombineResultExprBase combineResultExpr);

      SqlExpr VisitGroupingSets(SqlMultipleGroupingSetsExprBase groupingSetsExpr);

      SqlExpr VisitOver(SqlOverExpr overExpr);
      SqlExpr VisitSqlFunction(SqlFunctionExprBase functionExpr);
      SqlExpr VisitSqlDistinctableFunction(SqlDistinctableFunctionExpr functionExpr);
      SqlExpr VisitCount(SqlCountExpr countExpr);
      SqlExpr VisitExplicitCast(SqlExplicitCastExpr explicitCastExpr);


      #endregion

   }

}
