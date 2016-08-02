using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryFramework.Relational.Storage
{

	public interface IDataStoreConnection : IDisposable
	{

		#region [ Properties ]


		string ConnectionString { get; }


		DbConnection DbConnection { get; }


		DataStoreTranscation Transaction { get; }


		#endregion

	}

}
