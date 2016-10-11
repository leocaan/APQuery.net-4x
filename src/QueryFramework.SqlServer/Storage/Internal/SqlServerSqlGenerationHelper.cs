// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Utilities;
using System;
using System.Globalization;
using System.Text;

namespace QueryFramework.Storage.Internal
{

   public class SqlServerSqlGenerationHelper : RelationalSqlGenerationHelper
   {

      #region[ Fields ]


      private const string DateTimeFormatConst = "yyyy-MM-ddTHH:mm:ss.fffK";
      private const string DateTimeFormatStringConst = "'{0:" + DateTimeFormatConst + "}'";
      private const string DateTimeOffsetFormatConst = "yyyy-MM-ddTHH:mm:ss.fffzzz";
      private const string DateTimeOffsetFormatStringConst = "'{0:" + DateTimeOffsetFormatConst + "}'";


      #endregion


      #region [ Properties ]


      public override string BatchTerminator
         => "GO" + Environment.NewLine + Environment.NewLine;


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
         => Check.NotEmpty(identifier, nameof(identifier)).Replace("]", "]]");


      public override void EscapeIdentifier(StringBuilder builder, string identifier)
      {
         Check.NotNull(builder, nameof(builder));
         Check.NotEmpty(identifier, nameof(identifier));


         var initialLength = builder.Length;
         builder.Append(identifier);
         builder.Replace("]", "]]", initialLength, identifier.Length);
      }


      public override string DelimitIdentifier(string identifier)
         => $"[{EscapeIdentifier(Check.NotEmpty(identifier, nameof(identifier)))}]"; // Interpolation okay; strings


      public override void DelimitIdentifier(StringBuilder builder, string identifier)
      {
         Check.NotNull(builder, nameof(builder));
         Check.NotEmpty(identifier, nameof(identifier));


         builder.Append('[');
         EscapeIdentifier(builder, identifier);
         builder.Append(']');
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


      protected override string GenerateLiteralValue(string value, RelationalTypeMapping typeMapping = null)
         => typeMapping == null || typeMapping.IsUnicode
            ? $"N'{EscapeLiteral(Check.NotNull(value, nameof(value)))}'" // Interpolation okay; strings
            : $"'{EscapeLiteral(Check.NotNull(value, nameof(value)))}'";


      protected override void GenerateLiteralValue(StringBuilder builder, string value, RelationalTypeMapping typeMapping = null)
      {
         builder.Append(typeMapping.IsUnicode ? "N'" : "'");
         EscapeLiteral(builder, value);
         builder.Append("'");
      }


      protected override string GenerateLiteralValue(DateTime value)
         => $"'{value.ToString(DateTimeFormat, CultureInfo.InvariantCulture)}'"; // Interpolation okay; strings


      protected override string GenerateLiteralValue(DateTimeOffset value)
         => $"'{value.ToString(DateTimeOffsetFormat, CultureInfo.InvariantCulture)}'"; // Interpolation okay; strings


      #endregion

   }

}
