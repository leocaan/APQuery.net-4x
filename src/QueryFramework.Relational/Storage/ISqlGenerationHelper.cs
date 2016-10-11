// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Text;

namespace QueryFramework.Storage
{

   public interface ISqlGenerationHelper
   {

      #region [ Properties ]


      string StatementTerminator { get; }


      string BatchTerminator { get; }


      #endregion


      #region [ Methods ]


      string GenerateParameterName(string name);


      void GenerateParameterName(StringBuilder builder, string name);


      string GenerateLiteral(object value, RelationalTypeMapping typeMapping = null);


      void GenerateLiteral(StringBuilder builder, object value, RelationalTypeMapping typeMapping = null);


      string EscapeLiteral(string literal);


      void EscapeLiteral(StringBuilder builder, string literal);


      string EscapeIdentifier(string identifier);


      void EscapeIdentifier(StringBuilder builder, string identifier);


      string DelimitIdentifier(string identifier);


      void DelimitIdentifier(StringBuilder builder, string identifier);


      string DelimitIdentifier(string name, string schema);


      void DelimitIdentifier(StringBuilder builder, string name, string schema);


      #endregion

   }

}
