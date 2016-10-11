// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.SqlSyntex;
using System;
using System.Collections.ObjectModel;

namespace QueryFramework.DBStruct
{

   public abstract class TableDef<TModel> : SqlTableExpr, ISqlQuerySource
   {

      #region [ Constructors ]


      protected TableDef(string schema, string name, string alias)
         : base(null, schema, name, alias)
      {
         QuerySource = this;

         DefBuilder.BuildTable(this);
      }


      #endregion


      #region [ Properties ]


      public ReadOnlyDictionary<string, ColumnDef<TModel>> Columns { get; internal set; }


      #endregion


      #region [ Methods ]


      public T As<T>(string aliasName) where T : TableDef<TModel>
      {
         T aliasTable = Activator.CreateInstance(this.GetType()) as T;

         aliasTable.Alias = aliasName;


         return aliasTable;
      }


      #endregion


      #region [ About Expr ]


      public SqlProjectStarExpr ProjectStar
         => new SqlProjectStarExpr(this);


      #endregion


   }

}
