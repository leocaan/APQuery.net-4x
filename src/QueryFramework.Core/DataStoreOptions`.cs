using QueryFramework.Infrastructure;
using QueryFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QueryFramework
{

	public class DataStoreOptions<TContext> : DataStoreOptions
		where TContext : DbContext
	{

		#region [ Constructors ]


		public DataStoreOptions()
			: base(new Dictionary<Type, IDataStoreOptionsExtension>())
		{
		}


		public DataStoreOptions(IReadOnlyDictionary<Type, IDataStoreOptionsExtension> extensions)
			: base(extensions)
		{
		}


		#endregion


		#region [ Methods ]


		public override DataStoreOptions WithExtension<TExtension>(TExtension extension)
		{
			Check.NotNull(extension, nameof(extension));

			var extensions = Extensions.ToDictionary(p => p.GetType(), p => p);
			extensions[typeof(TExtension)] = extension;

			return new DataStoreOptions<TContext>(extensions);
		}


		#endregion

	}

}
