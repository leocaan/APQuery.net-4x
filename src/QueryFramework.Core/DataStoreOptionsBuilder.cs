using QueryFramework.Infrastructure;
using QueryFramework.Utilities;
using System.Linq;

namespace QueryFramework
{

	public class DataStoreOptionsBuilder : IDataStoreOptionsBuilderExtender
	{

		#region [ Fields ]


		private DataStoreOptions _options;


		#endregion


		#region [ Constructors ]


		public DataStoreOptionsBuilder()
				: this(new DataStoreOptions<DbContext>())
		{
		}


		public DataStoreOptionsBuilder(DataStoreOptions options)
		{
			Check.NotNull(options, nameof(options));

			_options = options;
		}


		#endregion


		#region [ Properties ]


		public virtual DataStoreOptions Options
			=> _options;


		public virtual bool IsConfigured
			=> _options.Extensions.Any();


		#endregion


		#region [ Methods ]


		void IDataStoreOptionsBuilderExtender.AddOrUpdateExtension<TExtension>(TExtension extension)
		{
			Check.NotNull(extension, nameof(extension));

			_options = _options.WithExtension(extension);
		}


		#endregion

	}

}
