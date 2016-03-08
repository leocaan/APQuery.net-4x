using System.Reflection;

namespace Symber.Data.Utilities
{

	internal static class PropertyInfoExtensions
	{

		public static MethodInfo Getter(this PropertyInfo property)
			=> property.GetGetMethod(nonPublic: true);


		public static MethodInfo Setter(this PropertyInfo property)
			=> property.GetSetMethod(nonPublic: true);


		public static bool IsStatic(this PropertyInfo property)
			=> (property.Getter() ?? property.Setter()).IsStatic;


		public static bool IsPublic(this PropertyInfo property)
		{
			var getter = property.Getter();
			var getterAccess = getter == null ? MethodAttributes.Private : (getter.Attributes & MethodAttributes.MemberAccessMask);

			var setter = property.Setter();
			var setterAccess = setter == null ? MethodAttributes.Private : (setter.Attributes & MethodAttributes.MemberAccessMask);

			var propertyAccess = getterAccess > setterAccess ? getterAccess : setterAccess;

			return propertyAccess == MethodAttributes.Public;
		}

	}

}
