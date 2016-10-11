// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Utilities;
using System;
using System.Collections.Concurrent;

namespace QueryFramework.Storage
{


   public class ByteArrayRelationalTypeMapper : IByteArrayRelationalTypeMapper
   {

      #region [ Fields ]


      private readonly ConcurrentDictionary<int, RelationalTypeMapping> _boundedMappings
         = new ConcurrentDictionary<int, RelationalTypeMapping>();


      #endregion


      #region [ Constructors ]


      public ByteArrayRelationalTypeMapper(
         int maxBoundedLength,
            RelationalTypeMapping defaultMapping,
            RelationalTypeMapping unboundedMapping,
            RelationalTypeMapping keyMapping,
            RelationalTypeMapping rowVersionMapping,
            Func<int, RelationalTypeMapping> createBoundedMapping)
      {
         Check.NotNull(defaultMapping, nameof(defaultMapping));
         Check.NotNull(createBoundedMapping, nameof(createBoundedMapping));


         MaxBoundedLength = maxBoundedLength;
         DefaultMapping = defaultMapping;
         UnboundedMapping = unboundedMapping;
         KeyMapping = keyMapping;
         RowVersionMapping = rowVersionMapping;
         CreateBoundedMapping = createBoundedMapping;
      }


      #endregion


      #region [ Properties ]


      public virtual int MaxBoundedLength { get; }


      public virtual RelationalTypeMapping DefaultMapping { get; }


      public virtual RelationalTypeMapping UnboundedMapping { get; }


      public virtual RelationalTypeMapping KeyMapping { get; }


      public virtual RelationalTypeMapping RowVersionMapping { get; }


      public virtual Func<int, RelationalTypeMapping> CreateBoundedMapping { get; }


      #endregion


      #region [ Methods ]


      public virtual RelationalTypeMapping FindMapping(bool rowVersion, bool keyOrIndex, int? size)
      {
         if (rowVersion
            && RowVersionMapping != null)
         {
            return RowVersionMapping;
         }

         var defaultMapping =
            keyOrIndex && KeyMapping != null
               ? KeyMapping
               : DefaultMapping;

         if (size.HasValue
            && size != defaultMapping.Size)
         {
            return
               size <= MaxBoundedLength
                  ? _boundedMappings.GetOrAdd(size.Value, CreateBoundedMapping)
                  : UnboundedMapping;
         }


         return defaultMapping;
      }


      #endregion

   }

}
