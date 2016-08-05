using QueryFramework.Infrastructure;
using QueryFramework.Utilities;

namespace QueryFramework.Storage
{

	public abstract class DataStoreServices : IDataStoreServices
	{

		#region [ Constructors ]


		protected DataStoreServices(IDataStoreOptions options)
		{
			Check.NotNull(options, nameof(options));
		}


		#endregion


		#region [ Properties ]


		public abstract IDataStoreConnection Connection { get; }


		#endregion

	}

}
