using System;
using System.Linq;
using System.Reflection;

namespace Symber.Data.Utilities
{

	internal static class TypeExtensions
	{

		public static PropertyInfo GetStaticProperty(this Type type, string name)
		{
			Check.NotNull(type, nameof(type));
			Check.NotEmpty(name, nameof(name));

			var properties = type.GetRuntimeProperties()
				.Where(p => p.Name == name && p.IsStatic())
				.ToList();
			if (properties.Count() > 1)
			{
				throw new AmbiguousMatchException();
			}

			return properties.SingleOrDefault();
		}

	}

}
