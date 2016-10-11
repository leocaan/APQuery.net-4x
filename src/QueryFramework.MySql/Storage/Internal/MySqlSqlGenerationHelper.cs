// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Utilities;
using System;
using System.Globalization;
using System.Text;

namespace QueryFramework.Storage.Internal
{

   public class MySqlSqlGenerationHelper : RelationalSqlGenerationHelper
   {

      #region[ Fields ]


      private const string DateTimeFormatConst = "yyyy-MM-dd HH:mm:ss.fffffff";
      private const string DateTimeFormatStringConst = "'{0:" + DateTimeFormatConst + "}'";
      private const string DateTimeOffsetFormatConst = "yyyy-MM-dd HH:mm:ss.fffffffzzz";
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


      public override string EscapeIdentifier(string identifier)
         => Check.NotEmpty(identifier, nameof(identifier)).Replace("`", "``");


      public override void EscapeIdentifier(StringBuilder builder, string identifier)
      {
         Check.NotNull(builder, nameof(builder));
         Check.NotEmpty(identifier, nameof(identifier));


         var initialLength = builder.Length;
         builder.Append(identifier);
         builder.Replace("`", "``", initialLength, identifier.Length);
      }


      public override string DelimitIdentifier(string identifier)
         => $"`{EscapeIdentifier(Check.NotEmpty(identifier, nameof(identifier)))}`"; // Interpolation okay; strings


      public override void DelimitIdentifier(StringBuilder builder, string identifier)
      {
         Check.NotNull(builder, nameof(builder));
         Check.NotEmpty(identifier, nameof(identifier));


         builder.Append('`');
         EscapeIdentifier(builder, identifier);
         builder.Append('`');
      }


      protected override void GenerateLiteralValue(StringBuilder builder, byte[] value)
      {
         Check.NotNull(builder, nameof(builder));
         Check.NotNull(value, nameof(value));


         builder.Append("0x");

         foreach (var @byte in value)
         {
            builder.Append(@byte.ToString("X2", CultureInfo.InvariantCulture));
         }
      }


      protected override string GenerateLiteralValue(bool value)
         => value ? "TRUE" : "FALSE";


      protected override string GenerateLiteralValue(DateTime value)
         => $"'{value.ToString(DateTimeFormat, CultureInfo.InvariantCulture)}'"; // Interpolation okay; strings


      protected override string GenerateLiteralValue(DateTimeOffset value)
         => $"'{value.ToString(DateTimeOffsetFormat, CultureInfo.InvariantCulture)}'"; // Interpolation okay; strings


      #endregion

   }

}
