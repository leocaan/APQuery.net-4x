// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace QueryFramework.Query.SqlSyntex
{

   public abstract class SqlModificationCommand
   {

      #region [ Constructors ]


      internal SqlModificationCommand(SqlTableExpr target)
      {
         Target = target;
      }


      #endregion


      #region [ Properties ]


      public SqlTableExpr Target { get; }


      #endregion

   }

}
