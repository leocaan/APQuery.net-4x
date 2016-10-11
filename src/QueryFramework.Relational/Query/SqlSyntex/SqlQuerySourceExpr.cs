// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace QueryFramework.Query.SqlSyntex
{

   public abstract class SqlQuerySourceExpr : SqlExpr
   {

      #region [ Constructors ]


      protected SqlQuerySourceExpr(ISqlQuerySource querySource, string alias)
      {
         QuerySource = querySource;
         Alias = alias;
      }


      #endregion


      #region [ Properties ]


      public ISqlQuerySource QuerySource { get; internal set; }


      public string Alias { get; internal set; }


      #endregion

   }

}
