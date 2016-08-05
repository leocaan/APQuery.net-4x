using QueryFramework.Infrastructure;
using QueryFramework.Relational.SqlGen;
using QueryFramework.Storage;

namespace QueryFramework.Relational
{

	public abstract class RelationalDataStoreServices : DataStoreServices, IRelationalDataStoreServices
	{

		#region [ Constructors ]


		protected RelationalDataStoreServices(IDataStoreOptions options)
			: base(options)
		{
		}


		#endregion


		#region [ Properties ]


		public abstract ISqlGenerator SqlGenerator { get; }


		public abstract IRelationalConnection RelationalConnection { get; }


		public override IDataStoreConnection Connection
			=> RelationalConnection;


		#endregion

	}

}
