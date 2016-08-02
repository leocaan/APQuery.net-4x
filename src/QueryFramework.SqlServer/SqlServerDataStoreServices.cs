using QueryFramework.Relational.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryFramework.Relational.SqlServer
{

	public class SqlServerDataStoreServices : DataStoreServices
	{

		#region [ Constructors ]


		public SqlServerDataStoreServices(string connectionString, string factoryName)
			: base(connectionString, factoryName)
		{
		}


		#endregion


		#region [ Properties ]


		public override ISqlGenerator SqlGenerator => new SqlServerSqlGenerator();


		public override IDataStoreConnection RelationalConnection => new SqlServerConnection();


		#endregion

	}

}
