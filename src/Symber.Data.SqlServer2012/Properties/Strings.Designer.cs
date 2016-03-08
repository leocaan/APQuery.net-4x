// <auto-generated />
namespace Symber.Data.SqlServer2012
{
	using System.Globalization;
	using System.Reflection;
	using System.Resources;

	public static class Strings
	{
		private static readonly ResourceManager _resourceManager
			= new ResourceManager("Symber.Data.SqlServer2012.Strings", typeof(Strings).GetTypeInfo().Assembly);

		/// <summary>
		/// bb
		/// </summary>
		public static string bb
		{
			get { return GetString("bb"); }
		}

		/// <summary>
		/// Provider can not be found for the DbProviderFactory provider with type name '{typeName}'. 
		/// </summary>
		public static string Providers_NoProviderFound(object typeName)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("Providers_NoProviderFound", "typeName"), typeName);
		}

		/// <summary>
		/// The string argument '{argumentName}' cannot be empty.
		/// </summary>
		public static string Utilities_ArgumentIsEmpty(object argumentName)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("Utilities_ArgumentIsEmpty", "argumentName"), argumentName);
		}

		/// <summary>
		/// The property '{property}' of the argument '{argument}' cannot be null.
		/// </summary>
		public static string Utilities_ArgumentPropertyNull(object property, object argument)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("Utilities_ArgumentPropertyNull", "property", "argument"), property, argument);
		}

		/// <summary>
		/// The collection argument '{argumentName}' must contain at least one element.
		/// </summary>
		public static string Utilities_CollectionArgumentIsEmpty(object argumentName)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("Utilities_CollectionArgumentIsEmpty", "argumentName"), argumentName);
		}

		/// <summary>
		/// The type '{type}' provided for argument '{argumentName}' must be assigned to the type '{baseType}'.
		/// </summary>
		public static string Utilities_InvalidDerivesType(object type, object argumentName, object baseType)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("Utilities_InvalidDerivesType", "type", "argumentName", "baseType"), type, argumentName, baseType);
		}

		/// <summary>
		/// The entity type '{type}' provided for the argument '{argumentName}' must be a reference type.
		/// </summary>
		public static string Utilities_InvalidEntityType(object type, object argumentName)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("Utilities_InvalidEntityType", "type", "argumentName"), type, argumentName);
		}

		/// <summary>
		/// The value provided for argument '{argumentName}' must be a valid value of enum type '{enumType}'.
		/// </summary>
		public static string Utilities_InvalidEnumValue(object argumentName, object enumType)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("Utilities_InvalidEnumValue", "argumentName", "enumType"), argumentName, enumType);
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
