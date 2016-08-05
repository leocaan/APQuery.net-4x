using QueryFramework.Relational;

namespace QueryFramework.SqlServer
{

	public class SqlServerOptionsExtension : RelationalOptionsExtension
	{

		#region [ Constructors ]


		public SqlServerOptionsExtension()
		{
		}


		public SqlServerOptionsExtension(SqlServerOptionsExtension copyFrom)
			 : base(copyFrom)
		{
		}


		#endregion

	}

}
