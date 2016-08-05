namespace QueryFramework.Infrastructure
{

	public interface IDataStoreOptionsBuilderExtender
	{

		void AddOrUpdateExtension<TExtension>(TExtension extension)
			 where TExtension : class, IDataStoreOptionsExtension;

	}

}
