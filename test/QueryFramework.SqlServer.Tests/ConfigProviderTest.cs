using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueryFramework.Relational;

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
		}


	//[TestMethod]
	//public static void TestServices()
	//{
	//	var services = DataStoreServicesManager.CreateServices();

	//	var conn = services.RelationalConnection;
	//	var cmd = conn.DbConnection.CreateCommand();
	//	cmd.CommandText = "select * from department";
	//	conn.Open();



	//	using (var r = cmd.ExecuteReader())
	//	{
	//		while (r.Read())
	//		{
	//			object[] os = new object[10];
	//			r.GetValues(os);
	//		}
	//	}

	//}

}

}
