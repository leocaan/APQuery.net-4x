// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Reflection;

namespace QueryFramework.Utilities
{

   internal class TypeLoader
   {

      #region [ Methods ]


      internal static Type LoadType(string typeName)
      {
         Check.NotEmpty(typeName, nameof(typeName));


         Type type;

         if (null != (type = Type.GetType(typeName)))
         {
            return type;
         }

         if (null != (type = Assembly.GetExecutingAssembly().GetType(typeName)))
         {
            return type;
         }

         foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
         {
            if (null != (type = assembly.GetType(typeName)))
            {
               return type;
            }
         }


         return null;
      }


      #endregion

   }

}
