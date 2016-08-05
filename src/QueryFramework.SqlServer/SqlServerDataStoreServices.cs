using QueryFramework.Infrastructure;
using QueryFramework.Relational;
using QueryFramework.Relational.SqlGen;

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
			=> new SqlServerSqlGenerator();


		public override IRelationalConnection RelationalConnection
			=> new SqlServerConnection(_options);


		#endregion

	}

}
