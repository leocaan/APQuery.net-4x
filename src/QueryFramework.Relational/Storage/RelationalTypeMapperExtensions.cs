// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.


using QueryFramework.Internal;
using QueryFramework.Utilities;
using System;

namespace QueryFramework.Storage
{

   public static class RelationalTypeMapperExtensions
   {

      #region [ Methods ]


      public static RelationalTypeMapping GetMappingForValue(this IRelationalTypeMapper typeMapper,
         object value)
         => (value == null)
            || (value == DBNull.Value)
            || (typeMapper == null)
               ? RelationalTypeMapping.NullMapping
               : typeMapper.GetMapping(value.GetType());


      public static RelationalTypeMapping GetMapping(this IRelationalTypeMapper typeMapper,
         Type clrType)
      {
         Check.NotNull(typeMapper, nameof(typeMapper));
         Check.NotNull(clrType, nameof(clrType));


         var mapping = typeMapper.FindMapping(clrType);

         if (mapping != null)
         {
            return mapping;
         }


         throw new InvalidOperationException(RelationalStrings.Mapping_UnsupportedType(clrType));
      }


      public static RelationalTypeMapping GetMapping(this IRelationalTypeMapper typeMapper,
         string typeName)
      {
         Check.NotNull(typeMapper, nameof(typeMapper));
         Check.NotNull(typeName, nameof(typeName));


         var mapping = typeMapper.FindMapping(typeName);

         if (mapping != null)
         {
            return mapping;
         }

         throw new InvalidOperationException(RelationalStrings.Mapping_UnsupportedType(typeName));
      }


      public static bool IsTypeMapped(this IRelationalTypeMapper typeMapper,
         Type clrType)
      {
         Check.NotNull(typeMapper, nameof(typeMapper));
         Check.NotNull(clrType, nameof(clrType));


         return typeMapper.FindMapping(clrType) != null;
      }


      #endregion

   }

}
