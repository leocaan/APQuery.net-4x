using QueryFramework.Infrastructure;
using QueryFramework.Utilities;
using System;
using System.Data;
using System.Data.Common;

namespace QueryFramework.Relational
{

	public abstract class RelationalConnection : IRelationalConnection
	{

		#region [ Fields ]


		private readonly string _connectionString;
		private readonly LazyRef<DbConnection> _connection;
		private readonly bool _connectionOwned;
		private int _openedCount;
		private int? _commandTimeout;


		#endregion


		#region [ Constructors ]


		protected RelationalConnection(IDataStoreOptions options)
		{
			Check.NotNull(options, nameof(options));

			var storeConfig = RelationalOptionsExtension.Extract(options);

			_commandTimeout = storeConfig.CommandTimeout;

			if (storeConfig.Connection != null)
			{
				if (!string.IsNullOrWhiteSpace(storeConfig.ConnectionString))
				{
					throw new InvalidOperationException(Strings.Connection_ConnectionAndConnectionString);
				}

				_connection = new LazyRef<DbConnection>(() => storeConfig.Connection);
				_connectionOwned = false;
				_openedCount = storeConfig.Connection.State == ConnectionState.Open ? 1 : 0;
			}
			else if (!string.IsNullOrWhiteSpace(storeConfig.ConnectionString))
			{
				_connectionString = storeConfig.ConnectionString;
				_connection = new LazyRef<DbConnection>(CreateDbConnection);
				_connectionOwned = true;
			}
			else
			{
				throw new InvalidOperationException(Strings.Connection_NoConnectionOrConnectionString);
			}
		}


		#endregion


		#region [ Properties ]


		public virtual string ConnectionString
			=> _connectionString ?? _connection.Value.ConnectionString;


		public virtual DbConnection DbConnection
			=> _connection.Value;


		public virtual RelationalTranscation Transaction { get; protected set; }


		public virtual int? CommandTimeout
		{
			get { return _commandTimeout; }
			set
			{
				if (value.HasValue && value < 0)
				{
					throw new ArgumentException(Strings.Connection_InvalidCommandTimeout);
				}

				_commandTimeout = value;
			}
		}


		#endregion


		#region [ Methods ]


		protected abstract DbConnection CreateDbConnection();


		#endregion


		#region [ Implementation of IDisposable ]


		public virtual void Dispose()
		{
			Transaction?.Dispose();

			if (_connectionOwned && _connection.HasValue)
			{
				_connection.Value.Dispose();
				_connection.Reset(CreateDbConnection);
				_openedCount = 0;
			}
		}


		#endregion

	}

}
