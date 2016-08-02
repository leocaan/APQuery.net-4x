using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueryFramework;
using QueryFramework.Relational.Storage;
using System.Reflection;
using System.Resources;

namespace QueryFramework.SqlServer.Tests
{

	[TestClass]
	public class ConfigProviderTest
	{

		[TestMethod]
		public void LunchProvider()
		{
			//var type = typeof(Strings);
			//var rns = type.Assembly.GetManifestResourceNames();

			//ResourceManager _resourceManager
			//= new ResourceManager("QueryFramework.Core.Strings", typeof(Strings).GetTypeInfo().Assembly);
			//_resourceManager.GetString("Utilities_ArgumentIsEmpty");

			StorageTest.TestServices();
		}

	}

}
