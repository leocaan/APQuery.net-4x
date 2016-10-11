using QueryFramework.Infrastructure;
using QueryFramework.Relational;

namespace QueryFramework.SqlServer
{

	public class SqlServerOptionsBuilder : RelationalOptionsBuilder
	{

		#region [ Constructors ]


		public SqlServerOptionsBuilder(DataStoreOptionsBuilder optionsBuilder)
				: base(optionsBuilder)
		{
		}


		#endregion


		#region [ Methods ]


		public virtual SqlServerOptionsBuilder MaxBatchSize(int maxBatchSize)
		{
			var extension = new SqlServerOptionsExtension(OptionsBuilder.Options.GetExtension<SqlServerOptionsExtension>())
			{
				MaxBatchSize = maxBatchSize
			};

			((IDataStoreOptionsBuilderExtender)OptionsBuilder).AddOrUpdateExtension(extension);

			return this;
		}

		public virtual SqlServerOptionsBuilder CommandTimeout(int? commandTimeout)
		{
			var extension = new SqlServerOptionsExtension(OptionsBuilder.Options.GetExtension<SqlServerOptionsExtension>())
			{
				CommandTimeout = commandTimeout
			};

			((IDataStoreOptionsBuilderExtender)OptionsBuilder).AddOrUpdateExtension(extension);

			return this;
		}


		public virtual SqlServerOptionsBuilder SuppressAmbientTransactionWarning()
		{
			var extension = new SqlServerOptionsExtension(OptionsBuilder.Options.GetExtension<SqlServerOptionsExtension>())
			{
				ThrowOnAmbientTransaction = false
			};

			((IDataStoreOptionsBuilderExtender)OptionsBuilder).AddOrUpdateExtension(extension);

			return this;
		}


		#endregion

	}

}
