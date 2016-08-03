using QueryFramework.Relational.SqlGen;
using QueryFramework.Relational.Storage;

namespace QueryFramework.Relational.SqlServer
{

	public class SqlServerDataStoreServices : RelationalDataStoreServices
	{

		#region [ Constructors ]


		public SqlServerDataStoreServices(string connectionString, string factoryName)
			: base(connectionString, factoryName)
		{
		}


		#endregion


		#region [ Properties ]


		public override ISqlGenerator SqlGenerator => new SqlServerSqlGenerator();


		public override IRelationalConnection RelationalConnection => new SqlServerConnection();


		#endregion

	}

}
