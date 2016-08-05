using QueryFramework.Utilities;

namespace QueryFramework.Relational
{

	public class RelationalOptionsBuilder
	{

		#region [ Constructors ]


		public RelationalOptionsBuilder(DataStoreOptionsBuilder optionsBuilder)
		{
			Check.NotNull(optionsBuilder, nameof(optionsBuilder));

			OptionsBuilder = optionsBuilder;
		}


		#endregion


		#region [ Properties ]


		protected DataStoreOptionsBuilder OptionsBuilder { get; }


		#endregion

	}

}
