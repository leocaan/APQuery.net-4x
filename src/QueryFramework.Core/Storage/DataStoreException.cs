using System;

namespace QueryFramework.Storage
{

	public class DataStoreException : Exception
	{

		#region [ Constructors ]


		public DataStoreException()
		{
		}


		public DataStoreException(string message)
				: base(message)
		{
		}


		public DataStoreException(string message, Exception innerException)
				: base(message, innerException)
		{
		}


		#endregion

	}

}
