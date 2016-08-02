using QueryFramework.Relational;
using QueryFramework.Relational.Storage;
using QueryFramework.Relational.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace QueryFramework.Relational.DBStruct
{

	internal static class DefBuilder
	{

		#region [ Constructors ]


		public static void BuildTable<TModel>(TableDef<TModel> tableDef)
		{

			// Temporary columns.

			Dictionary<string, ColumnDef<TModel>> dict = new Dictionary<string, ColumnDef<TModel>>();


			foreach (var prop in tableDef.GetType().GetProperties())
			{
				if (prop.PropertyType.IsSubclassOf(typeof(ColumnDef<TModel>)))
				{
					var column = prop.GetValue(tableDef) as ColumnDef<TModel>;

					column.TableDef = tableDef;

					if (dict.ContainsKey(column.Name))
						throw new DataStoreException(Strings.DBStruct_DuplicateColumnName(column.Name, tableDef.GetType().Name));

					dict.Add(column.Name, column);
				}
			}


			// Set table.

			if (String.IsNullOrEmpty(tableDef.Name))
				tableDef.Name = typeof(TModel).Name;
			tableDef.Columns = new ReadOnlyDictionary<string, ColumnDef<TModel>>(dict);

		}


		#endregion

	}

}
