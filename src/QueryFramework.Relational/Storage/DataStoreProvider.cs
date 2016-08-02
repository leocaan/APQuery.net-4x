using System;

namespace QueryFramework.Relational.Storage
{

	public abstract class DataStoreProvider
	{

		#region [ Methods ]


		public abstract DataStoreServices CreateServices(string connectionString, string factoryName);


		#endregion

	}

}
