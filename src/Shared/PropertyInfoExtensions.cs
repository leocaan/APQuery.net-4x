// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Reflection;

namespace QueryFramework.Utilities
{

   internal static class PropertyInfoExtensions
   {

      #region [ Methods ]


      internal static bool IsStatic(this PropertyInfo propertyInfo)
         => (propertyInfo.GetMethod ?? propertyInfo.SetMethod).IsStatic;


      internal static bool IsCandidateProperty(this PropertyInfo propertyInfo, bool needsWrite = true)
         => !propertyInfo.IsStatic()
            && propertyInfo.GetIndexParameters().Length == 0
            && propertyInfo.CanRead
            && (!needsWrite || propertyInfo.CanWrite)
            && propertyInfo.GetMethod != null
            && propertyInfo.GetMethod.IsPublic;


      public static Type FindCandidateNavigationPropertyType(this PropertyInfo propertyInfo,
         Func<Type, bool> isPrimitiveProperty)
      {
         var targetType = propertyInfo.PropertyType;
         var targetSequenceType = targetType.TryGetSequenceType();
         if (!propertyInfo.IsCandidateProperty(targetSequenceType == null))
         {
            return null;
         }

         targetType = targetSequenceType ?? targetType;
         targetType = targetType.UnwrapNullableType();

         if (isPrimitiveProperty(targetType)
             || targetType.GetTypeInfo().IsInterface
             || targetType.GetTypeInfo().IsValueType
             || targetType == typeof(object))
         {
            return null;
         }


         return targetType;
      }


      #endregion

   }

}
