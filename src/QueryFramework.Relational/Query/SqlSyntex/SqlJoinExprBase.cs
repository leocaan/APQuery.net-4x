// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Utilities;

namespace QueryFramework.Query.SqlSyntex
{

   public abstract class SqlJoinExprBase : SqlQuerySourceExpr
   {

      #region [ Fields ]


      private SqlPredicateExpr _predicate;


      #endregion


      #region [ Constructors ]


      protected SqlJoinExprBase(SqlQuerySourceExpr tableExpr)
         : base(Check.NotNull(tableExpr, nameof(tableExpr)).QuerySource, tableExpr.Alias)
      {
         TableExpr = tableExpr;
      }


      #endregion


      #region [ Properties ]


      public SqlQuerySourceExpr TableExpr { get; }


      public SqlPredicateExpr Predicate
      {
         get { return _predicate; }
         set { Check.NotNull(value, nameof(value)); _predicate = value; }
      }


      #endregion

   }

}
