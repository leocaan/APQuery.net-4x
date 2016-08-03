using QueryFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryFramework.Infrastructure
{

	public class QueryOptions<TContext> : QueryOptions
	// todo: where TContext : DbContext
	{

		#region [ Constructors ]


		public QueryOptions()
			: base(new Dictionary<Type, IQueryOptionsExtension>())
		{
		}


		public QueryOptions(IReadOnlyDictionary<Type, IQueryOptionsExtension> extensions)
			: base(extensions)
		{
		}


		#endregion


		#region [ Methods ]


		public override QueryOptions WithExtension<TExtension>(TExtension extension)
		{
			Check.NotNull(extension, nameof(extension));

			var extensions = Extensions.ToDictionary(p => p.GetType(), p => p);
			extensions[typeof(TExtension)] = extension;

			return new QueryOptions<TContext>(extensions);
		}


		#endregion

	}

}
