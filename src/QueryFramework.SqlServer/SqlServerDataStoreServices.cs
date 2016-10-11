using QueryFramework.Infrastructure;
using QueryFramework.Query.Sql;
using QueryFramework.Relational;

namespace QueryFramework.SqlServer
{

	public class SqlServerDataStoreServices : RelationalDataStoreServices
	{

		#region [ Fields ]


		private IDataStoreOptions _options;


		#endregion


		#region [ Constructors ]


		public SqlServerDataStoreServices(IDataStoreOptions options)
			: base(options)
		{
			_options = options;
		}


		#endregion


		#region [ Properties ]


		public override ISqlGenerator SqlGenerator
			=> new SqlServerSqlGenerator(null, null, null, null, null); // todo


		public override IRelationalConnection RelationalConnection
			=> new SqlServerConnection(_options);


		#endregion

	}

}
