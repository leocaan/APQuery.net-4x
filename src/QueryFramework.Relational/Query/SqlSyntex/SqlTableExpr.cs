// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlTableExpr : SqlQuerySourceExpr
   {
      
      #region [ Constructors ]


      public SqlTableExpr(ISqlQuerySource querySource, string schema, string name, string alias)
         : base(querySource, alias)
      {
         Schema = schema;
         Name = name;
      }


      #endregion


      #region [ Properties ]


      public virtual string Schema { get; internal set; }


      public virtual string Name { get; internal set; }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitTable(this);


      #endregion

   }

}
