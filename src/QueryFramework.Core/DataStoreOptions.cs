using QueryFramework.Infrastructure;
using QueryFramework.Utilities;
using System;
using System.Collections.Generic;

namespace QueryFramework
{

	public abstract class DataStoreOptions : IDataStoreOptions
	{

		#region [ Fields ]


		private readonly IReadOnlyDictionary<Type, IDataStoreOptionsExtension> _extensions;


		#endregion


		#region [ Constructors ]


		protected DataStoreOptions(IReadOnlyDictionary<Type, IDataStoreOptionsExtension> extensions)
		{
			Check.NotNull(extensions, nameof(extensions));

			_extensions = extensions;
		}


		#endregion


		#region [ Properties ]


		public virtual IEnumerable<IDataStoreOptionsExtension> Extensions
			=> _extensions.Values;


		#endregion


		#region [ Methods ]


		public virtual TExtension FindExtension<TExtension>()
			where TExtension : class, IDataStoreOptionsExtension
		{
			IDataStoreOptionsExtension extension;

			return _extensions.TryGetValue(typeof(TExtension), out extension) ? (TExtension)extension : null;
		}


		public virtual TExtension GetExtension<TExtension>()
			where TExtension : class, IDataStoreOptionsExtension
		{
			var extension = FindExtension<TExtension>();

			if (extension == null)
			{
				throw new InvalidOperationException(Strings.Options_ExtensionNotFound(typeof(TExtension).Name));
			}

			return extension;
		}


		public abstract DataStoreOptions WithExtension<TExtension>(TExtension extension)
			where TExtension : class, IDataStoreOptionsExtension;


		#endregion

	}

}
