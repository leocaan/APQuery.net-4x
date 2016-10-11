// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Utilities;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlColumnExpr : SqlOperableExpr
   {

      #region [ Constructors ]


      internal SqlColumnExpr()
      {

      }


      public SqlColumnExpr(SqlQuerySourceExpr tableExpr, string name)
      {
         Check.NotNull(tableExpr, nameof(tableExpr));
         Check.NotEmpty(name, nameof(name));


         Table = tableExpr;
         Name = name;
      }


      #endregion


      #region [ Properties ]


      public virtual SqlQuerySourceExpr Table { get; internal set; }


      public virtual string Name { get; internal set; }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitColumn(this);


      #endregion

   }

}
