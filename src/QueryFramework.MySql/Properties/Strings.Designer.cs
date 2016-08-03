// <auto-generated />
namespace QueryFramework.MySql
{
	using System.Globalization;
	using System.Reflection;
	using System.Resources;

	public static class Strings
	{
		private static readonly ResourceManager _resourceManager
			= new ResourceManager("QueryFramework.MySql.Strings", typeof(Strings).GetTypeInfo().Assembly);

		/// <summary>
		/// The provider '{providerName}' not supported combines results 'INTERSECT' and 'MINUS'.
		/// </summary>
		public static string SqlSyntex_NotSupported_CombineResult_Expr_Part(object providerName)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("SqlSyntex_NotSupported_CombineResult_Expr_Part", "providerName"), providerName);
		}

		/// <summary>
		/// The provider '{providerName}' not supported '{funcName}' function.
		/// </summary>
		public static string SqlSyntex_NotSupported_Expr(object providerName, object funcName)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("SqlSyntex_NotSupported_Expr", "providerName", "funcName"), providerName, funcName);
		}

		/// <summary>
		/// The provider '{providerName}' not supported multiple grouping sets 'ROLLUP', 'CUBE' and 'GROUPING SETS'.
		/// </summary>
		public static string SqlSyntex_NotSupported_MultipleGroupingSets_Expr(object providerName)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("SqlSyntex_NotSupported_MultipleGroupingSets_Expr", "providerName"), providerName);
		}

		private static string GetString(string name, params string[] formatterNames)
		{
			var value = _resourceManager.GetString(name);

			if (formatterNames != null)
			{
				for (var i = 0; i < formatterNames.Length; i++)
				{
					value = value.Replace("{" + formatterNames[i] + "}", "{" + i + "}");
				}
			}

			return value;
		}
	}
}
