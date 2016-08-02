using System.ComponentModel;
using System.Configuration;

namespace QueryFramework.Relational.Configuration
{

	internal class APQuerySection : ConfigurationSection
	{

		#region [ Static Fields ]

		private const string defaultProviderKey = "defaultProvider";
		private const string providersKey = "providers";

		private static ConfigurationProperty defaultProviderProp;
		private static ConfigurationProperty providersProp;
		private static ConfigurationPropertyCollection properties;


		#endregion


		#region [ Constructor ]


		static APQuerySection()
		{
			defaultProviderProp = new ConfigurationProperty(
				defaultProviderKey,
				typeof(string),
				null,
				PropertyHelper.WhiteSpaceTrimStringConverter,
				PropertyHelper.NonEmptyStringValidator,
				ConfigurationPropertyOptions.None);
			providersProp = new ConfigurationProperty(
				providersKey,
				typeof(ProviderCollection),
				null);

			properties = new ConfigurationPropertyCollection();
			properties.Add(defaultProviderProp);
			properties.Add(providersProp);
		}


		#endregion


		#region [ Properties ]


		[TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
		[StringValidator(MinLength = 1)]
		[ConfigurationProperty(defaultProviderKey, DefaultValue = "SqlAPDalProvider")]
		public string DefaultProvider
		{
			get { return (string)base[defaultProviderProp]; }
			set { base[defaultProviderProp] = value; }
		}


		[ConfigurationProperty(providersKey)]
		public ProviderCollection Providers
		{
			get { return (ProviderCollection)base[providersProp]; }
		}


		protected override ConfigurationPropertyCollection Properties
		{
			get { return properties; }
		}


		#endregion

	}

}
