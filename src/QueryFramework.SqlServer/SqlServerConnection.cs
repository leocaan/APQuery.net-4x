using QueryFramework.Infrastructure;
using QueryFramework.Relational;
using System.Data.Common;
using System.Data.SqlClient;

namespace QueryFramework.SqlServer
{

	public class SqlServerConnection : RelationalConnection, ISqlServerConnection
	{

		#region [ Constructors ]


		public SqlServerConnection(IDataStoreOptions options)
			: base(options)
		{
		}


		#endregion


		#region [ Properties ]


		public override bool IsMultipleActiveResultSetsEnabled
		 => new SqlConnectionStringBuilder(ConnectionString).MultipleActiveResultSets;


		#endregion


		#region [ Methods ]


		protected override DbConnection CreateDbConnection()
			=> new SqlConnection(ConnectionString);


		public virtual ISqlServerConnection CreateMasterConnection()
		{
			var builder = new SqlConnectionStringBuilder
			{
				ConnectionString = ConnectionString,
				InitialCatalog = "master"
			};


			// TODO use clone connection method once implimented see #1406

			var optionsBuilder = new DataStoreOptionsBuilder();
			optionsBuilder
				.UseSqlServer(builder.ConnectionString)
				.CommandTimeout(CommandTimeout);

			return new SqlServerConnection(optionsBuilder.Options);
		}



		#endregion

	}

}
