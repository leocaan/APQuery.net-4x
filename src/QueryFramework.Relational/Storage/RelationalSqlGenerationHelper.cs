// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.


using QueryFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;

namespace QueryFramework.Storage
{

   public class RelationalSqlGenerationHelper : ISqlGenerationHelper
   {

      #region [ Fields ]


      private const string DecimalFormatConst = "0.0###########################";
      private const string DecimalFormatStringConst = "{0:" + DecimalFormatConst + "}";
      private const string DateTimeFormatConst = @"yyyy-MM-dd HH\:mm\:ss.fffffff";
      private const string DateTimeFormatStringConst = "TIMESTAMP '{0:" + DateTimeFormatConst + "}'";
      private const string DateTimeOffsetFormatConst = @"yyyy-MM-dd HH\:mm\:ss.fffffffzzz";
      private const string DateTimeOffsetFormatStringConst = "TIMESTAMP '{0:" + DateTimeOffsetFormatConst + "}'";


      private readonly Dictionary<DbType, string> _dbTypeNameMapping
         = new Dictionary<DbType, string> {
            { DbType.Byte, "tinyint" },
            { DbType.Decimal, "decimal" },
            { DbType.Double, "float" },
            { DbType.Int16, "smallint" },
            { DbType.Int32, "int" },
            { DbType.Int64, "bigint" },
            { DbType.String, "nvarchar" },
            { DbType.Date, "date" }
        };


      #endregion


      #region [ Properties ]


      protected virtual string FloatingPointFormatString
         => "{0}E0";


      protected virtual string DecimalFormat
         => DecimalFormatConst;


      protected virtual string DecimalFormatString
         => DecimalFormatStringConst;


      protected virtual string DateTimeFormat
         => DateTimeFormatConst;


      protected virtual string DateTimeFormatString
         => DateTimeFormatStringConst;


      protected virtual string DateTimeOffsetFormat
         => DateTimeOffsetFormatConst;


      protected virtual string DateTimeOffsetFormatString
         => DateTimeOffsetFormatStringConst;


      public virtual string StatementTerminator
         => ";";


      public virtual string BatchTerminator
         => string.Empty;


      #endregion


      #region [ Methods ]


      public virtual string GenerateParameterName(string name)
         => "@" + Check.NotNull(name, nameof(name));


      public virtual void GenerateParameterName(StringBuilder builder, string name)
         => Check.NotNull(builder, nameof(builder))
               .Append("@").Append(Check.NotNull(name, nameof(name)));


      public virtual string GenerateLiteral(object value, RelationalTypeMapping typeMapping = null)
      {
         if (value != null)
         {
            var s = value as string;

            return s != null ? GenerateLiteralValue(s, typeMapping) : GenerateLiteralValue((dynamic)value);
         }


         return "NULL";
      }


      public virtual void GenerateLiteral(StringBuilder builder, object value, RelationalTypeMapping typeMapping = null)
      {
         Check.NotNull(builder, nameof(builder));


         if (value != null)
         {
            var s = value as string;
            if (s != null)
            {
               GenerateLiteralValue(builder, s, typeMapping);
            }
            else
            {
               GenerateLiteralValue(builder, (dynamic)value);
            }
         }

         builder.Append("NULL");
      }


      public virtual string EscapeLiteral(string literal)
         => Check.NotNull(literal, nameof(literal))
               .Replace("'", "''");


      public virtual void EscapeLiteral(StringBuilder builder, string literal)
      {
         Check.NotNull(builder, nameof(builder));
         Check.NotNull(literal, nameof(literal));


         var initialLength = builder.Length;
         builder.Append(literal);
         builder.Replace("'", "''", initialLength, literal.Length);
      }


      public virtual string EscapeIdentifier(string identifier)
         => Check.NotEmpty(identifier, nameof(identifier))
               .Replace("\"", "\"\"");


      public virtual void EscapeIdentifier(StringBuilder builder, string identifier)
      {
         Check.NotNull(builder, nameof(builder));
         Check.NotEmpty(identifier, nameof(identifier));


         var initialLength = builder.Length;
         builder.Append(identifier);
         builder.Replace("\"", "\"\"", initialLength, identifier.Length);
      }


      public virtual string DelimitIdentifier(string identifier)
         => $"\"{EscapeIdentifier(Check.NotEmpty(identifier, nameof(identifier)))}\""; // Interpolation okay; strings


      public virtual void DelimitIdentifier(StringBuilder builder, string identifier)
      {
         Check.NotNull(builder, nameof(builder));
         Check.NotEmpty(identifier, nameof(identifier));


         builder.Append('"');
         EscapeIdentifier(builder, identifier);
         builder.Append('"');
      }


      public virtual string DelimitIdentifier(string name, string schema)
         => (!string.IsNullOrEmpty(schema)
               ? DelimitIdentifier(schema) + "."
               : string.Empty)
            + DelimitIdentifier(Check.NotEmpty(name, nameof(name)));


      public virtual void DelimitIdentifier(StringBuilder builder, string name, string schema)
      {
         Check.NotNull(builder, nameof(builder));
         Check.NotEmpty(name, nameof(name));


         if (!string.IsNullOrEmpty(schema))
         {
            DelimitIdentifier(builder, schema);
            builder.Append(".");
         }

         DelimitIdentifier(builder, name);
      }


      protected virtual string GenerateLiteralValue(int value)
         => value.ToString(CultureInfo.InvariantCulture);


      protected virtual void GenerateLiteralValue(StringBuilder builder, int value)
         => Check.NotNull(builder, nameof(builder))
               .Append(value.ToString(CultureInfo.InvariantCulture));


      protected virtual string GenerateLiteralValue(short value)
         => value.ToString(CultureInfo.InvariantCulture);


      protected virtual void GenerateLiteralValue(StringBuilder builder, short value)
         => Check.NotNull(builder, nameof(builder))
               .Append(value.ToString(CultureInfo.InvariantCulture));


      protected virtual string GenerateLiteralValue(long value)
         => value.ToString(CultureInfo.InvariantCulture);


      protected virtual void GenerateLiteralValue(StringBuilder builder, long value)
         => Check.NotNull(builder, nameof(builder))
               .Append(value.ToString(CultureInfo.InvariantCulture));


      protected virtual string GenerateLiteralValue(byte value)
         => value.ToString(CultureInfo.InvariantCulture);


      protected virtual void GenerateLiteralValue(StringBuilder builder, byte value)
         => Check.NotNull(builder, nameof(builder))
               .Append(value.ToString(CultureInfo.InvariantCulture));


      protected virtual string GenerateLiteralValue(decimal value)
         => value.ToString(DecimalFormat, CultureInfo.InvariantCulture);


      protected virtual void GenerateLiteralValue(StringBuilder builder, decimal value)
         => Check.NotNull(builder, nameof(builder))
               .AppendFormat(CultureInfo.InvariantCulture, DecimalFormatString, value);


      protected virtual string GenerateLiteralValue(double value)
         => string.Format(CultureInfo.InvariantCulture, FloatingPointFormatString, value);


      protected virtual void GenerateLiteralValue(StringBuilder builder, double value)
         => Check.NotNull(builder, nameof(builder))
               .AppendFormat(CultureInfo.InvariantCulture, FloatingPointFormatString, value);


      protected virtual string GenerateLiteralValue(float value)
         => string.Format(CultureInfo.InvariantCulture, FloatingPointFormatString, value);


      protected virtual void GenerateLiteralValue(StringBuilder builder, float value)
         => Check.NotNull(builder, nameof(builder))
               .AppendFormat(CultureInfo.InvariantCulture, FloatingPointFormatString, value);


      protected virtual string GenerateLiteralValue(bool value)
         => value ? "1" : "0";


      protected virtual void GenerateLiteralValue(StringBuilder builder, bool value)
         => Check.NotNull(builder, nameof(builder))
               .Append(value ? "1" : "0");


      protected virtual string GenerateLiteralValue(char value)
         => string.Format(CultureInfo.InvariantCulture, "'{0}'", value);


      protected virtual void GenerateLiteralValue(StringBuilder builder, char value)
         => Check.NotNull(builder, nameof(builder))
               .Append("'")
               .Append(value.ToString())
               .Append("'");


      protected virtual string GenerateLiteralValue(string value, RelationalTypeMapping typeMapping)
         => $"'{EscapeLiteral(Check.NotNull(value, nameof(value)))}'"; // Interpolation okay; strings


      protected virtual void GenerateLiteralValue(StringBuilder builder, string value, RelationalTypeMapping typeMapping)
      {
         Check.NotNull(builder, nameof(builder));
         Check.NotNull(value, nameof(value));


         builder.Append("'");
         EscapeLiteral(builder, value);
         builder.Append("'");
      }


      protected virtual string GenerateLiteralValue(object value)
         => string.Format(CultureInfo.InvariantCulture, "{0}", Check.NotNull(value, nameof(value)));


      protected virtual void GenerateLiteralValue(StringBuilder builder, object value)
         => Check.NotNull(builder, nameof(builder))
               .AppendFormat(CultureInfo.InvariantCulture, "{0}", Check.NotNull(value, nameof(value)));


      protected virtual string GenerateLiteralValue(byte[] value)
      {
         Check.NotNull(value, nameof(value));


         var stringBuilder = new StringBuilder();
         GenerateLiteralValue(stringBuilder, value);


         return stringBuilder.ToString();
      }


      protected virtual void GenerateLiteralValue(StringBuilder builder, byte[] value)
      {
         Check.NotNull(builder, nameof(builder));
         Check.NotNull(value, nameof(value));


         builder.Append("X'");

         foreach (var @byte in value)
         {
            builder.Append(@byte.ToString("X2", CultureInfo.InvariantCulture));
         }

         builder.Append("'");
      }


      protected virtual string GenerateLiteralValue(DbType value)
         => _dbTypeNameMapping[value];


      protected virtual void GenerateLiteralValue(StringBuilder builder, DbType value)
         => Check.NotNull(builder, nameof(builder))
               .Append(_dbTypeNameMapping[value]);


      protected virtual string GenerateLiteralValue(Enum value)
         => string.Format(CultureInfo.InvariantCulture, "{0:d}", Check.NotNull(value, nameof(value)));


      protected virtual void GenerateLiteralValue(StringBuilder builder, Enum value)
         => Check.NotNull(builder, nameof(builder))
               .AppendFormat(CultureInfo.InvariantCulture, "{0:d}", Check.NotNull(value, nameof(value)));


      protected virtual string GenerateLiteralValue(Guid value)
         => string.Format(CultureInfo.InvariantCulture, "'{0}'", value);


      protected virtual void GenerateLiteralValue(StringBuilder builder, Guid value)
         => Check.NotNull(builder, nameof(builder))
               .Append("'")
               .Append(value)
               .Append("'");


      protected virtual string GenerateLiteralValue(DateTime value)
         => $"TIMESTAMP '{value.ToString(DateTimeFormat, CultureInfo.InvariantCulture)}'"; // Interpolation okay; strings


      protected virtual void GenerateLiteralValue(StringBuilder builder, DateTime value)
         => Check.NotNull(builder, nameof(builder))
               .AppendFormat(CultureInfo.InvariantCulture, DateTimeFormatString, value);


      protected virtual string GenerateLiteralValue(DateTimeOffset value)
         => $"TIMESTAMP '{value.ToString(DateTimeOffsetFormat, CultureInfo.InvariantCulture)}'"; // Interpolation okay; strings


      protected virtual void GenerateLiteralValue(StringBuilder builder, DateTimeOffset value)
         => Check.NotNull(builder, nameof(builder))
               .AppendFormat(CultureInfo.InvariantCulture, DateTimeOffsetFormatString, value);


      protected virtual string GenerateLiteralValue(TimeSpan value)
         => String.Format(CultureInfo.InvariantCulture, "'{0}'", value);


      protected virtual void GenerateLiteralValue(StringBuilder builder, TimeSpan value)
         => Check.NotNull(builder, nameof(builder))
               .Append("'")
               .Append(value)
               .Append("'");


      #endregion

   }

}
