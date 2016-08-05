using QueryFramework.Infrastructure;
using QueryFramework.Relational;
using System.Data.Common;
using System.Data.SqlClient;

namespace QueryFramework.SqlServer
{

	public class SqlServerConnection : RelationalConnection
	{

		#region [ Constructors ]


		public SqlServerConnection(IDataStoreOptions options)
			: base(options)
		{

		}


		#endregion


		#region [ Methods ]


		protected override DbConnection CreateDbConnection()
			=> new SqlConnection(ConnectionString);


		#endregion

	}

}
