using QueryFramework.Relational.Storage;
using System;
using System.Data.Common;

namespace QueryFramework.Relational.SqlServer
{

	public class SqlServerConnection : IRelationalConnection
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

		public RelationalTranscation Transaction
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
