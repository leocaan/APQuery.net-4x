using QueryFramework.Relational.SqlGen;
using System.Collections.Generic;

namespace QueryFramework.Relational.SqlSyntex
{

	public abstract class SqlExpr
	{

		#region [ Static ]


		public static SqlAllExpr All(SqlSelectExpr subQuery)
			=> new SqlAllExpr(subQuery);

		public static SqlAndExpr AndAlso(SqlPredicateExpr left, SqlPredicateExpr right)
			=> new SqlAndExpr(left, right);

		public static SqlAnyExpr Any(SqlSelectExpr subQuery)
			=> new SqlAnyExpr(subQuery);

		public static SqlAliasExpr As(SqlOperableExpr operand, string alias)
			=> new SqlAliasExpr(operand, alias);

		public static SqlOrderingExpr Asc(SqlExpr operand)
			=> new SqlOrderingExpr(operand, SqlOrderingDirection.Asc);

		public static SqlAvgExpr Avg(SqlOperableExpr operand)
			=> new SqlAvgExpr(operand);

		public static SqlBetweenExpr Between(SqlOperableExpr operand, SqlOperableExpr begin, SqlOperableExpr end)
			=> new SqlBetweenExpr(operand, begin, end);

		public static SqlConstantExpr Constant(object value)
			=> value == null ? NULL : new SqlConstantExpr(value);

		public readonly static SqlCountExpr CountStar
			= new SqlCountExpr();

		public static SqlCountExpr Count(SqlOperableExpr operand)
			=> new SqlCountExpr(operand);

		public static SqlCrossJoinExpr CrossJoin(SqlQuerySourceExpr source)
			=> new SqlCrossJoinExpr(source);

		public static SqlCubeExpr Cube(SqlGroupableExpr grouping)
		{
			var clause = new SqlCubeExpr();
			clause.AddExpr(grouping);
			return clause;
		}

		public static SqlCubeExpr Cube(IEnumerable<SqlGroupableExpr> groupings)
		{
			var clause = new SqlCubeExpr();
			clause.AddExpr(groupings);
			return clause;
		}

		public static SqlCubeExpr Cube(params SqlGroupableExpr[] groupings)
		{
			var clause = new SqlCubeExpr();
			clause.AddExpr(groupings);
			return clause;
		}

		public static SqlDenseRankExpr DenseRank()
			=> new SqlDenseRankExpr();

		public static SqlOrderingExpr Desc(SqlExpr operand)
			=> new SqlOrderingExpr(operand, SqlOrderingDirection.Desc);

		public static SqlDistinctableFunctionExpr DistFunc(string name, SqlOperableExpr expr)
			=> new SqlDistinctableFunctionExpr(name).AddParameter(expr) as SqlDistinctableFunctionExpr;

		public static SqlDistinctableFunctionExpr DistFunc(string name, IEnumerable<SqlOperableExpr> exprs)
			=> new SqlDistinctableFunctionExpr(name).AddParameter(exprs) as SqlDistinctableFunctionExpr;

		public static SqlDistinctableFunctionExpr DistFunc(string name, params SqlOperableExpr[] exprs)
			=> new SqlDistinctableFunctionExpr(name).AddParameter(exprs) as SqlDistinctableFunctionExpr;

		public static SqlComparisonExpr Equal(SqlOperableExpr left, SqlOperableExpr right)
			=> new SqlComparisonExpr(left, right, SqlComparisonOperator.Equal);

		public static SqlComparisonSubQueryExpr Equal(SqlOperableExpr operand, SqlScalarSubQueryExpr subQuery)
			=> new SqlComparisonSubQueryExpr(operand, subQuery, SqlComparisonOperator.Equal);

		public static SqlExceptExpr Except(SqlSelectExpr nextQuery)
			=> new SqlExceptExpr(nextQuery);

		public static SqlExistsExpr Exists(SqlSelectExpr subQuery)
			=> new SqlExistsExpr(subQuery);

		public static SqlFullOuterJoinExpr FullJoin(SqlQuerySourceExpr source, SqlPredicateExpr predicate)
			=> new SqlFullOuterJoinExpr(source) { Predicate = predicate };

		public static SqlComparisonExpr GreaterThan(SqlOperableExpr left, SqlOperableExpr right)
			=> new SqlComparisonExpr(left, right, SqlComparisonOperator.GreaterThan);

		public static SqlComparisonSubQueryExpr GreaterThan(SqlOperableExpr operand, SqlScalarSubQueryExpr subQuery)
			=> new SqlComparisonSubQueryExpr(operand, subQuery, SqlComparisonOperator.GreaterThan);

		public static SqlComparisonExpr GreaterThanOrEqual(SqlOperableExpr left, SqlOperableExpr right)
			=> new SqlComparisonExpr(left, right, SqlComparisonOperator.GreaterThanOrEqual);

		public static SqlComparisonSubQueryExpr GreaterThanOrEqual(SqlOperableExpr operand, SqlScalarSubQueryExpr subQuery)
			=> new SqlComparisonSubQueryExpr(operand, subQuery, SqlComparisonOperator.GreaterThanOrEqual);

		public static SqlGroupableExpr Grouping(SqlOperableExpr operand)
			=> new SqlGroupableExpr(operand);

		public static SqlScalarSubQueryExpr Scalar(SqlSelectExpr subQuery)
			=> new SqlScalarSubQueryExpr(subQuery);

		public static SqlGroupingSetsExpr GroupingSets(SqlGroupableExpr grouping)
		{
			var clause = new SqlGroupingSetsExpr();
			clause.AddExpr(grouping);
			return clause;
		}

		public static SqlGroupingSetsExpr GroupingSets(IEnumerable<SqlGroupableExpr> groupings)
		{
			var clause = new SqlGroupingSetsExpr();
			clause.AddExpr(groupings);
			return clause;
		}

		public static SqlGroupingSetsExpr GroupingSets(params SqlGroupableExpr[] groupings)
		{
			var clause = new SqlGroupingSetsExpr();
			clause.AddExpr(groupings);
			return clause;
		}

		public static SqlInExpr In(SqlOperableExpr operand, IEnumerable<SqlOperableExpr> values)
			=> new SqlInExpr(operand, values);

		public static SqlInExpr In(SqlOperableExpr operand, params SqlOperableExpr[] values)
			=> new SqlInExpr(operand, values);

		public static SqlInSubQueryExpr In(SqlOperableExpr operand, SqlSelectExpr subQuery)
			=> new SqlInSubQueryExpr(operand, subQuery);

		public static SqlInnerJoinExpr InnerJoin(SqlQuerySourceExpr source, SqlPredicateExpr predicate)
			=> new SqlInnerJoinExpr(source) { Predicate = predicate };

		public static SqlIntersectExpr Intersect(SqlSelectExpr nextQuery)
			=> new SqlIntersectExpr(nextQuery);

		public static SqlNotExpr IsNotNull(SqlOperableExpr operand)
			=> Not(IsNull(operand));

		public static SqlIsNullExpr IsNull(SqlOperableExpr operand)
			=> new SqlIsNullExpr(operand);

		public static SqlLeftOuterJoinExpr LeftJoin(SqlQuerySourceExpr source, SqlPredicateExpr predicate)
			=> new SqlLeftOuterJoinExpr(source) { Predicate = predicate };

		public static SqlComparisonExpr LessThan(SqlOperableExpr left, SqlOperableExpr right)
			=> new SqlComparisonExpr(left, right, SqlComparisonOperator.LessThan);

		public static SqlComparisonSubQueryExpr LessThan(SqlOperableExpr operand, SqlScalarSubQueryExpr subQuery)
			=> new SqlComparisonSubQueryExpr(operand, subQuery, SqlComparisonOperator.LessThan);

		public static SqlComparisonExpr LessThanOrEqual(SqlOperableExpr left, SqlOperableExpr right)
			=> new SqlComparisonExpr(left, right, SqlComparisonOperator.LessThanOrEqual);

		public static SqlComparisonSubQueryExpr LessThanOrEqual(SqlOperableExpr operand, SqlScalarSubQueryExpr subQuery)
			=> new SqlComparisonSubQueryExpr(operand, subQuery, SqlComparisonOperator.LessThanOrEqual);

		public static SqlLikeExpr Like(SqlOperableExpr match, SqlOperableExpr pattern)
			=> new SqlLikeExpr(match, pattern);

		public static SqlLiteralExpr Literal(string literal)
			=> new SqlLiteralExpr(literal);

		public static SqlMaxExpr Max(SqlOperableExpr operand)
			=> new SqlMaxExpr(operand);

		public static SqlMinExpr Min(SqlOperableExpr operand)
			=> new SqlMinExpr(operand);

		public static SqlNotExpr Not(SqlPredicateExpr operand)
			=> new SqlNotExpr(operand);

		public static SqlNotExpr NotBetween(SqlOperableExpr operand, SqlOperableExpr begin, SqlOperableExpr end)
			=> Not(Between(operand, begin, end));

		public static SqlComparisonExpr NotEqual(SqlOperableExpr left, SqlOperableExpr right)
			=> new SqlComparisonExpr(left, right, SqlComparisonOperator.NotEqual);

		public static SqlComparisonSubQueryExpr NotEqual(SqlOperableExpr operand, SqlScalarSubQueryExpr subQuery)
			=> new SqlComparisonSubQueryExpr(operand, subQuery, SqlComparisonOperator.NotEqual);

		public static SqlNotExpr NotIn(SqlOperableExpr operand, IEnumerable<SqlOperableExpr> values)
			=> Not(In(operand, values));

		public static SqlNotExpr NotIn(SqlOperableExpr operand, params SqlOperableExpr[] values)
			=> Not(In(operand, values));

		public static SqlNotExpr NotIn(SqlOperableExpr operand, SqlSelectExpr subQuery)
			=> Not(In(operand, subQuery));

		public static SqlNotExpr NotLike(SqlOperableExpr match, SqlOperableExpr pattern)
			=> Not(Like(match, pattern));

		public static SqlNotExpr NotExists(SqlSelectExpr subQuery)
			=> Not(Exists(subQuery));

		public static SqlNtileExpr Ntile(int number)
			=> new SqlNtileExpr(number);

		public readonly static SqlConstantExpr NULL
			= new SqlConstantExpr(null);

		public static SqlOrExpr OrElse(SqlPredicateExpr left, SqlPredicateExpr right)
			=> new SqlOrExpr(left, right);

		public static SqlOverExpr Over(SqlFunctionExprBase function)
			=> new SqlOverExpr(function);

		public static SqlParameterExpr Parameter(object value)
			=> new SqlParameterExpr(value);

		public static SqlProjectableExpr Project(SqlOperableExpr operand)
			=> new SqlProjectableExpr(operand);

		public static SqlRightOuterJoinExpr RightJoin(SqlQuerySourceExpr source, SqlPredicateExpr predicate)
			=> new SqlRightOuterJoinExpr(source) { Predicate = predicate };

		public static SqlRankExpr Rank()
			=> new SqlRankExpr();

		public static SqlRawSqlExpr RawSql(string sql)
			=> new SqlRawSqlExpr(sql);

		public static SqlRollupExpr Rollup(SqlGroupableExpr grouping)
		{
			var clause = new SqlRollupExpr();
			clause.AddExpr(grouping);
			return clause;
		}

		public static SqlRollupExpr Rollup(IEnumerable<SqlGroupableExpr> groupings)
		{
			var clause = new SqlRollupExpr();
			clause.AddExpr(groupings);
			return clause;
		}

		public static SqlRollupExpr Rollup(params SqlGroupableExpr[] groupings)
		{
			var clause = new SqlRollupExpr();
			clause.AddExpr(groupings);
			return clause;
		}

		public static SqlRowNumberExpr RowNumber()
			=> new SqlRowNumberExpr();

		public readonly static SqlProjectStarExpr Star
			= new SqlProjectStarExpr(null);

		public static SqlSumExpr Sum(SqlOperableExpr operand)
			=> new SqlSumExpr(operand);

		public static SqlUnionExpr Union(SqlSelectExpr nextQuery)
			=> new SqlUnionExpr(nextQuery, false);

		public static SqlUnionExpr UnionAll(SqlSelectExpr nextQuery)
			=> new SqlUnionExpr(nextQuery, true);





		//public static BinaryExpression Add(Expression left, Expression right);
		//public static BinaryExpression Add(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression AddAssign(Expression left, Expression right);
		//public static BinaryExpression AddAssign(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression AddAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
		//public static BinaryExpression AddAssignChecked(Expression left, Expression right);
		//public static BinaryExpression AddAssignChecked(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression AddAssignChecked(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
		//public static BinaryExpression AddChecked(Expression left, Expression right);
		//public static BinaryExpression AddChecked(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression And(Expression left, Expression right);
		//public static BinaryExpression And(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression AndAssign(Expression left, Expression right);
		//public static BinaryExpression AndAssign(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression AndAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
		//public static IndexExpression ArrayAccess(Expression array, params Expression[] indexes);
		//public static IndexExpression ArrayAccess(Expression array, IEnumerable<Expression> indexes);
		//public static MethodCallExpression ArrayIndex(Expression array, params Expression[] indexes);
		//public static BinaryExpression ArrayIndex(Expression array, Expression index);
		//public static MethodCallExpression ArrayIndex(Expression array, IEnumerable<Expression> indexes);
		//public static UnaryExpression ArrayLength(Expression array);
		//public static BinaryExpression Assign(Expression left, Expression right);
		//public static MemberAssignment Bind(MemberInfo member, Expression expression);
		//public static MemberAssignment Bind(MethodInfo propertyAccessor, Expression expression);
		//public static BlockExpression Block(params Expression[] expressions);
		//public static BlockExpression Block(IEnumerable<Expression> expressions);
		//public static BlockExpression Block(Type type, params Expression[] expressions);
		//public static BlockExpression Block(IEnumerable<ParameterExpression> variables, params Expression[] expressions);
		//public static BlockExpression Block(IEnumerable<ParameterExpression> variables, IEnumerable<Expression> expressions);
		//public static BlockExpression Block(Expression arg0, Expression arg1);
		//public static BlockExpression Block(Type type, IEnumerable<Expression> expressions);
		//public static BlockExpression Block(Type type, IEnumerable<ParameterExpression> variables, params Expression[] expressions);
		//public static BlockExpression Block(Expression arg0, Expression arg1, Expression arg2);
		//public static BlockExpression Block(Type type, IEnumerable<ParameterExpression> variables, IEnumerable<Expression> expressions);
		//public static BlockExpression Block(Expression arg0, Expression arg1, Expression arg2, Expression arg3);
		//public static BlockExpression Block(Expression arg0, Expression arg1, Expression arg2, Expression arg3, Expression arg4);
		//public static GotoExpression Break(LabelTarget target);
		//public static GotoExpression Break(LabelTarget target, Expression value);
		//public static GotoExpression Break(LabelTarget target, Type type);
		//public static GotoExpression Break(LabelTarget target, Expression value, Type type);
		//public static MethodCallExpression Call(MethodInfo method, params Expression[] arguments);
		//public static MethodCallExpression Call(MethodInfo method, IEnumerable<Expression> arguments);
		//public static MethodCallExpression Call(MethodInfo method, Expression arg0);
		//public static MethodCallExpression Call(Expression instance, MethodInfo method);
		//public static MethodCallExpression Call(Expression instance, MethodInfo method, IEnumerable<Expression> arguments);
		//public static MethodCallExpression Call(Expression instance, MethodInfo method, params Expression[] arguments);
		//public static MethodCallExpression Call(MethodInfo method, Expression arg0, Expression arg1);
		//public static MethodCallExpression Call(MethodInfo method, Expression arg0, Expression arg1, Expression arg2);
		//public static MethodCallExpression Call(Expression instance, string methodName, Type[] typeArguments, params Expression[] arguments);
		//public static MethodCallExpression Call(Type type, string methodName, Type[] typeArguments, params Expression[] arguments);
		//public static MethodCallExpression Call(Expression instance, MethodInfo method, Expression arg0, Expression arg1);
		//public static MethodCallExpression Call(Expression instance, MethodInfo method, Expression arg0, Expression arg1, Expression arg2);
		//public static MethodCallExpression Call(MethodInfo method, Expression arg0, Expression arg1, Expression arg2, Expression arg3);
		//public static MethodCallExpression Call(MethodInfo method, Expression arg0, Expression arg1, Expression arg2, Expression arg3, Expression arg4);
		//public static CatchBlock Catch(Type type, Expression body);
		//public static CatchBlock Catch(ParameterExpression variable, Expression body);
		//public static CatchBlock Catch(Type type, Expression body, Expression filter);
		//public static CatchBlock Catch(ParameterExpression variable, Expression body, Expression filter);
		//public static DebugInfoExpression ClearDebugInfo(SymbolDocumentInfo document);
		//public static BinaryExpression Coalesce(Expression left, Expression right);
		//public static BinaryExpression Coalesce(Expression left, Expression right, LambdaExpression conversion);
		//public static ConditionalExpression Condition(Expression test, Expression ifTrue, Expression ifFalse);
		//public static ConditionalExpression Condition(Expression test, Expression ifTrue, Expression ifFalse, Type type);
		//public static GotoExpression Continue(LabelTarget target);
		//public static GotoExpression Continue(LabelTarget target, Type type);
		//public static UnaryExpression Convert(Expression expression, Type type);
		//public static UnaryExpression Convert(Expression expression, Type type, MethodInfo method);
		//public static UnaryExpression ConvertChecked(Expression expression, Type type);
		//public static UnaryExpression ConvertChecked(Expression expression, Type type, MethodInfo method);
		//public static DebugInfoExpression DebugInfo(SymbolDocumentInfo document, int startLine, int startColumn, int endLine, int endColumn);
		//public static UnaryExpression Decrement(Expression expression);
		//public static UnaryExpression Decrement(Expression expression, MethodInfo method);
		//public static DefaultExpression Default(Type type);
		//public static BinaryExpression Divide(Expression left, Expression right);
		//public static BinaryExpression Divide(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression DivideAssign(Expression left, Expression right);
		//public static BinaryExpression DivideAssign(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression DivideAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
		//public static DynamicExpression Dynamic(CallSiteBinder binder, Type returnType, Expression arg0);
		//public static DynamicExpression Dynamic(CallSiteBinder binder, Type returnType, IEnumerable<Expression> arguments);
		//public static DynamicExpression Dynamic(CallSiteBinder binder, Type returnType, params Expression[] arguments);
		//public static DynamicExpression Dynamic(CallSiteBinder binder, Type returnType, Expression arg0, Expression arg1);
		//public static DynamicExpression Dynamic(CallSiteBinder binder, Type returnType, Expression arg0, Expression arg1, Expression arg2);
		//public static DynamicExpression Dynamic(CallSiteBinder binder, Type returnType, Expression arg0, Expression arg1, Expression arg2, Expression arg3);
		//public static ElementInit ElementInit(MethodInfo addMethod, IEnumerable<Expression> arguments);
		//public static ElementInit ElementInit(MethodInfo addMethod, params Expression[] arguments);
		//public static DefaultExpression Empty();
		//public static BinaryExpression ExclusiveOr(Expression left, Expression right);
		//public static BinaryExpression ExclusiveOr(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression ExclusiveOrAssign(Expression left, Expression right);
		//public static BinaryExpression ExclusiveOrAssign(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression ExclusiveOrAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
		//public static MemberExpression Field(Expression expression, FieldInfo field);
		//public static MemberExpression Field(Expression expression, string fieldName);
		//public static MemberExpression Field(Expression expression, Type type, string fieldName);
		//public static Type GetActionType(params Type[] typeArgs);
		//public static Type GetDelegateType(params Type[] typeArgs);
		//public static Type GetFuncType(params Type[] typeArgs);
		//public static GotoExpression Goto(LabelTarget target);
		//public static GotoExpression Goto(LabelTarget target, Type type);
		//public static GotoExpression Goto(LabelTarget target, Expression value);
		//public static GotoExpression Goto(LabelTarget target, Expression value, Type type);
		//public static BinaryExpression GreaterThan(Expression left, Expression right);
		//public static BinaryExpression GreaterThan(Expression left, Expression right, bool liftToNull, MethodInfo method);
		//public static BinaryExpression GreaterThanOrEqual(Expression left, Expression right);
		//public static BinaryExpression GreaterThanOrEqual(Expression left, Expression right, bool liftToNull, MethodInfo method);
		//public static ConditionalExpression IfThen(Expression test, Expression ifTrue);
		//public static ConditionalExpression IfThenElse(Expression test, Expression ifTrue, Expression ifFalse);
		//public static UnaryExpression Increment(Expression expression);
		//public static UnaryExpression Increment(Expression expression, MethodInfo method);
		//public static InvocationExpression Invoke(Expression expression, IEnumerable<Expression> arguments);
		//public static InvocationExpression Invoke(Expression expression, params Expression[] arguments);
		//public static UnaryExpression IsFalse(Expression expression);
		//public static UnaryExpression IsFalse(Expression expression, MethodInfo method);
		//public static UnaryExpression IsTrue(Expression expression);
		//public static UnaryExpression IsTrue(Expression expression, MethodInfo method);
		//public static LabelTarget Label();
		//public static LabelExpression Label(LabelTarget target);
		//public static LabelTarget Label(string name);
		//public static LabelTarget Label(Type type);
		//public static LabelTarget Label(Type type, string name);
		//public static LabelExpression Label(LabelTarget target, Expression defaultValue);
		//public static LambdaExpression Lambda(Expression body, IEnumerable<ParameterExpression> parameters);
		//public static LambdaExpression Lambda(Expression body, params ParameterExpression[] parameters);
		//public static LambdaExpression Lambda(Type delegateType, Expression body, IEnumerable<ParameterExpression> parameters);
		//public static LambdaExpression Lambda(Type delegateType, Expression body, params ParameterExpression[] parameters);
		//public static LambdaExpression Lambda(Expression body, bool tailCall, IEnumerable<ParameterExpression> parameters);
		//public static LambdaExpression Lambda(Expression body, bool tailCall, params ParameterExpression[] parameters);
		//public static LambdaExpression Lambda(Expression body, string name, IEnumerable<ParameterExpression> parameters);
		//public static LambdaExpression Lambda(Expression body, string name, bool tailCall, IEnumerable<ParameterExpression> parameters);
		//public static LambdaExpression Lambda(Type delegateType, Expression body, bool tailCall, params ParameterExpression[] parameters);
		//public static LambdaExpression Lambda(Type delegateType, Expression body, bool tailCall, IEnumerable<ParameterExpression> parameters);
		//public static LambdaExpression Lambda(Type delegateType, Expression body, string name, IEnumerable<ParameterExpression> parameters);
		//public static LambdaExpression Lambda(Type delegateType, Expression body, string name, bool tailCall, IEnumerable<ParameterExpression> parameters);
		//public static Expression<TDelegate> Lambda<TDelegate>(Expression body, IEnumerable<ParameterExpression> parameters);
		//public static Expression<TDelegate> Lambda<TDelegate>(Expression body, params ParameterExpression[] parameters);
		//public static Expression<TDelegate> Lambda<TDelegate>(Expression body, bool tailCall, IEnumerable<ParameterExpression> parameters);
		//public static Expression<TDelegate> Lambda<TDelegate>(Expression body, string name, IEnumerable<ParameterExpression> parameters);
		//public static Expression<TDelegate> Lambda<TDelegate>(Expression body, bool tailCall, params ParameterExpression[] parameters);
		//public static Expression<TDelegate> Lambda<TDelegate>(Expression body, string name, bool tailCall, IEnumerable<ParameterExpression> parameters);
		//public static BinaryExpression LeftShift(Expression left, Expression right);
		//public static BinaryExpression LeftShift(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression LeftShiftAssign(Expression left, Expression right);
		//public static BinaryExpression LeftShiftAssign(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression LeftShiftAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
		//public static BinaryExpression LessThan(Expression left, Expression right);
		//public static BinaryExpression LessThan(Expression left, Expression right, bool liftToNull, MethodInfo method);
		//public static BinaryExpression LessThanOrEqual(Expression left, Expression right);
		//public static BinaryExpression LessThanOrEqual(Expression left, Expression right, bool liftToNull, MethodInfo method);
		//public static MemberListBinding ListBind(MethodInfo propertyAccessor, params ElementInit[] initializers);
		//public static MemberListBinding ListBind(MethodInfo propertyAccessor, IEnumerable<ElementInit> initializers);
		//public static MemberListBinding ListBind(MemberInfo member, IEnumerable<ElementInit> initializers);
		//public static MemberListBinding ListBind(MemberInfo member, params ElementInit[] initializers);
		//public static ListInitExpression ListInit(NewExpression newExpression, IEnumerable<Expression> initializers);
		//public static ListInitExpression ListInit(NewExpression newExpression, params Expression[] initializers);
		//public static ListInitExpression ListInit(NewExpression newExpression, params ElementInit[] initializers);
		//public static ListInitExpression ListInit(NewExpression newExpression, IEnumerable<ElementInit> initializers);
		//public static ListInitExpression ListInit(NewExpression newExpression, MethodInfo addMethod, params Expression[] initializers);
		//public static ListInitExpression ListInit(NewExpression newExpression, MethodInfo addMethod, IEnumerable<Expression> initializers);
		//public static LoopExpression Loop(Expression body);
		//public static LoopExpression Loop(Expression body, LabelTarget @break);
		//public static LoopExpression Loop(Expression body, LabelTarget @break, LabelTarget @continue);
		//public static BinaryExpression MakeBinary(ExpressionType binaryType, Expression left, Expression right);
		//public static BinaryExpression MakeBinary(ExpressionType binaryType, Expression left, Expression right, bool liftToNull, MethodInfo method);
		//public static BinaryExpression MakeBinary(ExpressionType binaryType, Expression left, Expression right, bool liftToNull, MethodInfo method, LambdaExpression conversion);
		//public static CatchBlock MakeCatchBlock(Type type, ParameterExpression variable, Expression body, Expression filter);
		//public static DynamicExpression MakeDynamic(Type delegateType, CallSiteBinder binder, params Expression[] arguments);
		//public static DynamicExpression MakeDynamic(Type delegateType, CallSiteBinder binder, IEnumerable<Expression> arguments);
		//public static DynamicExpression MakeDynamic(Type delegateType, CallSiteBinder binder, Expression arg0);
		//public static DynamicExpression MakeDynamic(Type delegateType, CallSiteBinder binder, Expression arg0, Expression arg1);
		//public static DynamicExpression MakeDynamic(Type delegateType, CallSiteBinder binder, Expression arg0, Expression arg1, Expression arg2);
		//public static DynamicExpression MakeDynamic(Type delegateType, CallSiteBinder binder, Expression arg0, Expression arg1, Expression arg2, Expression arg3);
		//public static GotoExpression MakeGoto(GotoExpressionKind kind, LabelTarget target, Expression value, Type type);
		//public static IndexExpression MakeIndex(Expression instance, PropertyInfo indexer, IEnumerable<Expression> arguments);
		//public static MemberExpression MakeMemberAccess(Expression expression, MemberInfo member);
		//public static TryExpression MakeTry(Type type, Expression body, Expression @finally, Expression fault, IEnumerable<CatchBlock> handlers);
		//public static UnaryExpression MakeUnary(ExpressionType unaryType, Expression operand, Type type);
		//public static UnaryExpression MakeUnary(ExpressionType unaryType, Expression operand, Type type, MethodInfo method);
		//public static MemberMemberBinding MemberBind(MemberInfo member, IEnumerable<MemberBinding> bindings);
		//public static MemberMemberBinding MemberBind(MethodInfo propertyAccessor, params MemberBinding[] bindings);
		//public static MemberMemberBinding MemberBind(MethodInfo propertyAccessor, IEnumerable<MemberBinding> bindings);
		//public static MemberMemberBinding MemberBind(MemberInfo member, params MemberBinding[] bindings);
		//public static MemberInitExpression MemberInit(NewExpression newExpression, params MemberBinding[] bindings);
		//public static MemberInitExpression MemberInit(NewExpression newExpression, IEnumerable<MemberBinding> bindings);
		//public static BinaryExpression Modulo(Expression left, Expression right);
		//public static BinaryExpression Modulo(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression ModuloAssign(Expression left, Expression right);
		//public static BinaryExpression ModuloAssign(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression ModuloAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
		//public static BinaryExpression Multiply(Expression left, Expression right);
		//public static BinaryExpression Multiply(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression MultiplyAssign(Expression left, Expression right);
		//public static BinaryExpression MultiplyAssign(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression MultiplyAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
		//public static BinaryExpression MultiplyAssignChecked(Expression left, Expression right);
		//public static BinaryExpression MultiplyAssignChecked(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression MultiplyAssignChecked(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
		//public static BinaryExpression MultiplyChecked(Expression left, Expression right);
		//public static BinaryExpression MultiplyChecked(Expression left, Expression right, MethodInfo method);
		//public static UnaryExpression Negate(Expression expression);
		//public static UnaryExpression Negate(Expression expression, MethodInfo method);
		//public static UnaryExpression NegateChecked(Expression expression);
		//public static UnaryExpression NegateChecked(Expression expression, MethodInfo method);
		//public static NewExpression New(Type type);
		//public static NewExpression New(ConstructorInfo constructor);
		//public static NewExpression New(ConstructorInfo constructor, params Expression[] arguments);
		//public static NewExpression New(ConstructorInfo constructor, IEnumerable<Expression> arguments);
		//public static NewExpression New(ConstructorInfo constructor, IEnumerable<Expression> arguments, IEnumerable<MemberInfo> members);
		//public static NewExpression New(ConstructorInfo constructor, IEnumerable<Expression> arguments, params MemberInfo[] members);
		//public static NewArrayExpression NewArrayBounds(Type type, params Expression[] bounds);
		//public static NewArrayExpression NewArrayBounds(Type type, IEnumerable<Expression> bounds);
		//public static NewArrayExpression NewArrayInit(Type type, params Expression[] initializers);
		//public static NewArrayExpression NewArrayInit(Type type, IEnumerable<Expression> initializers);
		//public static UnaryExpression OnesComplement(Expression expression);
		//public static UnaryExpression OnesComplement(Expression expression, MethodInfo method);
		//public static BinaryExpression Or(Expression left, Expression right);
		//public static BinaryExpression Or(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression OrAssign(Expression left, Expression right);
		//public static BinaryExpression OrAssign(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression OrAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
		//public static UnaryExpression PostDecrementAssign(Expression expression);
		//public static UnaryExpression PostDecrementAssign(Expression expression, MethodInfo method);
		//public static UnaryExpression PostIncrementAssign(Expression expression);
		//public static UnaryExpression PostIncrementAssign(Expression expression, MethodInfo method);
		//public static BinaryExpression Power(Expression left, Expression right);
		//public static BinaryExpression Power(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression PowerAssign(Expression left, Expression right);
		//public static BinaryExpression PowerAssign(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression PowerAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
		//public static UnaryExpression PreDecrementAssign(Expression expression);
		//public static UnaryExpression PreDecrementAssign(Expression expression, MethodInfo method);
		//public static UnaryExpression PreIncrementAssign(Expression expression);
		//public static UnaryExpression PreIncrementAssign(Expression expression, MethodInfo method);
		//public static MemberExpression Property(Expression expression, PropertyInfo property);
		//public static MemberExpression Property(Expression expression, MethodInfo propertyAccessor);
		//public static MemberExpression Property(Expression expression, string propertyName);
		//public static IndexExpression Property(Expression instance, PropertyInfo indexer, IEnumerable<Expression> arguments);
		//public static IndexExpression Property(Expression instance, PropertyInfo indexer, params Expression[] arguments);
		//public static IndexExpression Property(Expression instance, string propertyName, params Expression[] arguments);
		//public static MemberExpression Property(Expression expression, Type type, string propertyName);
		//public static MemberExpression PropertyOrField(Expression expression, string propertyOrFieldName);
		//public static UnaryExpression Quote(Expression expression);
		//public static BinaryExpression ReferenceEqual(Expression left, Expression right);
		//public static BinaryExpression ReferenceNotEqual(Expression left, Expression right);
		//public static UnaryExpression Rethrow();
		//public static UnaryExpression Rethrow(Type type);
		//public static GotoExpression Return(LabelTarget target);
		//public static GotoExpression Return(LabelTarget target, Type type);
		//public static GotoExpression Return(LabelTarget target, Expression value);
		//public static GotoExpression Return(LabelTarget target, Expression value, Type type);
		//public static BinaryExpression RightShift(Expression left, Expression right);
		//public static BinaryExpression RightShift(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression RightShiftAssign(Expression left, Expression right);
		//public static BinaryExpression RightShiftAssign(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression RightShiftAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
		//public static RuntimeVariablesExpression RuntimeVariables(IEnumerable<ParameterExpression> variables);
		//public static RuntimeVariablesExpression RuntimeVariables(params ParameterExpression[] variables);
		//public static BinaryExpression Subtract(Expression left, Expression right);
		//public static BinaryExpression Subtract(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression SubtractAssign(Expression left, Expression right);
		//public static BinaryExpression SubtractAssign(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression SubtractAssign(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
		//public static BinaryExpression SubtractAssignChecked(Expression left, Expression right);
		//public static BinaryExpression SubtractAssignChecked(Expression left, Expression right, MethodInfo method);
		//public static BinaryExpression SubtractAssignChecked(Expression left, Expression right, MethodInfo method, LambdaExpression conversion);
		//public static BinaryExpression SubtractChecked(Expression left, Expression right);
		//public static BinaryExpression SubtractChecked(Expression left, Expression right, MethodInfo method);
		//public static SwitchExpression Switch(Expression switchValue, params SwitchCase[] cases);
		//public static SwitchExpression Switch(Expression switchValue, Expression defaultBody, params SwitchCase[] cases);
		//public static SwitchExpression Switch(Expression switchValue, Expression defaultBody, MethodInfo comparison, params SwitchCase[] cases);
		//public static SwitchExpression Switch(Expression switchValue, Expression defaultBody, MethodInfo comparison, IEnumerable<SwitchCase> cases);
		//public static SwitchExpression Switch(Type type, Expression switchValue, Expression defaultBody, MethodInfo comparison, params SwitchCase[] cases);
		//public static SwitchExpression Switch(Type type, Expression switchValue, Expression defaultBody, MethodInfo comparison, IEnumerable<SwitchCase> cases);
		//public static SwitchCase SwitchCase(Expression body, IEnumerable<Expression> testValues);
		//public static SwitchCase SwitchCase(Expression body, params Expression[] testValues);
		//public static SymbolDocumentInfo SymbolDocument(string fileName);
		//public static SymbolDocumentInfo SymbolDocument(string fileName, Guid language);
		//public static SymbolDocumentInfo SymbolDocument(string fileName, Guid language, Guid languageVendor);
		//public static SymbolDocumentInfo SymbolDocument(string fileName, Guid language, Guid languageVendor, Guid documentType);
		//public static UnaryExpression Throw(Expression value);
		//public static UnaryExpression Throw(Expression value, Type type);
		//public static TryExpression TryCatch(Expression body, params CatchBlock[] handlers);
		//public static TryExpression TryCatchFinally(Expression body, Expression @finally, params CatchBlock[] handlers);
		//public static TryExpression TryFault(Expression body, Expression fault);
		//public static TryExpression TryFinally(Expression body, Expression @finally);
		//public static bool TryGetActionType(Type[] typeArgs, out Type actionType);
		//public static bool TryGetFuncType(Type[] typeArgs, out Type funcType);
		//public static UnaryExpression TypeAs(Expression expression, Type type);
		//public static TypeBinaryExpression TypeEqual(Expression expression, Type type);
		//public static TypeBinaryExpression TypeIs(Expression expression, Type type);
		//public static UnaryExpression UnaryPlus(Expression expression);
		//public static UnaryExpression UnaryPlus(Expression expression, MethodInfo method);
		//public static UnaryExpression Unbox(Expression expression, Type type);
		//public static ParameterExpression Variable(Type type);
		//public static ParameterExpression Variable(Type type, string name);

		#endregion


		#region [ Constructors ]


		internal SqlExpr()
		{

		}


		#endregion


		#region [ Methods ]


		public abstract SqlExpr Accept(ISqlExprVisitor visitor);


		#endregion

	}

}
