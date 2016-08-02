namespace QueryFramework.Relational.SqlSyntex
{

	public interface ISqlQuerySource
	{

		string Schema { get; }


		string Name { get; }


		string Alias { get; }

	}

}
