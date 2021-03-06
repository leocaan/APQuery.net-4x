﻿// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Internal;
using QueryFramework.Utilities;
using System;
using System.Reflection;

namespace QueryFramework.Relational.Storage
{

   internal class DataStoreProviderFactory
   {

      #region [ Methods ]


      public DataStoreProvider GetInstance(string providerTypeName)
      {
         Check.NotEmpty(providerTypeName, nameof(providerTypeName));


         var providerType = Type.GetType(providerTypeName, throwOnError: false);


         return providerType == null ? null : GetInstance(providerType);
      }


      private static DataStoreProvider GetInstance(Type providerType)
      {
         Check.NotNull(providerType, nameof(providerType));


         const BindingFlags bindingFlags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

         var instanceMember = providerType.GetStaticProperty("Instance")
                              ?? (MemberInfo)providerType.GetField("Instance", bindingFlags);
         if (instanceMember == null)
         {
            throw new InvalidOperationException(RelationalStrings.Providers_InstanceMissing(providerType.AssemblyQualifiedName));
         }

         var providerInstance = instanceMember.GetValue() as DataStoreProvider;
         if (providerInstance == null)
         {
            throw new InvalidOperationException(RelationalStrings.Providers_NotDataStoreProvider(providerType.AssemblyQualifiedName, typeof(DataStoreProvider).AssemblyQualifiedName));
         }


         return providerInstance;
      }


      #endregion

   }

}
