using Symber.Data.Utilities;
using System;
using System.Reflection;

namespace Symber.Data.Storage
{

	internal class DataStoreProviderFactory
	{

		public DataStoreProvider GetInstance(string providerTypeName)
		{
			Check.NotEmpty(providerTypeName, nameof(providerTypeName));

			var providerType = Type.GetType(providerTypeName, throwOnError: false);

			return providerType == null ? null : GetInstance(providerType);
		}


		private static DataStoreProvider GetInstance(Type providerType)
		{
			Check.NotNull(providerType, nameof(providerType));


			const BindingFlags bindingFlags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

			var instanceMember = providerType.GetStaticProperty("Instance")
										?? (MemberInfo)providerType.GetField("Instance", bindingFlags);
			if (instanceMember == null)
			{
				throw new InvalidOperationException(Strings.Providers_InstanceMissing(providerType.AssemblyQualifiedName));
			}

			var providerInstance = instanceMember.GetValue() as DataStoreProvider;
			if (providerInstance == null)
			{
				throw new InvalidOperationException(Strings.Providers_NotDataStoreProvider(providerType.AssemblyQualifiedName, typeof(DataStoreProvider).AssemblyQualifiedName));
			}

			return providerInstance;
		}

	}

}
