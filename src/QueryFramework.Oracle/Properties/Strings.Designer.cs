// <auto-generated />
namespace QueryFramework.Oracle
{
	using System.Reflection;
	using System.Resources;

	public static class Strings
	{
		private static readonly ResourceManager _resourceManager
			= new ResourceManager("QueryFramework.Oracle.Strings", typeof(Strings).GetTypeInfo().Assembly);

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
