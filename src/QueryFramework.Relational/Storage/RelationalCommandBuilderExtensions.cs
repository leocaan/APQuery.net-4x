// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.


using QueryFramework.Utilities;
using System;

namespace QueryFramework.Storage
{

   public static class RelationalCommandBuilderExtensions
   {

      #region [ Methods ]


      public static IRelationalCommandBuilder Append(this IRelationalCommandBuilder commandBuilder, object o)
      {
         Check.NotNull(commandBuilder, nameof(commandBuilder));
         Check.NotNull(o, nameof(o));


         commandBuilder.Instance.Append(o);


         return commandBuilder;
      }


      public static IRelationalCommandBuilder AppendLine(this IRelationalCommandBuilder commandBuilder)
      {
         Check.NotNull(commandBuilder, nameof(commandBuilder));


         commandBuilder.Instance.AppendLine();


         return commandBuilder;
      }


      public static IRelationalCommandBuilder AppendLine(this IRelationalCommandBuilder commandBuilder, object o)
      {
         Check.NotNull(commandBuilder, nameof(commandBuilder));
         Check.NotNull(o, nameof(o));


         commandBuilder.Instance.AppendLine(o);


         return commandBuilder;
      }


      public static IRelationalCommandBuilder AppendLines(this IRelationalCommandBuilder commandBuilder, object o)
      {
         Check.NotNull(commandBuilder, nameof(commandBuilder));
         Check.NotNull(o, nameof(o));


         commandBuilder.Instance.AppendLines(o);


         return commandBuilder;
      }


      public static IRelationalCommandBuilder IncrementIndent(this IRelationalCommandBuilder commandBuilder)
      {
         Check.NotNull(commandBuilder, nameof(commandBuilder));


         commandBuilder.Instance.IncrementIndent();


         return commandBuilder;
      }


      public static IRelationalCommandBuilder DecrementIndent(this IRelationalCommandBuilder commandBuilder)
      {
         Check.NotNull(commandBuilder, nameof(commandBuilder));


         commandBuilder.Instance.DecrementIndent();


         return commandBuilder;
      }


      public static IDisposable Indent(this IRelationalCommandBuilder commandBuilder)
          => Check.NotNull(commandBuilder, nameof(commandBuilder)).Instance.Indent();


      public static int GetLength(this IRelationalCommandBuilder commandBuilder)
          => Check.NotNull(commandBuilder, nameof(commandBuilder)).Instance.Length;


      public static IRelationalCommandBuilder AddParameter(
         this IRelationalCommandBuilder commandBuilder,
         string invariantName,
         string name,
         object value)
      {
         commandBuilder.ParameterBuilder.AddParameter(invariantName, name, value);


         return commandBuilder;
      }


      #endregion

   }

}
