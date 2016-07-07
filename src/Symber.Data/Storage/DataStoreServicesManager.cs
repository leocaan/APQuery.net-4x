using Symber.Data.Configuration;
using Symber.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Symber.Data.Storage
{

	internal static class DataStoreServicesManager
	{

		#region [ Fields ]


		private static Dictionary<string, DataStoreProvider> providers;
		private static DataStoreProvider defaultProvider;
		private static Dictionary<string, ConnectionStringSettings> connectionStringSettings;
		private static Dictionary<string, DataStoreServices> servicesCache;


		#endregion


		#region [ Constructors ]


		static DataStoreServicesManager()
		{
			providers = new Dictionary<string, DataStoreProvider>();
			connectionStringSettings = new Dictionary<string, ConnectionStringSettings>();
			servicesCache = new Dictionary<string, DataStoreServices>();


			var section = (APQuerySection)ConfigurationManager.GetSection("APQuery");
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


		public static DataStoreServices CreateServices(string connectionStringName = null, string providerName = null)
		{
			if (connectionStringName == null)
			{
				if (connectionStringSettings.Count == 0)
				{
					throw new DataStoreException(Strings.DataStore_ConnectionStringNotFound(connectionStringName));
				}
				connectionStringName = connectionStringSettings.First().Key;
			}


			if (servicesCache.ContainsKey(connectionStringName))
				return servicesCache[connectionStringName];


			if (!connectionStringSettings.ContainsKey(connectionStringName)
				|| String.IsNullOrEmpty(connectionStringSettings[connectionStringName].ConnectionString))
				throw new DataStoreException(Strings.DataStore_ConnectionStringNotFound(connectionStringName));


			DataStoreProvider provider;

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

			var settings = connectionStringSettings[connectionStringName];
			var services = new DataStoreServices(provider, settings.ConnectionString, settings.ProviderName);


			servicesCache.Add(connectionStringName, services);


			return services;
		}


		#endregion

	}

}
