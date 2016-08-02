using QueryFramework.Utilities;
using System.Data;

namespace QueryFramework.Relational.SqlGen
{

	public class CommandParameter
	{

		#region [ Constructors ]



		public CommandParameter(string name, object value, ParameterDirection direction)
		{
			Check.NotNull(name, nameof(name));
			Check.NotNull(value, nameof(value));

			Name = name;
			Value = name;
			Direction = direction;
		}


		#endregion


		#region [ Properties ]


		public virtual string Name { get; }


		public virtual object Value { get; }


		public virtual ParameterDirection Direction { get; }


		#endregion

	}

}
