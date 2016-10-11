// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Utilities;
using System;
using System.Data;
using System.Data.Common;

namespace QueryFramework.Storage
{

   public class RelationalTypeMapping
   {

      #region [ Fields ]


      public static readonly RelationalTypeMapping NullMapping = new RelationalTypeMapping("NULL");


      #endregion


      #region [ Constructors ]


      public RelationalTypeMapping(string storeType, Type clrType)
         : this(storeType, clrType, dbType: null)
      {
      }


      public RelationalTypeMapping(string storeType, Type clrType, DbType? dbType)
         : this(storeType, clrType, dbType, unicode: false, size: null)
      {
      }


      public RelationalTypeMapping(string storeType, Type clrType, DbType? dbType,
         bool unicode, int? size, bool hasNonDefaultUnicode = false, bool hasNonDefaultSize = false)
         : this(storeType)
      {
         Check.NotNull(clrType, nameof(clrType));


         ClrType = clrType;
         DbType = dbType;
         IsUnicode = unicode;
         Size = size;
         HasNonDefaultUnicode = hasNonDefaultUnicode;
         HasNonDefaultSize = hasNonDefaultSize;
      }


      private RelationalTypeMapping(string storeType)
      {
         Check.NotEmpty(storeType, nameof(storeType));


         StoreType = storeType;
      }


      public virtual RelationalTypeMapping CreateCopy(string storeType, int? size)
         => new RelationalTypeMapping(
               storeType,
               ClrType,
               DbType,
               IsUnicode,
               size,
               HasNonDefaultUnicode,
               hasNonDefaultSize: size != Size);


      #endregion


      #region [ Properties ]


      public virtual string StoreType { get; }


      public virtual Type ClrType { get; }


      public virtual DbType? DbType { get; }


      public virtual bool IsUnicode { get; }


      public virtual int? Size { get; }


      public virtual bool HasNonDefaultUnicode { get; }


      public virtual bool HasNonDefaultSize { get; }


      #endregion


      #region [ Methods ]


      public virtual DbParameter CreateParameter(
         DbCommand command,
         string name,
         object value,
         bool? nullable = null)
      {
         Check.NotNull(command, nameof(command));
         Check.NotNull(command, nameof(command));


         var parameter = command.CreateParameter();
         parameter.Direction = ParameterDirection.Input;
         parameter.ParameterName = name;
         parameter.Value = value ?? DBNull.Value;

         if (nullable.HasValue)
         {
            parameter.IsNullable = nullable.Value;
         }

         if (DbType.HasValue)
         {
            parameter.DbType = DbType.Value;
         }

         if (Size.HasValue)
         {
            parameter.Size = Size.Value;
         }

         ConfigureParameter(parameter);


         return parameter;
      }


      protected virtual void ConfigureParameter(DbParameter parameter)
      {
      }


      #endregion

   }

}
