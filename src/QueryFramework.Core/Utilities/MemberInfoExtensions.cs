using System.Diagnostics;
using System.Reflection;

namespace QueryFramework.Utilities
{

	internal static class MemberInfoExtensions
	{

		public static object GetValue(this MemberInfo memberInfo)
		{
			Debug.Assert(memberInfo is PropertyInfo || memberInfo is FieldInfo);

			var asPropertyInfo = memberInfo as PropertyInfo;
			return asPropertyInfo != null ? asPropertyInfo.GetValue(null, null) : ((FieldInfo)memberInfo).GetValue(null);
		}

	}

}
