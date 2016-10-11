// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.


using QueryFramework.Utilities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace QueryFramework.Storage
{

   public abstract class RelationalTypeMapper : IRelationalTypeMapper
   {

      #region [ Fields ]


      private readonly ConcurrentDictionary<string, RelationalTypeMapping> _explicitMappings
         = new ConcurrentDictionary<string, RelationalTypeMapping>();


      #endregion


      #region [ Methods ]


      protected abstract IReadOnlyDictionary<Type, RelationalTypeMapping> GetClrTypeMappings();


      protected abstract IReadOnlyDictionary<string, RelationalTypeMapping> GetStoreTypeMappings();


      public virtual void ValidateTypeName(string storeType)
      {
      }


      public virtual RelationalTypeMapping FindMapping(Type clrType)
      {
         Check.NotNull(clrType, nameof(clrType));


         RelationalTypeMapping mapping;
         return GetClrTypeMappings().TryGetValue(clrType.UnwrapNullableType().UnwrapEnumType(), out mapping)
             ? mapping
             : null;
      }


      public virtual RelationalTypeMapping FindMapping(string storeType)
      {
         Check.NotNull(storeType, nameof(storeType));


         return _explicitMappings.GetOrAdd(storeType, CreateMappingFromStoreType);
      }


      protected virtual RelationalTypeMapping CreateMappingFromStoreType(string storeType)
      {
         Check.NotNull(storeType, nameof(storeType));


         RelationalTypeMapping mapping;
         if (GetStoreTypeMappings().TryGetValue(storeType, out mapping)
               && mapping.StoreType.Equals(storeType, StringComparison.OrdinalIgnoreCase))
         {
            return mapping;
         }

         var openParen = storeType.IndexOf("(", StringComparison.Ordinal);
         if (openParen > 0)
         {
            if (!GetStoreTypeMappings().TryGetValue(storeType.Substring(0, openParen), out mapping))
            {
               return null;
            }

            if (mapping.ClrType == typeof(string)
                  || mapping.ClrType == typeof(byte[]))
            {
               var closeParen = storeType.IndexOf(")", openParen + 1, StringComparison.Ordinal);
               int size;
               if (closeParen > openParen
                   && int.TryParse(storeType.Substring(openParen + 1, closeParen - openParen - 1), out size)
                   && mapping.Size != size)
               {
                  return mapping.CreateCopy(storeType, size);
               }
            }
         }


         return mapping?.CreateCopy(storeType, mapping.Size);
      }


      public virtual IByteArrayRelationalTypeMapper ByteArrayMapper
         => null;


      public virtual IStringRelationalTypeMapper StringMapper
         => null;


      #endregion

   }

}
