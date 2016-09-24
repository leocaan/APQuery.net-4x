using QueryFramework.Relational.Configuration;
using QueryFramework.Storage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace QueryFramework.Relational.Storage
{

	internal static class DataStoreServicesManager
	{

		#region [ Fields ]


		private static Dictionary<string, DataStoreProvider> providers;
		private static DataStoreProvider defaultProvider;
		private static Dictionary<string, ConnectionStringSettings> connectionStringSettings;


		#endregion


		#region [ Constructors ]


		static DataStoreServicesManager()
		{
			providers = new Dictionary<string, DataStoreProvider>();
			connectionStringSettings = new Dictionary<string, ConnectionStringSettings>();


			var section = (QueryFrameworkSection)ConfigurationManager.GetSection("queryFramework");


			DataStoreProviderFactory factory = new DataStoreProviderFactory();
			foreach (var name in section.Providers.AllKeys)
			{
				var item = section.Providers[name];
				var provider = factory.GetInstance(item.Type);

				if (provider == null)
				{
					throw new DataStoreException(Strings.Providers_LoadTypeError(item.Type));
				}

				providers.Add(item.Name, provider);
			}


			if (providers.Count > 0)
			{
				if (section.DefaultProvider == null)
				{
					defaultProvider = providers.First().Value;
				}
				else if (providers.ContainsKey(section.DefaultProvider))
				{
					defaultProvider = providers[section.DefaultProvider];
				}
				else
				{
					throw new DataStoreException(Strings.Providers_NoProviderFound(section.DefaultProvider));
				}
			}


			for (int i = 0, j = ConfigurationManager.ConnectionStrings.Count; i < j; i++)
			{
				var item = ConfigurationManager.ConnectionStrings[i];
				connectionStringSettings.Add(item.Name, item);
			}
		}


		#endregion


		#region [ Methods ]


		public static RelationalDataStoreServices CreateServices(string nameOrConnectionString = null, string providerName = null)
		{
			string name = null;
			string connectionString = null;
			string factoryName = null;
			DataStoreProvider provider;


			// Get connectionString

			if (nameOrConnectionString != null)
			{
				if (nameOrConnectionString.StartsWith("name=", StringComparison.InvariantCulture))
				{
					name = nameOrConnectionString.Substring(5);
				}
				else
				{
					connectionString = nameOrConnectionString;
				}
			}

			if (connectionString == null)
			{
				ConnectionStringSettings settings = null;

				if (name != null)
				{
					if (connectionStringSettings.ContainsKey(name))
					{
						settings = connectionStringSettings[name];
					}
				}
				else if (connectionStringSettings.Count > 0)
				{
					settings = connectionStringSettings.First().Value;
				}

				if (settings != null)
				{
					connectionString = settings.ConnectionString;
					factoryName = settings.ProviderName;
				}
			}


			if (connectionString == null || String.IsNullOrEmpty(connectionString))
			{
				throw new DataStoreException(Strings.DataStore_ConnectionStringNotFound(nameOrConnectionString));
			}


			// Get DataStoreProvider

			if (providerName == null)
			{
				if (defaultProvider == null)
					throw new DataStoreException(Strings.Providers_NoDefaultProvider);

				provider = defaultProvider;
			}
			else
			{
				if (!providers.ContainsKey(providerName))
					throw new DataStoreException(Strings.Providers_NoProviderFound(providerName));

				provider = providers[providerName];
			}


			return provider.CreateServices(connectionString, factoryName);
		}


		#endregion

	}

}
