using Symber.Data.Configuration;
using System.Configuration;

namespace Symber.Data.Storage
{
	public class StorageTest
	{
		public static void TestServices()
		{
			var section = (APQuerySection)ConfigurationManager.GetSection("APQuery");

			var provider = new DataStoreProviderFactory().GetInstance(section.Providers[0].Type);
		}
	}
}
