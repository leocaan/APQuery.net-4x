using QueryFramework.Infrastructure;
using QueryFramework.SqlServer;
using QueryFramework.Utilities;

namespace QueryFramework
{

	public static class SqlServerOptionsExtensions
	{

		public static SqlServerOptionsBuilder UseSqlServer(this DataStoreOptionsBuilder optionsBuilder, string connectionString)
		{
			Check.NotNull(optionsBuilder, nameof(optionsBuilder));
			Check.NotEmpty(connectionString, nameof(connectionString));

			var extension = GetOrCreateExtension(optionsBuilder);

			extension.ConnectionString = connectionString;

			((IDataStoreOptionsBuilderExtender)optionsBuilder).AddOrUpdateExtension(extension);

			return new SqlServerOptionsBuilder(optionsBuilder);
		}


		private static SqlServerOptionsExtension GetOrCreateExtension(DataStoreOptionsBuilder optionsBuilder)
		{
			var existing = optionsBuilder.Options.FindExtension<SqlServerOptionsExtension>();
			return existing != null
				 ? new SqlServerOptionsExtension(existing)
				 : new SqlServerOptionsExtension();
		}

	}

}
