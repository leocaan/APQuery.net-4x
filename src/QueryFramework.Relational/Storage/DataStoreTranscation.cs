using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryFramework.Relational.Storage
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
