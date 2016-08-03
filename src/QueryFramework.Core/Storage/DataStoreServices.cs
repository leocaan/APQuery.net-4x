using QueryFramework.Infrastructure;
using QueryFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryFramework.Storage
{

	public abstract class DataStoreServices : IDataStoreServices
	{

		#region [ Constructors ]


		protected DataStoreServices(IQueryOptions options)
		{
			Check.NotNull(options, nameof(options));
		}


		#endregion


		#region [ Properties ]


		public abstract IDataStoreConnection Connection { get; }


		#endregion

	}

}
