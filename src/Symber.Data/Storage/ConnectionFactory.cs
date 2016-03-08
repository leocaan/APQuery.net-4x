using System.Data.Common;

namespace Symber.Data.Storage
{
	public abstract class ConnectionFactory
	{

		public ConnectionFactory()
		{

		}

		public abstract DbConnection CreateConnection();

	}
}
