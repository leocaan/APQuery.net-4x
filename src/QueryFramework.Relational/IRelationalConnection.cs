using QueryFramework.Storage;
using System;
using System.Data.Common;

namespace QueryFramework.Relational
{

	public interface IRelationalConnection : IDataStoreConnection, IDisposable
	{

		#region [ Properties ]


		string ConnectionString { get; }


		DbConnection DbConnection { get; }


		RelationalTranscation Transaction { get; }


		int? CommandTimeout { get; set; }


		#endregion

	}

}
