// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Utilities;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlScalarSubQueryExpr : SqlExpr
   {

      #region [ Constructors ]


      public SqlScalarSubQueryExpr(SqlSelectExpr subQuery)
      {
         Check.NotNull(subQuery, nameof(subQuery));


         SubQuery = subQuery;
      }


      #endregion


      #region [ Properties ]


      public SqlSelectExpr SubQuery { get; }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitScalarSubQuery(this);


      #endregion


      #region [ Override Implementation of Implicit Operator ]


      public static implicit operator SqlScalarSubQueryExpr(SqlSelectExpr value)
         => SqlExpr.Scalar(value);


      #endregion

   }
}

