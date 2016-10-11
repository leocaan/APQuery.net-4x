// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Text;

namespace QueryFramework.Storage.Internal
{

   public class SqliteSqlGenerationHelper : RelationalSqlGenerationHelper
   {

      #region [ Fields ]


      private const string DateTimeFormatConst = @"yyyy\-MM\-dd HH\:mm\:ss.FFFFFFF";
      private const string DateTimeFormatStringConst = "'{0:" + DateTimeFormatConst + "}'";
      private const string DateTimeOffsetFormatConst = @"yyyy\-MM\-dd HH\:mm\:ss.FFFFFFFzzz";
      private const string DateTimeOffsetFormatStringConst = "'{0:" + DateTimeOffsetFormatConst + "}'";


      #endregion


      #region [ Properties ]


      protected override string DateTimeFormat
         => DateTimeFormatConst;


      protected override string DateTimeFormatString
         => DateTimeFormatStringConst;


      protected override string DateTimeOffsetFormat
         => DateTimeOffsetFormatConst;


      protected override string DateTimeOffsetFormatString
         => DateTimeOffsetFormatStringConst;


      #endregion


      #region [ Methods ]


      // TODO throw a logger warning that this call was improperly made. The SQLite provider should never specify a schema
      public override string DelimitIdentifier(string name, string schema)
         => base.DelimitIdentifier(name);


      public override void DelimitIdentifier(StringBuilder builder, string name, string schema)
         => base.DelimitIdentifier(builder, name);


      protected override string GenerateLiteralValue(DateTime value)
         => $"'{value.ToString(DateTimeFormat, CultureInfo.InvariantCulture)}'"; // Interpolation okay; strings


      protected override string GenerateLiteralValue(DateTimeOffset value)
         => $"'{value.ToString(DateTimeOffsetFormat, CultureInfo.InvariantCulture)}'"; // Interpolation okay; strings


      protected override string GenerateLiteralValue(Guid value)
         => GenerateLiteralValue(value.ToByteArray());


      protected override void GenerateLiteralValue(StringBuilder builder, Guid value)
         => GenerateLiteralValue(builder, value.ToByteArray());


      #endregion

   }

}
