using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueryFramework.Relational.Storage;

namespace QueryFramework.SqlServer.Tests
{

	[TestClass]
	public class ConfigProviderTest
	{

		[TestMethod]
		public void LunchProvider()
		{
			//var opts = new DataStoreOptions<DbContext>();
			//var builder = new DataStoreOptionsBuilder(opts);

			//var sqlbuilder = builder
			//	.UseSqlServer("abc")
			//	.MaxBatchSize(10);

			//var services = new SqlServerDataStoreServices(builder.Options);
			//var conn = services.RelationalConnection;


			StorageTest.TestServices();
		}

	}

}
