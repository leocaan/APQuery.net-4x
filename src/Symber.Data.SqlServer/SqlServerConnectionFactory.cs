using Symber.Data.Storage;
using System.Data.Common;

namespace Symber.Data.SqlServer
{

	public class SqlServerConnectionFactory : ConnectionFactory
	{

		#region [ Fields ]
		 

		private DbProviderFactory _factory = null;
		private string _connectionString;


		#endregion


		#region [ Constructors ]


		public SqlServerConnectionFactory(DbProviderFactory factory, string connectionString)
		{
			_factory = factory;
			_connectionString = connectionString;
		}


		#endregion


		#region [ Override Implementation of ConnectionFactory ]


		public override DbConnection CreateConnection()
		{
			DbConnection connection = _factory.CreateConnection();
			connection.ConnectionString = _connectionString;
			connection.Open();
			return connection;
		}


		#endregion

	}

}
