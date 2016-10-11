// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlRawSqlExpr : SqlOperableExpr
   {

      #region [ Consturctors ]


      public SqlRawSqlExpr(string sql)
      {
         Sql = sql;
      }


      #endregion


      #region [ Properties ]


      public virtual string Sql { get; }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitRawSql(this);


      #endregion

   }

}
