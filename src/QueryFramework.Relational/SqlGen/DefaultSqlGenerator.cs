using QueryFramework.Relational.SqlSyntex;
using QueryFramework.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace QueryFramework.Relational.SqlGen
{

	public class DefaultSqlGenerator : ISqlExprVisitor
	{

		#region [ Fields ]


		private IndentedStringBuilder _sql;
		private Dictionary<string, SqlParameterExpr> _sqlParameters;
		private SqlParameterNameGenerator _parameterNameGenerator;
		private SqlTableAliasGenerator _tableAliasGenerator;


		#endregion


		#region [ Constructors ]


		public DefaultSqlGenerator()
		{
			_sql = new IndentedStringBuilder();
			_sqlParameters = new Dictionary<string, SqlParameterExpr>();
			_parameterNameGenerator = new SqlParameterNameGenerator();
			_tableAliasGenerator = new SqlTableAliasGenerator();
		}


		#endregion


		#region [ Properties ]


		public virtual IndentedStringBuilder Sql
			=> _sql;


		public virtual IReadOnlyDictionary<string, SqlParameterExpr> Parameters
			=> _sqlParameters;


		public virtual string SqlString
			=> _sql.ToString();


		#endregion


		#region [ Methods ]


		public virtual DefaultSqlGenerator GenerateSelect(SqlSelectExpr selectExpr)
		{
			Check.NotNull(selectExpr, nameof(selectExpr));

			Visit(selectExpr);

			return this;
		}


		public virtual DefaultSqlGenerator GenerateInsert(SqlInsertCommand insertCommand)
		{
			Check.NotNull(insertCommand, nameof(insertCommand));
			return this;
		}


		public virtual DefaultSqlGenerator GenerateUpdate(SqlUpdateCommand updateCommand)
		{
			Check.NotNull(updateCommand, nameof(updateCommand));
			return this;
		}


		public virtual DefaultSqlGenerator GenerateDelete(SqlDeleteCommand deleteCommand)
		{
			Check.NotNull(deleteCommand, nameof(deleteCommand));
			return this;
		}


		#endregion


		#region [ Protected Properties ]


		public virtual string ParameterPrefix => "@";


		protected virtual string TrueLiteral => "1";


		protected virtual string FalseLiteral => "0";


		protected virtual SqlParameterNameGenerator ParameterNameGenerator
			=> _parameterNameGenerator;


		#endregion


		#region [ Protected Methods ]


		protected SqlExpr Visit(SqlExpr expr)
			=> expr.Accept(this);


		protected virtual IReadOnlyList<SqlOperableExpr> ProcessInExprValues(IReadOnlyList<SqlOperableExpr> inExprValues)
		{
			var inConstants = new List<SqlOperableExpr>();

			foreach (var expr in inExprValues)
			{
				var constantExpr = expr as SqlConstantExpr;
				if (!object.ReferenceEquals(constantExpr, null))
				{
					inConstants.Add(constantExpr);
					continue;
				}

				var parameterExpr = expr as SqlParameterExpr;
				if (!object.ReferenceEquals(parameterExpr, null))
				{
					var parameterValue = parameterExpr.Value;
					var valuesCollection = parameterValue as IEnumerable;

					if (valuesCollection != null
						 && parameterValue.GetType() != typeof(string)
						 && parameterValue.GetType() != typeof(byte[]))
					{
						inConstants.AddRange(valuesCollection.Cast<object>().Select(SqlExpr.Constant));
					}
					else
					{
						inConstants.Add(parameterExpr);
					}
				}
			}

			return inConstants;
		}


		protected virtual IReadOnlyList<SqlOperableExpr> ExtractNonNullExprValues(IReadOnlyList<SqlOperableExpr> inExprValues)
		{
			var inValuesNotNull = new List<SqlOperableExpr>();

			foreach (var expr in inExprValues)
			{
				var constantExpr = expr as SqlConstantExpr;
				if (constantExpr?.Value != null)
				{
					inValuesNotNull.Add(expr);
					continue;
				}

				var parameterExpr = expr as SqlParameterExpr;
				if (parameterExpr?.Value != null)
				{
					inValuesNotNull.Add(expr);
				}
			}

			return inValuesNotNull;
		}


		protected virtual string GetTableAlias(SqlQuerySourceExpr table)
			=> _tableAliasGenerator.GetAlias(table);


		protected virtual void GenerateTop(SqlSelectExpr selectExpr)
		{
			Check.NotNull(selectExpr, nameof(selectExpr));


			if (selectExpr.Limit != null && selectExpr.Offset == null)
			{
				_sql.Append("TOP(")
					 .Append(selectExpr.Limit)
					 .Append(") ");
			}
		}


		protected virtual void GenerateLimitOffset(SqlSelectExpr selectExpr)
		{
			Check.NotNull(selectExpr, nameof(selectExpr));


			if (selectExpr.Offset != null)
			{
				_sql.AppendLine()
					 .Append("OFFSET ")
					 .Append(selectExpr.Offset)
					 .Append(" ROWS");

				if (selectExpr.Limit != null)
				{
					_sql.Append(" FETCH NEXT ")
						 .Append(selectExpr.Limit)
						 .Append(" ROWS ONLY");
				}
			}
		}


		// TODO: Share the code below (#1559)


		protected virtual string DelimitIdentifier(string identifier)
			 => "\"" + Check.NotEmpty(identifier, nameof(identifier)) + "\"";


		protected virtual string EscapeLiteral(string literal)
			 => Check.NotNull(literal, nameof(literal)).Replace("'", "''");


		private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffK";
		private const string DateTimeOffsetFormat = "yyyy-MM-ddTHH:mm:ss.fffzzz";
		private const string FloatingPointFormat = "{0}E0";


		protected virtual string GenerateLiteral(object value)
			 => string.Format(CultureInfo.InvariantCulture, "{0}", value);


		protected virtual string GenerateLiteral(bool value)
			 => value ? TrueLiteral : FalseLiteral;


		protected virtual string GenerateLiteral(short value)
			 => value.ToString();


		protected virtual string GenerateLiteral(int value)
			 => value.ToString();


		protected virtual string GenerateLiteral(long value)
			 => value.ToString();


		protected virtual string GenerateLiteral(ushort value)
			 => value.ToString();


		protected virtual string GenerateLiteral(uint value)
			=> value.ToString();


		protected virtual string GenerateLiteral(ulong value)
			 => value.ToString();


		protected virtual string GenerateLiteral(byte value)
			 => value.ToString();


		protected virtual string GenerateLiteral(sbyte value)
			 => value.ToString();


		protected virtual string GenerateLiteral(char value)
			 => value.ToString();


		protected virtual string GenerateLiteral(string value)
			 => "'" + EscapeLiteral(Check.NotNull(value, nameof(value))) + "'";


		protected virtual string GenerateLiteral(byte[] value)
		{
			var stringBuilder = new StringBuilder("0x");

			foreach (var @byte in value)
			{
				stringBuilder.Append(@byte.ToString("X2", CultureInfo.InvariantCulture));
			}

			return stringBuilder.ToString();
		}


		protected virtual string GenerateLiteral(decimal value)
			 => string.Format(value.ToString(CultureInfo.InvariantCulture));


		protected virtual string GenerateLiteral(double value)
			 => string.Format(CultureInfo.InvariantCulture, FloatingPointFormat, value);


		protected virtual string GenerateLiteral(float value)
			 => string.Format(CultureInfo.InvariantCulture, FloatingPointFormat, value);


		protected virtual string GenerateLiteral(Guid value)
			 => "'" + value + "'";


		protected virtual string GenerateLiteral(DateTime value)
			 => "'" + value.ToString(DateTimeFormat, CultureInfo.InvariantCulture) + "'";


		protected virtual string GenerateLiteral(DateTimeOffset value)
			 => "'" + value.ToString(DateTimeOffsetFormat, CultureInfo.InvariantCulture) + "'";


		protected virtual string GenerateLiteral(TimeSpan value)
			 => "'" + value + "'";


		#endregion


		#region [ Visits ]


		public virtual SqlExpr VisitSelect(SqlSelectExpr selectExpr)
		{
			Check.NotNull(selectExpr, nameof(selectExpr));


			IDisposable subQueryIndent = null;

			if (selectExpr.Alias != null)
			{
				_sql.AppendLine("(");

				subQueryIndent = _sql.Indent();
			}


			// SELECT <select_list>

			_sql.Append("SELECT ");

			if (selectExpr.IsDistinct)
			{
				_sql.Append("DISTINCT ");
			}

			GenerateTop(selectExpr);

			if (selectExpr.SelectClause.Any())
			{
				VisitJoin(selectExpr.SelectClause);
			}


			// [ FROM { <table_source> } [ ,...n ] ]

			if (selectExpr.FromClause.Any())
			{
				_sql.AppendLine()
					 .Append("FROM ");

				VisitJoin(selectExpr.FromClause, sql => sql.AppendLine());
			}


			// [ WHERE <search_condition> ]

			if (selectExpr.WhereClause != null)
			{
				_sql.AppendLine()
					 .Append("WHERE ");

				Visit(selectExpr.WhereClause);
			}


			// [ GROUP BY <group by spec> ]

			if (selectExpr.GroupByClause.Any())
			{
				_sql.AppendLine()
					 .Append("GROUP BY ");

				VisitJoin(selectExpr.GroupByClause);
			}


			// [ HAVING <search_condition> ]

			if (selectExpr.HavingClause != null)
			{
				_sql.AppendLine()
					 .Append("HAVING ");

				Visit(selectExpr.HavingClause);
			}


			// [ ORDER BY { order_by_expression [ASC | DESC] } [ ,...n] ]

			if (selectExpr.OrderByClause.Any())
			{
				_sql.AppendLine()
					 .Append("ORDER BY ");

				VisitJoin(selectExpr.OrderByClause);
			}

			GenerateLimitOffset(selectExpr);

			if (subQueryIndent != null)
			{
				subQueryIndent.Dispose();

				_sql.AppendLine()
					 .Append(") AS ")
					 .Append(DelimitIdentifier(GetTableAlias(selectExpr)));
			}

			// [ UNION ... ]

			if (selectExpr.CombineResults.Any())
			{
				_sql.AppendLine();

				VisitJoin(selectExpr.CombineResults, sql => sql.AppendLine());
			}


			return selectExpr;
		}


		public virtual SqlExpr VisitTable(SqlTableExpr tableExpr)
		{
			Check.NotNull(tableExpr, nameof(tableExpr));


			if (tableExpr.Schema != null)
			{
				_sql.Append(DelimitIdentifier(tableExpr.Schema))
					 .Append(".");
			}

			_sql.Append(DelimitIdentifier(tableExpr.Name))
				 .Append(" AS ")
				 .Append(DelimitIdentifier(GetTableAlias(tableExpr)));


			return tableExpr;
		}


		public virtual SqlExpr VisitInnerJoin(SqlInnerJoinExpr innerJoinExpr)
		{
			Check.NotNull(innerJoinExpr, nameof(innerJoinExpr));


			_sql.Append("INNER JOIN ");

			Visit(innerJoinExpr.TableExpr);

			_sql.Append(" ON ");

			Visit(innerJoinExpr.Predicate);


			return innerJoinExpr;
		}


		public virtual SqlExpr VisitLeftOuterJoin(SqlLeftOuterJoinExpr leftOuterJoinExpr)
		{
			Check.NotNull(leftOuterJoinExpr, nameof(leftOuterJoinExpr));


			_sql.Append("LEFT JOIN ");

			Visit(leftOuterJoinExpr.TableExpr);

			_sql.Append(" ON ");

			Visit(leftOuterJoinExpr.Predicate);


			return leftOuterJoinExpr;
		}


		public virtual SqlExpr VisitRightOuterJoin(SqlRightOuterJoinExpr rightOuterJoinExpr)
		{
			Check.NotNull(rightOuterJoinExpr, nameof(rightOuterJoinExpr));


			_sql.Append("RIGHT JOIN ");

			Visit(rightOuterJoinExpr.TableExpr);

			_sql.Append(" ON ");

			Visit(rightOuterJoinExpr.Predicate);


			return rightOuterJoinExpr;
		}


		public virtual SqlExpr VisitFullOuterJoin(SqlFullOuterJoinExpr fullOuterJoinExpr)
		{
			Check.NotNull(fullOuterJoinExpr, nameof(fullOuterJoinExpr));


			_sql.Append("FULL JOIN ");

			Visit(fullOuterJoinExpr.TableExpr);

			_sql.Append(" ON ");

			Visit(fullOuterJoinExpr.Predicate);


			return fullOuterJoinExpr;
		}


		public virtual SqlExpr VisitCrossJoin(SqlCrossJoinExpr crossJoinExpr)
		{
			Check.NotNull(crossJoinExpr, nameof(crossJoinExpr));


			_sql.Append("CROSS JOIN ");

			Visit(crossJoinExpr.TableExpr);


			return crossJoinExpr;
		}


		public virtual SqlExpr VisitStar(SqlProjectStarExpr starExpr)
		{
			Check.NotNull(starExpr, nameof(starExpr));


			if (starExpr.Table != null)
			{
				_sql.Append(DelimitIdentifier(GetTableAlias(starExpr.Table)))
					 .Append(".");
			}
			_sql.Append("*");


			return starExpr;
		}


		public virtual SqlExpr VisitColumn(SqlColumnExpr columnExpr)
		{
			Check.NotNull(columnExpr, nameof(columnExpr));


			_sql.Append(DelimitIdentifier(GetTableAlias(columnExpr.Table)))
				 .Append(".")
				 .Append(DelimitIdentifier(columnExpr.Name));


			return columnExpr;
		}


		public virtual SqlExpr VisitAlias(SqlAliasExpr aliasExpr)
		{
			Check.NotNull(aliasExpr, nameof(aliasExpr));


			Visit(aliasExpr.Operand);
			_sql.Append(" AS ")
				 .Append(DelimitIdentifier(aliasExpr.Alias));


			return aliasExpr;
		}


		public virtual SqlExpr VisitConstant(SqlConstantExpr constantExpr)
		{
			Check.NotNull(constantExpr, nameof(constantExpr));


			_sql.Append(constantExpr.Value == null
				 ? "NULL"
				 : GenerateLiteral((dynamic)constantExpr.Value));


			return constantExpr;
		}


		public virtual SqlExpr VisitLiteral(SqlLiteralExpr literalExpr)
		{
			Check.NotNull(literalExpr, nameof(literalExpr));


			_sql.Append(GenerateLiteral(literalExpr.Literal));


			return literalExpr;
		}


		public virtual SqlExpr VisitRawSql(SqlRawSqlExpr rawSqlExpr)
		{
			Check.NotNull(rawSqlExpr, nameof(rawSqlExpr));


			_sql.Append(rawSqlExpr.Sql);


			return rawSqlExpr;
		}


		public virtual SqlExpr VisitParameter(SqlParameterExpr parameterExpr)
		{
			Check.NotNull(parameterExpr, nameof(parameterExpr));


			string parameterName = ParameterNameGenerator.GenerateNext(parameterExpr.Name);

			_sql.Append(ParameterPrefix + parameterName);

			_sqlParameters.Add(parameterName, parameterExpr);


			return parameterExpr;
		}


		public virtual SqlExpr VisitNot(SqlNotExpr notExpr)
		{
			Check.NotNull(notExpr, nameof(notExpr));


			var isNullExpr = notExpr.Operand as SqlIsNullExpr;
			if (isNullExpr != null)
			{
				return VisitIsNotNull(isNullExpr);
			}

			var inExpr = notExpr.Operand as SqlInExpr;
			if (inExpr != null)
			{
				return VisitNotIn(inExpr);
			}

			var betweenExpr = notExpr.Operand as SqlBetweenExpr;
			if (betweenExpr != null)
			{
				return VisitNotBetween(betweenExpr);
			}

			var likeExpr = notExpr.Operand as SqlLikeExpr;
			if (likeExpr != null)
			{
				return VisitNotLike(likeExpr);
			}

			var existsExpr = notExpr.Operand as SqlExistsExpr;
			if (existsExpr != null)
			{
				return VisitNotExists(existsExpr);
			}

			var inSubQueryExpr = notExpr.Operand as SqlInSubQueryExpr;
			if (inSubQueryExpr != null)
			{
				return VisitNotInSubQuery(inSubQueryExpr);
			}

			_sql.Append("NOT (");

			Visit(notExpr.Operand);

			_sql.Append(")");


			return notExpr;
		}


		public virtual SqlExpr VisitAnd(SqlAndExpr andExpr)
		{
			Check.NotNull(andExpr, nameof(andExpr));


			if (andExpr.Left is SqlOrExpr)
			{
				_sql.Append("(");
				Visit(andExpr.Left);
				_sql.Append(")");
			}
			else
			{
				Visit(andExpr.Left);
			}

			_sql.Append(" AND ");

			if (andExpr.Right is SqlOrExpr)
			{
				_sql.Append("(");
				Visit(andExpr.Right);
				_sql.Append(")");
			}
			else
			{
				Visit(andExpr.Right);
			}


			return andExpr;
		}


		public virtual SqlExpr VisitOr(SqlOrExpr orExpr)
		{
			Check.NotNull(orExpr, nameof(orExpr));


			if (orExpr.Left is SqlAndExpr)
			{
				_sql.Append("(");
				Visit(orExpr.Left);
				_sql.Append(")");
			}
			else
			{
				Visit(orExpr.Left);
			}

			_sql.Append(" OR ");

			if (orExpr.Right is SqlAndExpr)
			{
				_sql.Append("(");
				Visit(orExpr.Right);
				_sql.Append(")");
			}
			else
			{
				Visit(orExpr.Right);
			}


			return orExpr;
		}


		public virtual SqlExpr VisitIsNull(SqlIsNullExpr isNullExpr)
		{
			Check.NotNull(isNullExpr, nameof(isNullExpr));


			Visit(isNullExpr.Operand);

			_sql.Append(" IS NULL");


			return isNullExpr;
		}


		public virtual SqlExpr VisitIsNotNull(SqlIsNullExpr isNullExpr)
		{
			Check.NotNull(isNullExpr, nameof(isNullExpr));


			Visit(isNullExpr.Operand);

			_sql.Append(" IS NOT NULL");


			return isNullExpr;
		}


		public virtual SqlExpr VisitComparison(SqlComparisonExpr comparisonExpr)
		{
			Check.NotNull(comparisonExpr, nameof(comparisonExpr));


			Visit(comparisonExpr.Left);

			VisitComparisonOperator(comparisonExpr.Operator);

			Visit(comparisonExpr.Right);


			return comparisonExpr;
		}


		public virtual SqlExpr VisitIn(SqlInExpr inExpr)
		{
			Check.NotNull(inExpr, nameof(inExpr));


			var inValues = ProcessInExprValues(inExpr.Values);
			var inValuesNotNull = ExtractNonNullExprValues(inValues);

			if (inValues.Count != inValuesNotNull.Count)
			{
				var nullSemanticsInExpression = SqlExpr.OrElse(
					SqlExpr.In(inExpr.Operand, inValuesNotNull),
					SqlExpr.IsNull(inExpr.Operand)
					);

				return Visit(nullSemanticsInExpression);
			}

			if (inValuesNotNull.Count > 0)
			{
				Visit(inExpr.Operand);

				_sql.Append(" IN (");

				VisitJoin(inValuesNotNull);

				_sql.Append(")");
			}
			else
			{
				_sql.Append("1 = 0");
			}


			return inExpr;
		}


		public virtual SqlExpr VisitNotIn(SqlInExpr inExpr)
		{
			Check.NotNull(inExpr, nameof(inExpr));


			var inValues = ProcessInExprValues(inExpr.Values);
			var inValuesNotNull = ExtractNonNullExprValues(inValues);

			if (inValues.Count != inValuesNotNull.Count)
			{
				var nullSemanticsInExpression = SqlExpr.AndAlso(
					SqlExpr.NotIn(inExpr.Operand, inValuesNotNull),
					SqlExpr.IsNotNull(inExpr.Operand)
					);

				return Visit(nullSemanticsInExpression);
			}

			if (inValuesNotNull.Count > 0)
			{
				Visit(inExpr.Operand);

				_sql.Append(" NOT IN (");

				VisitJoin(inValuesNotNull);

				_sql.Append(")");
			}
			else
			{
				_sql.Append("1 = 1");
			}


			return inExpr;
		}


		public virtual SqlExpr VisitBetween(SqlBetweenExpr betweenExpr)
		{
			Check.NotNull(betweenExpr, nameof(betweenExpr));


			Visit(betweenExpr.Operand);

			_sql.Append(" BETWEEN ");

			Visit(betweenExpr.Begin);

			_sql.Append(" AND ");

			Visit(betweenExpr.End);


			return betweenExpr;
		}


		public virtual SqlExpr VisitNotBetween(SqlBetweenExpr betweenExpr)
		{
			Check.NotNull(betweenExpr, nameof(betweenExpr));


			Visit(betweenExpr.Operand);

			_sql.Append(" NOT BETWEEN ");

			Visit(betweenExpr.Begin);

			_sql.Append(" AND ");

			Visit(betweenExpr.End);


			return betweenExpr;
		}


		public virtual SqlExpr VisitLike(SqlLikeExpr likeExpr)
		{
			Check.NotNull(likeExpr, nameof(likeExpr));


			Visit(likeExpr.Match);

			_sql.Append(" LIKE ");

			Visit(likeExpr.Pattern);


			return likeExpr;
		}


		public virtual SqlExpr VisitNotLike(SqlLikeExpr likeExpr)
		{
			Check.NotNull(likeExpr, nameof(likeExpr));


			Visit(likeExpr.Match);

			_sql.Append(" NOT LIKE ");

			Visit(likeExpr.Pattern);


			return likeExpr;
		}


		public virtual SqlExpr VisitExists(SqlExistsExpr existsExpr)
		{
			Check.NotNull(existsExpr, nameof(existsExpr));


			_sql.AppendLine("EXISTS (");

			using (_sql.Indent())
			{
				Visit(existsExpr.SubQuery);
			}

			_sql.AppendLine(")");


			return existsExpr;
		}


		public virtual SqlExpr VisitNotExists(SqlExistsExpr existsExpr)
		{
			Check.NotNull(existsExpr, nameof(existsExpr));


			_sql.AppendLine("NOT EXISTS (");

			using (_sql.Indent())
			{
				Visit(existsExpr.SubQuery);
			}

			_sql.AppendLine(")");


			return existsExpr;
		}


		public virtual SqlExpr VisitInSubQuery(SqlInSubQueryExpr inSubQueryExpr)
		{
			Check.NotNull(inSubQueryExpr, nameof(inSubQueryExpr));


			Visit(inSubQueryExpr.Operand);

			_sql.AppendLine(" IN (");

			using (_sql.Indent())
			{
				Visit(inSubQueryExpr.SubQuery);
			}

			_sql.AppendLine(")");


			return inSubQueryExpr;
		}


		public virtual SqlExpr VisitNotInSubQuery(SqlInSubQueryExpr inSubQueryExpr)
		{
			Check.NotNull(inSubQueryExpr, nameof(inSubQueryExpr));


			Visit(inSubQueryExpr.Operand);

			_sql.AppendLine(" NOT IN (");

			using (_sql.Indent())
			{
				Visit(inSubQueryExpr.SubQuery);
			}

			_sql.AppendLine(")");


			return inSubQueryExpr;
		}


		public virtual SqlExpr VisitComparisonSubQuery(SqlComparisonSubQueryExpr comparisonSubQueryExpr)
		{
			Check.NotNull(comparisonSubQueryExpr, nameof(comparisonSubQueryExpr));


			Visit(comparisonSubQueryExpr.Operand);

			VisitComparisonOperator(comparisonSubQueryExpr.Operator);

			Visit(comparisonSubQueryExpr.SubQuery);


			return comparisonSubQueryExpr;
		}


		public virtual SqlExpr VisitScalarSubQuery(SqlScalarSubQueryExpr scalarSubQueryExpr)
		{
			Check.NotNull(scalarSubQueryExpr, nameof(scalarSubQueryExpr));


			_sql.AppendLine(" (");

			using (_sql.Indent())
			{
				Visit(scalarSubQueryExpr.SubQuery);
			}

			_sql.AppendLine(")");


			return scalarSubQueryExpr;
		}


		public virtual SqlExpr VisitAny(SqlAnyExpr anyExpr)
		{
			Check.NotNull(anyExpr, nameof(anyExpr));


			_sql.AppendLine(" ANY (");

			using (_sql.Indent())
			{
				Visit(anyExpr.SubQuery);
			}

			_sql.AppendLine(")");


			return anyExpr;
		}


		public virtual SqlExpr VisitAll(SqlAllExpr allExpr)
		{
			Check.NotNull(allExpr, nameof(allExpr));


			_sql.AppendLine(" ALL (");

			using (_sql.Indent())
			{
				Visit(allExpr.SubQuery);
			}

			_sql.AppendLine(")");


			return allExpr;
		}


		public virtual SqlExpr VisitOrdering(SqlOrderingExpr orderingExpr)
		{
			Check.NotNull(orderingExpr, nameof(orderingExpr));


			var aliasExpr = orderingExpr.Operand as SqlAliasExpr;

			if (aliasExpr != null)
			{
				if (aliasExpr.Alias != null)
				{
					_sql.Append(DelimitIdentifier(aliasExpr.Alias));
				}
				else
				{
					Visit(aliasExpr.Operand);
				}
			}
			else
			{
				Visit(orderingExpr.Operand);
			}

			if (orderingExpr.OrderingDirection == SqlOrderingDirection.Desc)
			{
				_sql.Append(" DESC");
			}


			return orderingExpr;
		}


		public virtual SqlExpr VisitCombineResult(SqlCombineResultExprBase combineResultExpr)
		{
			Check.NotNull(combineResultExpr, nameof(combineResultExpr));


			_sql.AppendLine(combineResultExpr.Operator);

			if (combineResultExpr.NextQuery.CombineResults.Any())
			{
				_sql.AppendLine("(");
			}

			Visit(combineResultExpr.NextQuery);

			if (combineResultExpr.NextQuery.CombineResults.Any())
			{
				_sql.AppendLine()
					 .AppendLine(")");
			}


			return combineResultExpr;
		}


		public virtual SqlExpr VisitGroupingSets(SqlMultipleGroupingSetsExprBase groupingSetsExpr)
		{
			Check.NotNull(groupingSetsExpr, nameof(groupingSetsExpr));


			_sql.Append(groupingSetsExpr.Operator)
				 .Append(" (");

			VisitJoin(groupingSetsExpr.Exprs);

			_sql.Append(")");


			return groupingSetsExpr;
		}


		public virtual SqlExpr VisitOver(SqlOverExpr overExpr)
		{
			Check.NotNull(overExpr, nameof(overExpr));


			Visit(overExpr.Function);

			_sql.Append(" OVER(");

			if (overExpr.PartitionByClause.Any())
			{
				_sql.Append("PARTITION BY ");

				VisitJoin(overExpr.PartitionByClause);
			}

			if (overExpr.OrderByClause.Any())
			{
				if (overExpr.PartitionByClause.Any())
				{
					_sql.Append(" ");
				}

				_sql.Append("ORDER BY ");

				VisitJoin(overExpr.OrderByClause);
			}

			_sql.Append(")");


			return overExpr;
		}


		public virtual SqlExpr VisitSqlFunction(SqlFunctionExprBase functionExpr)
		{
			Check.NotNull(functionExpr, nameof(functionExpr));


			_sql.Append(functionExpr.Name)
				 .Append("(");

			VisitJoin(functionExpr.Parameters);

			_sql.Append(")");


			return functionExpr;
		}


		public virtual SqlExpr VisitSqlDistinctableFunction(SqlDistinctableFunctionExpr functionExpr)
		{
			Check.NotNull(functionExpr, nameof(functionExpr));


			_sql.Append(functionExpr.Name)
				 .Append(functionExpr.IsDistinct ? "(DISTINCT " : "(");

			VisitJoin(functionExpr.Parameters);

			_sql.Append(")");


			return functionExpr;
		}


		public virtual SqlExpr VisitCount(SqlCountExpr countExpr)
		{
			Check.NotNull(countExpr, nameof(countExpr));


			if (countExpr.Parameters.Any())
			{
				VisitSqlDistinctableFunction(countExpr);
			}
			else
			{
				_sql.Append("COUNT(*)");
			}


			return countExpr;
		}


		#endregion


		#region [ Private Methods ]


		private void VisitJoin(
			IEnumerable<SqlExpr> expressions, Action<IndentedStringBuilder> joinAction = null)
			=> VisitJoin(expressions, e => Visit(e), joinAction);


		private void VisitJoin<T>(
			 IEnumerable<T> items, Action<T> itemAction, Action<IndentedStringBuilder> joinAction = null)
		{
			joinAction = joinAction ?? (isb => isb.Append(", "));

			bool first = true;
			foreach(var item in items)
			{
				if (!first)
				{
					joinAction(_sql);
				}

				itemAction(item);

				first = false;
			}
		}


		private void VisitComparisonOperator(SqlComparisonOperator @operator)
		{
			string op;

			switch (@operator)
			{
				case SqlComparisonOperator.Equal:
					op = " = ";
					break;
				case SqlComparisonOperator.NotEqual:
					op = " <> ";
					break;
				case SqlComparisonOperator.GreaterThan:
					op = " > ";
					break;
				case SqlComparisonOperator.GreaterThanOrEqual:
					op = " >= ";
					break;
				case SqlComparisonOperator.LessThan:
					op = " < ";
					break;
				case SqlComparisonOperator.LessThanOrEqual:
					op = " <= ";
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			_sql.Append(op);
		}


		#endregion

	}

}
