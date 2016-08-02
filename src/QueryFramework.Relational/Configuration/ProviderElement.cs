using System.ComponentModel;
using System.Configuration;

namespace QueryFramework.Relational.Configuration
{

	internal class ProviderElement : ConfigurationElement
	{

		#region [ Static Fields ]


		private const string nameKey = "name";
		private const string typeKey = "type";

		private static ConfigurationProperty nameProp;
		private static ConfigurationProperty typeProp;
		private static ConfigurationPropertyCollection properties;


		#endregion


		#region [ Constructor ]


		static ProviderElement()
		{
			nameProp = new ConfigurationProperty(
				nameKey,
				typeof(string),
				null,
				PropertyHelper.WhiteSpaceTrimStringConverter,
				PropertyHelper.NonEmptyStringValidator,
				ConfigurationPropertyOptions.IsKey | ConfigurationPropertyOptions.IsRequired);
			typeProp = new ConfigurationProperty(
				typeKey,
				typeof(string),
				null,
				PropertyHelper.StringConverter,
				PropertyHelper.NonEmptyStringValidator,
				ConfigurationPropertyOptions.IsRequired);

			properties = new ConfigurationPropertyCollection();
			properties.Add(nameProp);
			properties.Add(typeProp);
		}


		#endregion


		#region [ Properties ]


		[TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
		[StringValidator(MinLength = 1)]
		[ConfigurationProperty(nameKey)]
		public string Name
		{
			get { return (string)base[nameProp]; }
			set { base[nameProp] = value; }
		}


		[TypeConverter(typeof(StringConverter))]
		[StringValidator(MinLength = 1)]
		[ConfigurationProperty(typeKey)]
		public string Type
		{
			get { return (string)base[typeProp]; }
			set { base[typeProp] = value; }
		}


		protected override ConfigurationPropertyCollection Properties
		{
			get { return properties; }
		}


		#endregion

	}

}
