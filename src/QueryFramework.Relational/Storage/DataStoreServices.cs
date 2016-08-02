using QueryFramework.Utilities;

namespace QueryFramework.Relational.Storage
{

	public abstract class DataStoreServices
	{

		#region [ Constructors ]


		public DataStoreServices(string connectionString, string factoryName)
		{
			Check.NotEmpty(connectionString, nameof(connectionString));
			Check.NullButNotEmpty(factoryName, nameof(factoryName));
		}


		#endregion


		#region [ Properties ]


		public abstract ISqlGenerator SqlGenerator { get; }


		public abstract IDataStoreConnection RelationalConnection { get; }


		#endregion

	}

}
