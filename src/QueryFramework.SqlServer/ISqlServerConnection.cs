using QueryFramework.Relational;

namespace QueryFramework.SqlServer
{

	public interface ISqlServerConnection : IRelationalConnection
	{

		#region [ Methods ]


		ISqlServerConnection CreateMasterConnection();


		#endregion


	}

}
