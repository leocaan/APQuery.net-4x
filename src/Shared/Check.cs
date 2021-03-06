﻿// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace QueryFramework.Utilities
{

   [DebuggerStepThrough]
   internal static class Check
   {

      #region [ Methods 


      public static T NotNull<T>(T value, string parameterName)
      {
         if (ReferenceEquals(value, null))
         {
            NotEmpty(parameterName, nameof(parameterName));

            throw new ArgumentNullException(parameterName);
         }


         return value;
      }


      public static T NotNull<T>(T value, string parameterName, string propertyName)
      {
         if (ReferenceEquals(value, null))
         {
            NotEmpty(parameterName, nameof(parameterName));
            NotEmpty(propertyName, nameof(propertyName));

            throw new ArgumentException(Strings.Utilities_ArgumentPropertyNull(propertyName, parameterName));
         }


         return value;
      }


      public static string NotEmpty(string value, string parameterName)
      {
         Exception e = null;
         if (ReferenceEquals(value, null))
         {
            e = new ArgumentNullException(parameterName);
         }
         else if (value.Trim().Length == 0)
         {
            e = new ArgumentException(Strings.Utilities_ArgumentIsEmpty(parameterName));
         }

         if (e != null)
         {
            NotEmpty(parameterName, nameof(parameterName));

            throw e;
         }


         return value;
      }


      public static IReadOnlyList<T> NotEmpty<T>(IReadOnlyList<T> value, string parameterName)
      {
         NotNull(value, parameterName);


         if (value.Count == 0)
         {
            NotEmpty(parameterName, nameof(parameterName));

            throw new ArgumentException(Strings.Utilities_CollectionArgumentIsEmpty(parameterName));
         }


         return value;
      }


      public static string NullButNotEmpty(string value, string parameterName)
      {
         if (!ReferenceEquals(value, null) && value.Length == 0)
         {
            NotEmpty(parameterName, nameof(parameterName));

            throw new ArgumentException(Strings.Utilities_ArgumentIsEmpty(parameterName));
         }


         return value;
      }


      public static IReadOnlyList<T> HasNoNulls<T>(IReadOnlyList<T> value, string parameterName)
         where T : class
      {
         NotNull(value, parameterName);


         if (value.Any(e => e == null))
         {
            NotEmpty(parameterName, nameof(parameterName));

            throw new ArgumentException(parameterName);
         }


         return value;
      }


      public static Type ValidEntityType(Type value, string parameterName)
      {
         if (!value.GetTypeInfo().IsClass)
         {
            NotEmpty(parameterName, nameof(parameterName));

            throw new ArgumentException(Strings.Utilities_InvalidEntityType(parameterName, value));
         }


         return value;
      }


      #endregion

   }

}
