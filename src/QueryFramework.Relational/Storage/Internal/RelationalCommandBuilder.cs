// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Infrastructure;
using QueryFramework.Internal;
using QueryFramework.Utilities;

namespace QueryFramework.Storage.Internal
{

   public class RelationalCommandBuilder : IRelationalCommandBuilder
   {

      #region [ Fields ]


      private readonly IndentedStringBuilder _commandTextBuilder = new IndentedStringBuilder();


      #endregion


      #region [ Constructors ]


      public RelationalCommandBuilder(IRelationalTypeMapper typeMapper)
      {
         Check.NotNull(typeMapper, nameof(typeMapper));


         ParameterBuilder = new RelationalParameterBuilder(typeMapper);
      }


      #endregion


      #region [ Properties ]


      IndentedStringBuilder IInfrastructure<IndentedStringBuilder>.Instance
          => _commandTextBuilder;


      public virtual IRelationalParameterBuilder ParameterBuilder { get; }


      #endregion


      #region [ Methods ]


      public virtual IRelationalCommand Build()
         => new RelationalCommand(
               _commandTextBuilder.ToString(),
               ParameterBuilder.Parameters);


      #endregion


      #region [ Override Implementation of Object ]


      public override string ToString()
         => _commandTextBuilder.ToString();


      #endregion

   }

}
