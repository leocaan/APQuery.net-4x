// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Data;
using System.Data.Common;

namespace QueryFramework.Storage.Internal
{

   public class SqlServerMaxLengthMapping : RelationalTypeMapping
   {

      #region [ Constructors ]


      public SqlServerMaxLengthMapping(string storeType, Type clrType, DbType? dbType = null)
         : this(storeType, clrType, dbType, unicode: false, size: null)
      {
      }


      public SqlServerMaxLengthMapping(string storeType, Type clrType, DbType? dbType,
         bool unicode, int? size, bool hasNonDefaultUnicode = false,
         bool hasNonDefaultSize = false)
         : base(storeType, clrType, dbType, unicode, CalculateSize(unicode, size), hasNonDefaultUnicode, hasNonDefaultSize)
      {
      }


      #endregion


      #region [ Methods  ]


      private static int CalculateSize(bool unicode, int? size)
         => unicode
            ? size.HasValue && size < 4000 ? size.Value : 4000
            : size.HasValue && size < 8000 ? size.Value : 8000;


      public override RelationalTypeMapping CreateCopy(string storeType, int? size)
         => new SqlServerMaxLengthMapping(
               storeType,
               ClrType,
               DbType,
               IsUnicode,
               size,
               HasNonDefaultUnicode,
               hasNonDefaultSize: size != Size);


      protected override void ConfigureParameter(DbParameter parameter)
      {
         // For strings and byte arrays, set the max length to the size facet if specififed, or
         // 8000 bytes if no size facet specified, if the data will fit so as to avoid query cache
         // fragmentation by setting lots of differet Size values otherwise always set to 
         // -1 (unbounded) to avoid SQL client size inference.

         var value = parameter.Value;
         var length = (value as string)?.Length ?? (value as byte[])?.Length;

         parameter.Size = value == null || value == DBNull.Value || (length != null && length <= Size.Value)
             ? Size.Value
             : -1;
      }


      #endregion

   }

}
