// <auto-generated />
namespace QueryFramework.Relational
{
	using System;
	using System.Diagnostics;
	using System.Globalization;
	using System.Reflection;
	using System.Resources;

	public static class Strings
	{
		private static readonly ResourceManager _resourceManager
			= new ResourceManager("QueryFramework.Relational.Strings", typeof(Strings).GetTypeInfo().Assembly);

		/// <summary>
		/// The attribute 'connectionStringName' is missing or empty in applications configuration.
		/// </summary>
		public static string DataStore_ConnectionNameNotSpecified
		{
			get { return GetString("DataStore_ConnectionNameNotSpecified"); }
		}

		/// <summary>
		/// The connection name '{connectionStringName}' was not found in the applications configuration or the connection string is empty.
		/// </summary>
		public static string DataStore_ConnectionStringNotFound(object connectionStringName)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("DataStore_ConnectionStringNotFound", "connectionStringName"), connectionStringName);
		}

		/// <summary>
		/// The column name '{columnName}' is already existed in type '{tableType}'.
		/// </summary>
		public static string DBStruct_DuplicateColumnName(object columnName, object tableType)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("DBStruct_DuplicateColumnName", "columnName", "tableType"), columnName, tableType);
		}

		/// <summary>
		/// The specified transaction is not associated with the current connection. Only transactions associated with the current connection may be used.
		/// </summary>
		public static string Relational_TransactionAssociatedWithDifferentConnection
		{
			get { return GetString("Relational_TransactionAssociatedWithDifferentConnection"); }
		}

		/// <summary>
		/// Can not find the section '{sectionName}' in the applications configuration.
		/// </summary>
		public static string Configuration_NotFindSection(object sectionName)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("Configuration_NotFindSection", "sectionName"), sectionName);
		}

		/// <summary>
		/// Can not create instance of the type '{typeName}'.
		/// </summary>
		public static string Providers_CreateInstanceError(object typeName)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("Providers_CreateInstanceError", "typeName"), typeName);
		}

		/// <summary>
		/// Can not load the type '{typeName}'.
		/// </summary>
		public static string Providers_LoadTypeError(object typeName)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("Providers_LoadTypeError", "typeName"), typeName);
		}

		/// <summary>
		/// The provider type '{typeName}' did not have a static property or field named 'Instance'. 
		/// </summary>
		public static string Providers_InstanceMissing(object typeName)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("Providers_InstanceMissing", "typeName"), typeName);
		}

		/// <summary>
		/// No provider found with name '{name}'. Make sure the provider is registered in the 'APQuery' section of the application config file. 
		/// </summary>
		public static string Providers_NoProviderFound(object name)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("Providers_NoProviderFound", "name"), name);
		}

		/// <summary>
		/// The 'Instance' member of the provider type '{typeName}' did not return an object that inherits from '{baseTypeName}'.
		/// </summary>
		public static string Providers_NotDataStoreProvider(object typeName, object baseTypeName)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("Providers_NotDataStoreProvider", "typeName", "baseTypeName"), typeName, baseTypeName);
		}

		/// <summary>
		/// No default provider found. Make sure the provider is registered in the 'APQuery' section of the application config file.
		/// </summary>
		public static string Providers_NoDefaultProvider
		{
			get { return GetString("Providers_NoDefaultProvider"); }
		}

		/// <summary>
		/// The specified CommandTimeout value is not valid. It must be a positive number.
		/// </summary>
		public static string Connection_InvalidCommandTimeout
		{
			get { return GetString("Connection_InvalidCommandTimeout"); }
		}

		/// <summary>
		/// The specified MaxBatchSize value is not valid. It must be a positive number.
		/// </summary>
		public static string Connection_InvalidMaxBatchSize
		{
			get { return GetString("Connection_InvalidMaxBatchSize"); }
		}

		/// <summary>
		/// Multiple relational data store configurations found. A context can only be configured to use a single data store.
		/// </summary>
		public static string Connection_MultipleDataStoresConfigured
		{
			get { return GetString("Connection_MultipleDataStoresConfigured"); }
		}

		/// <summary>
		/// No relational data stores are configured. Configure a data store using OnConfiguring or by creating an ImmutableDbContextOptions with a data store configured and passing it to the context.
		/// </summary>
		public static string Connection_NoDataStoreConfigured
		{
			get { return GetString("Connection_NoDataStoreConfigured"); }
		}

		/// <summary>
		/// Both an existing DbConnection and a connection string have been configured. When an existing DbConnection is used the connection string must be set on that connection.
		/// </summary>
		public static string Connection_ConnectionAndConnectionString
		{
			get { return GetString("Connection_ConnectionAndConnectionString"); }
		}

		/// <summary>
		/// A relational store has been configured without specifying either the DbConnection or connection string to use.
		/// </summary>
		public static string Connection_NoConnectionOrConnectionString
		{
			get { return GetString("Connection_NoConnectionOrConnectionString"); }
		}

		private static string GetString(string name, params string[] formatterNames)
		{
			var value = _resourceManager.GetString(name);

			if (formatterNames != null)
			{
				for (var i = 0; i < formatterNames.Length; i++)
				{
					value = value.Replace("{" + formatterNames[i] + "}", "{" + i + "}");
				}
			}

			return value;
		}
	}
}
