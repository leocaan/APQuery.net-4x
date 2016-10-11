// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.SqlSyntex;
using QueryFramework.Storage;
using System.Collections.Generic;

namespace QueryFramework.Query.Sql
{

   public interface ISqlGenerator
   {

      #region [ Methods ]


      void GenerateSelect(SqlSelectExpr selectExpr);


      void GenerateInsert(SqlInsertCommand selectExpr);


      void GenerateUpdate(SqlUpdateCommand selectExpr);


      void GenerateDelete(SqlDeleteCommand selectExpr);


      string SqlString { get; }


      IReadOnlyList<IRelationalParameter> Parameters { get; }



      #endregion

   }

}
