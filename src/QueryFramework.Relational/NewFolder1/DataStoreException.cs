using System;

namespace Symber.Data.Storage
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
