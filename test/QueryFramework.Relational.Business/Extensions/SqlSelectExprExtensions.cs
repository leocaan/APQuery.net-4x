using QueryFramework.Relational.SqlGen;
using System;

namespace QueryFramework.Relational.SqlSyntex
{

	public static class SqlSelectExprExtensions
	{

		public static void print(this SqlSelectExpr query, string description = null)
		{
			var generator = new DefaultSqlGenerator();


			if (description != null)
				Console.WriteLine(description);
			Console.WriteLine("----------------------------------------------------------------");
			Console.WriteLine(generator
				.GenerateSelect(query)
				.SqlString);

			if (generator.Parameters.Count > 0)
			{
				Console.WriteLine("----------------------------------------------------------------");
				foreach (var item in generator.Parameters)
				{
					Console.WriteLine(generator.ParameterPrefix + item.Key + "=" + item.Value.Value);
				}
			}
			Console.WriteLine();
			Console.WriteLine();
		}

	}

}
