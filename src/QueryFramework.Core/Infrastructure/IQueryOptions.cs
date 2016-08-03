using System.Collections.Generic;

namespace QueryFramework.Infrastructure
{

	public interface IQueryOptions
	{

		IEnumerable<IQueryOptionsExtension> Extensions { get; }


		TExtension FindExtension<TExtension>() where TExtension : class, IQueryOptionsExtension;

	}

}
