using QueryFramework.Infrastructure;
using QueryFramework.Relational.SqlGen;
using QueryFramework.Storage;
using QueryFramework.Utilities;

namespace QueryFramework.Relational
{

	public abstract class RelationalDataStoreServices : DataStoreServices, IRelationalDataStoreServices
	{

		#region [ Constructors ]


		protected RelationalDataStoreServices(IQueryOptions options)
			: base(options)
		{
		}


		#endregion


		#region [ Properties ]


		public abstract ISqlGenerator SqlGenerator { get; }


		public abstract IRelationalConnection RelationalConnection { get; }


		#endregion

	}

}
