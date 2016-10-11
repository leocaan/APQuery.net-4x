// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Utilities;
using System.Collections.Generic;

namespace QueryFramework.Storage.Internal
{

   public class RelationalCommand : IRelationalCommand
   {

      #region [ Constructors ]


      public RelationalCommand(string commandText, IReadOnlyList<IRelationalParameter> parameters)
      {
         Check.NotNull(commandText, nameof(commandText));
         Check.NotNull(parameters, nameof(parameters));


         CommandText = commandText;
         Parameters = parameters;
      }


      #endregion


      #region [ Properties ]


      public virtual string CommandText { get; }


      public virtual IReadOnlyList<IRelationalParameter> Parameters { get; }


      #endregion


      #region [ Methods ]

      //todo
      //public virtual int ExecuteNonQuery(
      //	 IRelationalConnection connection,
      //	 IReadOnlyDictionary<string, object> parameterValues = null,
      //	 bool manageConnection = true)
      //	 => (int)Execute(
      //		  Check.NotNull(connection, nameof(connection)),
      //		  nameof(ExecuteNonQuery),
      //		  parameterValues,
      //		  openConnection: manageConnection,
      //		  closeConnection: manageConnection);

      //public virtual Task<int> ExecuteNonQueryAsync(
      //	 IRelationalConnection connection,
      //	 IReadOnlyDictionary<string, object> parameterValues = null,
      //	 bool manageConnection = true,
      //	 CancellationToken cancellationToken = default(CancellationToken))
      //	 => ExecuteAsync(
      //		  Check.NotNull(connection, nameof(connection)),
      //		  nameof(ExecuteNonQuery),
      //		  parameterValues,
      //		  openConnection: manageConnection,
      //		  closeConnection: manageConnection,
      //		  cancellationToken: cancellationToken).Cast<object, int>();

      //public virtual object ExecuteScalar(
      //	 IRelationalConnection connection,
      //	 IReadOnlyDictionary<string, object> parameterValues = null,
      //	 bool manageConnection = true)
      //	 => Execute(
      //		  Check.NotNull(connection, nameof(connection)),
      //		  nameof(ExecuteScalar),
      //		  parameterValues,
      //		  openConnection: manageConnection,
      //		  closeConnection: manageConnection);

      //public virtual Task<object> ExecuteScalarAsync(
      //	 IRelationalConnection connection,
      //	 IReadOnlyDictionary<string, object> parameterValues = null,
      //	 bool manageConnection = true,
      //	 CancellationToken cancellationToken = default(CancellationToken))
      //	 => ExecuteAsync(
      //		  Check.NotNull(connection, nameof(connection)),
      //		  nameof(ExecuteScalar),
      //		  parameterValues,
      //		  openConnection: manageConnection,
      //		  closeConnection: manageConnection,
      //		  cancellationToken: cancellationToken);

      //public virtual RelationalDataReader ExecuteReader(
      //	 IRelationalConnection connection,
      //	 IReadOnlyDictionary<string, object> parameterValues = null,
      //	 bool manageConnection = true)
      //	 => (RelationalDataReader)Execute(
      //		  Check.NotNull(connection, nameof(connection)),
      //		  nameof(ExecuteReader),
      //		  parameterValues,
      //		  openConnection: manageConnection,
      //		  closeConnection: false);

      //public virtual Task<RelationalDataReader> ExecuteReaderAsync(
      //	 IRelationalConnection connection,
      //	 IReadOnlyDictionary<string, object> parameterValues = null,
      //	 bool manageConnection = true,
      //	 CancellationToken cancellationToken = default(CancellationToken))
      //	 => ExecuteAsync(
      //		  Check.NotNull(connection, nameof(connection)),
      //		  nameof(ExecuteReader),
      //		  parameterValues,
      //		  openConnection: manageConnection,
      //		  closeConnection: false,
      //		  cancellationToken: cancellationToken).Cast<object, RelationalDataReader>();

      //protected virtual object Execute(
      //	 [NotNull] IRelationalConnection connection,
      //	 [NotNull] string executeMethod,
      //	 [CanBeNull] IReadOnlyDictionary<string, object> parameterValues,
      //	 bool openConnection,
      //	 bool closeConnection)
      //{
      //	Check.NotNull(connection, nameof(connection));
      //	Check.NotEmpty(executeMethod, nameof(executeMethod));

      //	var dbCommand = CreateCommand(connection, parameterValues);

      //	object result;

      //	if (openConnection)
      //	{
      //		connection.Open();
      //	}

      //	var startTimestamp = Stopwatch.GetTimestamp();
      //	var instanceId = Guid.NewGuid();

      //	DiagnosticSource.WriteCommandBefore(
      //		 dbCommand,
      //		 executeMethod,
      //		 instanceId,
      //		 startTimestamp,
      //		 async: false);

      //	try
      //	{
      //		switch (executeMethod)
      //		{
      //			case nameof(ExecuteNonQuery):
      //				{
      //					using (dbCommand)
      //					{
      //						result = dbCommand.ExecuteNonQuery();
      //					}

      //					break;
      //				}
      //			case nameof(ExecuteScalar):
      //				{
      //					using (dbCommand)
      //					{
      //						result = dbCommand.ExecuteScalar();
      //					}

      //					break;
      //				}
      //			case nameof(ExecuteReader):
      //				{
      //					try
      //					{
      //						result
      //							 = new RelationalDataReader(
      //								  openConnection ? connection : null,
      //								  dbCommand,
      //								  dbCommand.ExecuteReader());
      //					}
      //					catch
      //					{
      //						dbCommand.Dispose();

      //						throw;
      //					}

      //					break;
      //				}
      //			default:
      //				{
      //					throw new NotSupportedException();
      //				}
      //		}

      //		var currentTimestamp = Stopwatch.GetTimestamp();

      //		Logger.LogCommandExecuted(dbCommand, startTimestamp, currentTimestamp);

      //		DiagnosticSource.WriteCommandAfter(
      //			 dbCommand,
      //			 executeMethod,
      //			 instanceId,
      //			 startTimestamp,
      //			 currentTimestamp);
      //	}
      //	catch (Exception exception)
      //	{
      //		var currentTimestamp = Stopwatch.GetTimestamp();

      //		Logger.LogCommandExecuted(dbCommand, startTimestamp, currentTimestamp);

      //		DiagnosticSource.WriteCommandError(
      //			 dbCommand,
      //			 executeMethod,
      //			 instanceId,
      //			 startTimestamp,
      //			 currentTimestamp,
      //			 exception,
      //			 async: false);

      //		if (openConnection && !closeConnection)
      //		{
      //			connection.Close();
      //		}

      //		throw;
      //	}
      //	finally
      //	{
      //		if (closeConnection)
      //		{
      //			connection.Close();
      //		}
      //	}

      //	return result;
      //}

      //protected virtual async Task<object> ExecuteAsync(
      //	 [NotNull] IRelationalConnection connection,
      //	 [NotNull] string executeMethod,
      //	 [CanBeNull] IReadOnlyDictionary<string, object> parameterValues,
      //	 bool openConnection,
      //	 bool closeConnection,
      //	 CancellationToken cancellationToken = default(CancellationToken))
      //{
      //	Check.NotNull(connection, nameof(connection));
      //	Check.NotEmpty(executeMethod, nameof(executeMethod));

      //	var dbCommand = CreateCommand(connection, parameterValues);

      //	object result;

      //	if (openConnection)
      //	{
      //		await connection.OpenAsync(cancellationToken);
      //	}

      //	var startTimestamp = Stopwatch.GetTimestamp();
      //	var instanceId = Guid.NewGuid();

      //	DiagnosticSource.WriteCommandBefore(
      //		 dbCommand,
      //		 executeMethod,
      //		 instanceId,
      //		 startTimestamp,
      //		 async: true);

      //	try
      //	{
      //		switch (executeMethod)
      //		{
      //			case nameof(ExecuteNonQuery):
      //				{
      //					using (dbCommand)
      //					{
      //						result = await dbCommand.ExecuteNonQueryAsync(cancellationToken);
      //					}

      //					break;
      //				}
      //			case nameof(ExecuteScalar):
      //				{
      //					using (dbCommand)
      //					{
      //						result = await dbCommand.ExecuteScalarAsync(cancellationToken);
      //					}

      //					break;
      //				}
      //			case nameof(ExecuteReader):
      //				{
      //					try
      //					{
      //						result
      //							 = new RelationalDataReader(
      //								  openConnection ? connection : null,
      //								  dbCommand,
      //								  await dbCommand.ExecuteReaderAsync(cancellationToken));
      //					}
      //					catch
      //					{
      //						dbCommand.Dispose();

      //						throw;
      //					}

      //					break;
      //				}
      //			default:
      //				{
      //					throw new NotSupportedException();
      //				}
      //		}

      //		var currentTimestamp = Stopwatch.GetTimestamp();

      //		Logger.LogCommandExecuted(dbCommand, startTimestamp, currentTimestamp);

      //		DiagnosticSource.WriteCommandAfter(
      //			 dbCommand,
      //			 executeMethod,
      //			 instanceId,
      //			 startTimestamp,
      //			 currentTimestamp,
      //			 async: true);
      //	}
      //	catch (Exception exception)
      //	{
      //		var currentTimestamp = Stopwatch.GetTimestamp();

      //		Logger.LogCommandExecuted(dbCommand, startTimestamp, currentTimestamp);

      //		DiagnosticSource.WriteCommandError(
      //			 dbCommand,
      //			 executeMethod,
      //			 instanceId,
      //			 startTimestamp,
      //			 currentTimestamp,
      //			 exception,
      //			 async: true);

      //		if (openConnection && !closeConnection)
      //		{
      //			connection.Close();
      //		}

      //		throw;
      //	}
      //	finally
      //	{
      //		if (closeConnection)
      //		{
      //			connection.Close();
      //		}
      //	}

      //	return result;
      //}

      //private DbCommand CreateCommand(
      //	 IRelationalConnection connection,
      //	 IReadOnlyDictionary<string, object> parameterValues)
      //{
      //	var command = connection.DbConnection.CreateCommand();

      //	command.CommandText = CommandText;

      //	if (connection.CurrentTransaction != null)
      //	{
      //		command.Transaction = connection.CurrentTransaction.GetDbTransaction();
      //	}

      //	if (connection.CommandTimeout != null)
      //	{
      //		command.CommandTimeout = (int)connection.CommandTimeout;
      //	}

      //	if (Parameters.Count > 0)
      //	{
      //		if (parameterValues == null)
      //		{
      //			throw new InvalidOperationException(
      //				 RelationalStrings.MissingParameterValue(
      //					  Parameters[0].InvariantName));
      //		}

      //		foreach (var parameter in Parameters)
      //		{
      //			object parameterValue;

      //			if (parameterValues.TryGetValue(parameter.InvariantName, out parameterValue))
      //			{
      //				parameter.AddDbParameter(command, parameterValue);
      //			}
      //			else
      //			{
      //				throw new InvalidOperationException(
      //					 RelationalStrings.MissingParameterValue(parameter.InvariantName));
      //			}
      //		}
      //	}

      //	return command;
      //}

      #endregion

   }

}
