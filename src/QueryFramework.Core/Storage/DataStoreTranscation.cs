using System;

namespace QueryFramework.Storage
{

	public abstract class DataStoreTranscation : IDisposable
	{

		#region [ Properties ]


		public abstract void Commit();


		public abstract void Rollback();


		public abstract void Dispose();


		#endregion

	}

}
