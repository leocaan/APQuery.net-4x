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
			var opts = new DataStoreOptions<DbContext>();
			var builder = new DataStoreOptionsBuilder(opts);

			var sqlbuilder = builder
				.UseSqlServer("abc")
				.MaxBatchSize(10);

			var services = new SqlServerDataStoreServices(builder.Options);
			var conn = services.RelationalConnection;

			//QueryOptionsBuilder baseBuilder = new QueryOptionsBuilder(new QueryOptions<SqlServerOptionsExtension>());

			//SqlServerQueryOptionsBuilder builder = new SqlServerQueryOptionsBuilder(baseBuilder);
			//builder
			//	.MaxBatchSize(10)
			//	.CommandTimeout(10);


			//var type = typeof(Strings);
			//var rns = type.Assembly.GetManifestResourceNames();

			//ResourceManager _resourceManager
			//= new ResourceManager("QueryFramework.Core.Strings", typeof(Strings).GetTypeInfo().Assembly);
			//_resourceManager.GetString("Utilities_ArgumentIsEmpty");

			StorageTest.TestServices();
		}

	}

}
