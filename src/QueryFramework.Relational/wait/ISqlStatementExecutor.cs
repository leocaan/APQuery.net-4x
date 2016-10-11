using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace QueryFramework.Relational
{

   public interface ISqlStatementExecutor
	{

		#region [ Methods ]


		Task ExecuteNonQueryAsync(
			IRelationalConnection connection,
			DbTransaction transaction,
			string sql,
			CancellationToken cancellationToken = default(CancellationToken));

		Task<object> ExecuteScalarAsync(
			IRelationalConnection connection,
			DbTransaction transaction,
			string sql,
			CancellationToken cancellationToken = default(CancellationToken));


		Task<object> ExecuteAsync(
			IRelationalConnection connection,
			Func<Task<object>> action,
			CancellationToken cancellationToken = default(CancellationToken));


		void ExecuteNonQuery(
			IRelationalConnection connection,
			DbTransaction transaction,
			string sql);

		object ExecuteScalar(
			IRelationalConnection connection,
			DbTransaction transaction,
			string sql);


		object Execute(
			IRelationalConnection connection,
			Func<object> action);


		#endregion

	}

}
