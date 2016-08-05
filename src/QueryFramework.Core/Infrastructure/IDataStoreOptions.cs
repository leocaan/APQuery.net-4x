using System.Collections.Generic;

namespace QueryFramework.Infrastructure
{

	public interface IDataStoreOptions
	{

		IEnumerable<IDataStoreOptionsExtension> Extensions { get; }


		TExtension FindExtension<TExtension>() where TExtension : class, IDataStoreOptionsExtension;

	}

}
