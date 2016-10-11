using QueryFramework.Utilities;
using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace QueryFramework.Relational
{

   public class SqlStatementExecutor : ISqlStatementExecutor
	{

		#region [ Constructors ]


		public SqlStatementExecutor()
		{
		}


		#endregion


		#region [ Methods ]


		public virtual Task ExecuteNonQueryAsync(
			IRelationalConnection connection,
			DbTransaction transaction,
			string sql,
			CancellationToken cancellationToken = default(CancellationToken))
		{
			Check.NotNull(connection, nameof(connection));
			Check.NotNull(sql, nameof(sql));

			return ExecuteAsync(
				 connection,
				 () =>
				 {
					 var command = CreateCommand(connection, transaction, sql);

					 command.ExecuteNonQueryAsync(cancellationToken);

					 return Task.FromResult<object>(null);
				 },
				 cancellationToken);
		}


		public virtual Task<object> ExecuteScalarAsync(
			IRelationalConnection connection,
			DbTransaction transaction,
			string sql,
			CancellationToken cancellationToken = default(CancellationToken))
		{
			Check.NotNull(connection, nameof(connection));
			Check.NotNull(sql, nameof(sql));

			return ExecuteAsync(
				connection,
				() =>
				{
					var command = CreateCommand(connection, transaction, sql);

					return command.ExecuteScalarAsync(cancellationToken);
				},
				cancellationToken);
		}


		public virtual async Task<object> ExecuteAsync(
			IRelationalConnection connection,
			Func<Task<object>> action,
			CancellationToken cancellationToken = default(CancellationToken))
		{
			Check.NotNull(connection, nameof(connection));

			var connectionWasOpen = connection.DbConnection.State == ConnectionState.Open;
			if (!connectionWasOpen)
			{
				await connection.OpenAsync(cancellationToken);
			}

			try
			{
				return await action();
			}
			finally
			{
				if (!connectionWasOpen)
				{
					connection.Close();
				}
			}
		}


		public virtual void ExecuteNonQuery(
			 IRelationalConnection connection,
			 DbTransaction transaction,
			 string sql)
		{
			Check.NotNull(connection, nameof(connection));
			Check.NotNull(sql, nameof(sql));

			Execute(
				 connection,
				 () =>
				 {
					 var command = CreateCommand(connection, transaction, sql);

					 command.ExecuteNonQuery();

					 return null;
				 });
		}


		public virtual object ExecuteScalar(
			 IRelationalConnection connection,
			 DbTransaction transaction,
			 string sql)
		{
			Check.NotNull(connection, nameof(connection));
			Check.NotNull(sql, nameof(sql));

			return Execute(
				 connection,
				 () =>
				 {
					 var command = CreateCommand(connection, transaction, sql);

					 return command.ExecuteScalar();
				 });
		}


		public virtual object Execute(
			 IRelationalConnection connection,
			 Func<object> action)
		{
			Check.NotNull(connection, nameof(connection));

			// TODO Deal with suppressing transactions etc.

			var connectionWasOpen = connection.DbConnection.State == ConnectionState.Open;
			if (!connectionWasOpen)
			{
				connection.Open();
			}

			try
			{
				return action();
			}
			finally
			{
				if (!connectionWasOpen)
				{
					connection.Close();
				}
			}
		}


		protected virtual DbCommand CreateCommand(
			 IRelationalConnection connection,
			 DbTransaction transaction,
			 string sql)
		{
			var command = connection.DbConnection.CreateCommand();
			command.CommandText = sql;
			command.Transaction = transaction;

			if (connection.CommandTimeout != null)
			{
				command.CommandTimeout = (int)connection.CommandTimeout;
			}

			return command;
		}


		#endregion

	}

}
