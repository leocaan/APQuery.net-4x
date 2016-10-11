// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Data;

namespace QueryFramework.Storage.Internal
{

   public class MySqlTypeMapper : RelationalTypeMapper
   {

      #region [ Fields ]


      private readonly MySqlMaxLengthMapping _varcharmax
         = new MySqlMaxLengthMapping("longtext", typeof(string), dbType: DbType.AnsiString);

      private readonly MySqlMaxLengthMapping _varchar255
         = new MySqlMaxLengthMapping("varchar(255)", typeof(string), dbType: DbType.AnsiString);

      private readonly MySqlMaxLengthMapping _varbinarymax
         = new MySqlMaxLengthMapping("longblob", typeof(byte[]), dbType: DbType.Binary);

      private readonly MySqlMaxLengthMapping _varbinary767
         = new MySqlMaxLengthMapping("varbinary(767)", typeof(byte[]), dbType: DbType.Binary);

      private readonly RelationalTypeMapping _rowversion
         = new RelationalTypeMapping("TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP", typeof(byte[]), dbType: DbType.Binary);

      private readonly RelationalTypeMapping _int
         = new RelationalTypeMapping("int", typeof(int), dbType: DbType.Int32);

      private readonly RelationalTypeMapping _bigint
         = new RelationalTypeMapping("bigint", typeof(long), dbType: DbType.Int64);

      private readonly RelationalTypeMapping _smallint
         = new RelationalTypeMapping("smallint", typeof(short), dbType: DbType.Int16);

      private readonly RelationalTypeMapping _tinyint
         = new RelationalTypeMapping("tinyint unsigned", typeof(byte), dbType: DbType.Byte);

      private readonly RelationalTypeMapping _bit
         = new RelationalTypeMapping("bit", typeof(bool));

      private readonly MySqlMaxLengthMapping _nchar
         = new MySqlMaxLengthMapping("varchar", typeof(string), dbType: DbType.StringFixedLength);

      private readonly MySqlMaxLengthMapping _nvarchar
         = new MySqlMaxLengthMapping("varchar", typeof(string));

      private readonly MySqlMaxLengthMapping _char
         = new MySqlMaxLengthMapping("char", typeof(string), dbType: DbType.AnsiStringFixedLength, unicode: false, size: null, hasNonDefaultUnicode: true);

      private readonly MySqlMaxLengthMapping _varchar
         = new MySqlMaxLengthMapping("varchar", typeof(string), dbType: DbType.AnsiString);

      private readonly MySqlMaxLengthMapping _varbinary
         = new MySqlMaxLengthMapping("varbinary", typeof(byte[]), dbType: DbType.Binary);

      private readonly RelationalTypeMapping _datetime
         = new RelationalTypeMapping("datetime", typeof(DateTime), dbType: DbType.DateTime);

      private readonly RelationalTypeMapping _double
         = new RelationalTypeMapping("double", typeof(double));

      private readonly RelationalTypeMapping _datetimeoffset
         = new RelationalTypeMapping("varchar(255)", typeof(DateTimeOffset), DbType.DateTimeOffset);

      private readonly RelationalTypeMapping _float
         = new RelationalTypeMapping("float", typeof(float));

      private readonly RelationalTypeMapping _uniqueidentifier
         = new RelationalTypeMapping("char(38)", typeof(Guid));

      private readonly RelationalTypeMapping _decimal
         = new RelationalTypeMapping("decimal(18, 2)", typeof(decimal));

      private readonly RelationalTypeMapping _time
         = new RelationalTypeMapping("time(6)", typeof(TimeSpan), DbType.Time);

      private readonly Dictionary<string, RelationalTypeMapping> _storeTypeMappings;
      private readonly Dictionary<Type, RelationalTypeMapping> _clrTypeMappings;


      #endregion


      #region [ Constructors ]


      public MySqlTypeMapper()
      {
         _storeTypeMappings
            = new Dictionary<string, RelationalTypeMapping>(StringComparer.OrdinalIgnoreCase)
            {
               { "bigint", _bigint },
               // { "binary varying", _varbinary },
               { "binary", _varbinary },
               { "bit", _bit },
               { "char varying", _varchar },
               { "char varying(8000)", _varcharmax },
               { "char", _char },
               { "character varying", _varchar },
               { "character varying(8000)", _varcharmax },
               { "character", _char },
               { "date", _datetime },
               { "datetime", _datetime },
               { "datetimeoffset", _datetimeoffset },
               { "dec", _decimal },
               { "decimal", _decimal },
               { "float", _double },
               { "image", _varbinary },
               { "int", _int },
               { "money", _decimal },
               { "nchar", _nchar },
               { "ntext", _nvarchar },
               { "numeric", _decimal },
               { "nvarchar", _nvarchar },
               { "smallint", _smallint },
               { "smallmoney", _decimal },
               { "text", _varchar },
               { "time", _time },
               { "timestamp", _rowversion },
               { "tinyint", _tinyint },
               { "uniqueidentifier", _uniqueidentifier },
               { "varbinary", _varbinary },
               { "varchar", _varchar },
               { "varchar(8000)", _varcharmax }
            };

         _clrTypeMappings
            = new Dictionary<Type, RelationalTypeMapping>
            {
               { typeof(int), _int },
               { typeof(long), _bigint },
               { typeof(DateTime), _datetime },
               { typeof(Guid), _uniqueidentifier },
               { typeof(bool), _bit },
               { typeof(byte), _tinyint },
               { typeof(double), _double },
               { typeof(DateTimeOffset), _datetimeoffset },
               { typeof(char), _int },
               { typeof(sbyte), new RelationalTypeMapping("tinyint", typeof(sbyte)) },
               { typeof(ushort), new RelationalTypeMapping("int", typeof(ushort)) },
               { typeof(uint), new RelationalTypeMapping("bigint", typeof(uint)) },
               { typeof(ulong), new RelationalTypeMapping("real(20, 0)", typeof(ulong)) },
               { typeof(short), _smallint },
               { typeof(float), _float },
               { typeof(decimal), _decimal },
               { typeof(TimeSpan), _time }
            };

         ByteArrayMapper
            = new ByteArrayRelationalTypeMapper(
               8000,
               _varbinarymax,
               _varbinary767,
               _varbinary767,
               _rowversion,
               size => new MySqlMaxLengthMapping(
                  "varbinary(" + size + ")",
                  typeof(byte[]),
                  DbType.Binary,
                  unicode: false,
                  size: size,
                  hasNonDefaultUnicode: false,
                  hasNonDefaultSize: true));

         StringMapper
            = new StringRelationalTypeMapper(
               8000,
               _varcharmax,
               _varchar255,
               _varchar255,
               size => new MySqlMaxLengthMapping(
                  "varchar(" + size + ")",
                  typeof(string),
                  dbType: DbType.AnsiString,
                  unicode: false,
                  size: size,
                  hasNonDefaultUnicode: true,
                  hasNonDefaultSize: true),
               4000,
               _varcharmax,
               _varchar255,
               _varchar255,
               size => new MySqlMaxLengthMapping(
                  "nvarchar(" + size + ")",
                  typeof(string),
                  dbType: null,
                  unicode: true,
                  size: size,
                  hasNonDefaultUnicode: false,
                  hasNonDefaultSize: true));
      }


      #endregion


      #region [ Properties ]


      public override IByteArrayRelationalTypeMapper ByteArrayMapper { get; }


      public override IStringRelationalTypeMapper StringMapper { get; }


      #endregion


      #region [ Methods ]


      protected override IReadOnlyDictionary<Type, RelationalTypeMapping> GetClrTypeMappings()
         => _clrTypeMappings;


      protected override IReadOnlyDictionary<string, RelationalTypeMapping> GetStoreTypeMappings()
         => _storeTypeMappings;


      public override RelationalTypeMapping FindMapping(Type clrType)
      {
         Check.NotNull(clrType, nameof(clrType));


         clrType = clrType
            .UnwrapNullableType()
            .UnwrapEnumType();


         return clrType == typeof(string)
            ? _varcharmax
            : (clrType == typeof(byte[])
               ? _varbinarymax
               : base.FindMapping(clrType));
      }


      #endregion

   }

}
