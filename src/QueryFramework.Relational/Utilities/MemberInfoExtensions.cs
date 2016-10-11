// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Diagnostics;
using System.Reflection;

namespace QueryFramework.Utilities
{

   internal static class MemberInfoExtensions
   {

      #region [ Methods ]


      internal static object GetValue(this MemberInfo memberInfo)
      {
         Debug.Assert(memberInfo is PropertyInfo || memberInfo is FieldInfo);

         var asPropertyInfo = memberInfo as PropertyInfo;


         return asPropertyInfo != null
            ? asPropertyInfo.GetValue(null, null)
            : ((FieldInfo)memberInfo).GetValue(null);
      }


      #endregion

   }

}
