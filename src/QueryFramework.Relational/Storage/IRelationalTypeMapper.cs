// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace QueryFramework.Storage
{

   public interface IRelationalTypeMapper
   {

      #region [ Properties ]


      IByteArrayRelationalTypeMapper ByteArrayMapper { get; }


      IStringRelationalTypeMapper StringMapper { get; }


      #endregion


      #region [ Methods ]


      RelationalTypeMapping FindMapping(Type clrType);


      RelationalTypeMapping FindMapping(string storeType);


      void ValidateTypeName(string storeType);


      #endregion

   }

}
