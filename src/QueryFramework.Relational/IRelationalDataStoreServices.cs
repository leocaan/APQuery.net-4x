using QueryFramework.Relational.SqlGen;
using QueryFramework.Storage;

namespace QueryFramework.Relational
{

	public interface IRelationalDataStoreServices : IDataStoreServices
	{

		IRelationalConnection RelationalConnection { get; }


		ISqlGenerator SqlGenerator { get; }

	}

}
