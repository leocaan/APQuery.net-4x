// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Utilities;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlParameterExpr : SqlOperableExpr
   {

      #region [ Constructors ]


      public SqlParameterExpr(object value)
         :this(value, null)
      {
      }


      public SqlParameterExpr(object value, string name)
      {
         Check.NotNull(value, nameof(value));


         Value = value;
         Name = name;
      }


      #endregion


      #region [ Properties ]


      public virtual object Value { get; }


      public virtual string Name { get; set; }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitParameter(this);


      #endregion

   }

}
