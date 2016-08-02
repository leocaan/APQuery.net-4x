using QueryFramework.Relational.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace QueryFramework.Relational.SqlServer
{

	public class SqlServerConnection : IDataStoreConnection
	{
		public string ConnectionString
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public DbConnection DbConnection
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public DataStoreTranscation Transaction
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}

}
