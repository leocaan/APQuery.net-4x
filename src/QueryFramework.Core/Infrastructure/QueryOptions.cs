using QueryFramework.Utilities;
using System;
using System.Collections.Generic;

namespace QueryFramework.Infrastructure
{

	public abstract class QueryOptions : IQueryOptions
	{

		#region [ Fields ]


		private readonly IReadOnlyDictionary<Type, IQueryOptionsExtension> _extensions;


		#endregion


		#region [ Constructors ]


		protected QueryOptions(IReadOnlyDictionary<Type, IQueryOptionsExtension> extensions)
		{
			Check.NotNull(extensions, nameof(extensions));

			_extensions = extensions;
		}


		#endregion


		#region [ Properties ]


		public virtual IEnumerable<IQueryOptionsExtension> Extensions
			=> _extensions.Values;


		#endregion


		#region [ Methods ]


		public virtual TExtension FindExtension<TExtension>()
			where TExtension : class, IQueryOptionsExtension
		{
			IQueryOptionsExtension extension;

			return _extensions.TryGetValue(typeof(TExtension), out extension) ? (TExtension)extension : null;
		}


		public virtual TExtension GetExtension<TExtension>()
			where TExtension : class, IQueryOptionsExtension
		{
			var extension = FindExtension<TExtension>();

			if (extension == null)
			{
				throw new InvalidOperationException(Strings.Options_ExtensionNotFound(typeof(TExtension).Name));
			}

			return extension;
		}


		public abstract QueryOptions WithExtension<TExtension>(TExtension extension)
			where TExtension : class, IQueryOptionsExtension;


		#endregion

	}

}
