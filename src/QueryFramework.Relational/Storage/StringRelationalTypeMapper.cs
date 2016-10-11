// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Utilities;
using System;
using System.Collections.Concurrent;

namespace QueryFramework.Storage
{

   public class StringRelationalTypeMapper : IStringRelationalTypeMapper
   {

      #region [ Fields ]


      private readonly ConcurrentDictionary<int, RelationalTypeMapping> _boundedAnsiMappings
         = new ConcurrentDictionary<int, RelationalTypeMapping>();

      private readonly ConcurrentDictionary<int, RelationalTypeMapping> _boundedUnicodeMappings
         = new ConcurrentDictionary<int, RelationalTypeMapping>();


      #endregion


      #region [ Constructors ]


      public StringRelationalTypeMapper(
         int maxBoundedAnsiLength,
         RelationalTypeMapping defaultAnsiMapping,
         RelationalTypeMapping unboundedAnsiMapping,
         RelationalTypeMapping keyAnsiMapping,
         Func<int, RelationalTypeMapping> createBoundedAnsiMapping,
         int maxBoundedUnicodeLength,
         RelationalTypeMapping defaultUnicodeMapping,
         RelationalTypeMapping unboundedUnicodeMapping,
         RelationalTypeMapping keyUnicodeMapping,
         Func<int, RelationalTypeMapping> createBoundedUnicodeMapping)
      {
         Check.NotNull(defaultAnsiMapping, nameof(defaultAnsiMapping));
         Check.NotNull(createBoundedAnsiMapping, nameof(createBoundedAnsiMapping));
         Check.NotNull(defaultUnicodeMapping, nameof(defaultUnicodeMapping));
         Check.NotNull(createBoundedUnicodeMapping, nameof(createBoundedUnicodeMapping));


         MaxBoundedAnsiLength = maxBoundedAnsiLength;
         DefaultAnsiMapping = defaultAnsiMapping;
         UnboundedAnsiMapping = unboundedAnsiMapping;
         KeyAnsiMapping = keyAnsiMapping;
         CreateBoundedAnsiMapping = createBoundedAnsiMapping;

         MaxBoundedUnicodeLength = maxBoundedUnicodeLength;
         DefaultUnicodeMapping = defaultUnicodeMapping;
         UnboundedUnicodeMapping = unboundedUnicodeMapping;
         KeyUnicodeMapping = keyUnicodeMapping;
         CreateBoundedUnicodeMapping = createBoundedUnicodeMapping;
      }


      #endregion


      #region [ Fields ]


      public virtual int MaxBoundedAnsiLength { get; }


      public virtual RelationalTypeMapping DefaultAnsiMapping { get; }


      public virtual RelationalTypeMapping UnboundedAnsiMapping { get; }


      public virtual RelationalTypeMapping KeyAnsiMapping { get; }


      public virtual Func<int, RelationalTypeMapping> CreateBoundedAnsiMapping { get; }


      public virtual int MaxBoundedUnicodeLength { get; }


      public virtual RelationalTypeMapping DefaultUnicodeMapping { get; }


      public virtual RelationalTypeMapping UnboundedUnicodeMapping { get; }


      public virtual RelationalTypeMapping KeyUnicodeMapping { get; }


      public virtual Func<int, RelationalTypeMapping> CreateBoundedUnicodeMapping { get; }


      #endregion


      #region [ Methods ]


      public virtual RelationalTypeMapping FindMapping(bool unicode, bool keyOrIndex, int? maxLength)
         => unicode
               ? FindMapping(
                  keyOrIndex,
                  maxLength,
                  MaxBoundedUnicodeLength,
                  UnboundedUnicodeMapping,
                  DefaultUnicodeMapping,
                  KeyUnicodeMapping,
                  _boundedUnicodeMappings,
                  CreateBoundedUnicodeMapping)
               : FindMapping(
                  keyOrIndex,
                  maxLength,
                  MaxBoundedAnsiLength,
                  UnboundedAnsiMapping,
                  DefaultAnsiMapping,
                  KeyAnsiMapping,
                  _boundedAnsiMappings,
                  CreateBoundedAnsiMapping);


      private static RelationalTypeMapping FindMapping(
         bool isKeyOrIndex,
         int? maxLength,
         int maxBoundedLength,
         RelationalTypeMapping unboundedMapping,
         RelationalTypeMapping defaultMapping,
         RelationalTypeMapping keyMapping,
         ConcurrentDictionary<int, RelationalTypeMapping> boundedMappings,
         Func<int, RelationalTypeMapping> createBoundedMapping)
      {
         var mapping =
            isKeyOrIndex
               ? keyMapping
               : defaultMapping;

         if (maxLength.HasValue
            && maxLength != mapping.Size)
         {
            return
               maxLength <= maxBoundedLength
                  ? boundedMappings.GetOrAdd(maxLength.Value, createBoundedMapping)
                  : unboundedMapping;
         }


         return mapping;
      }


      #endregion

   }

}
