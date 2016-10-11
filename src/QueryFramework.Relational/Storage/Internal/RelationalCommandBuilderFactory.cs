// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Utilities;

namespace QueryFramework.Storage.Internal
{

   public class RelationalCommandBuilderFactory : IRelationalCommandBuilderFactory
   {

      #region [ Fields ]


      private readonly IRelationalTypeMapper _typeMapper;


      #endregion


      #region [ Constructors ]


      public RelationalCommandBuilderFactory(IRelationalTypeMapper typeMapper)
      {
         Check.NotNull(typeMapper, nameof(typeMapper));


         _typeMapper = typeMapper;
      }


      #endregion


      #region [ Methods ]


      public virtual IRelationalCommandBuilder Create()
          => new RelationalCommandBuilder(_typeMapper);


      #endregion

   }

}
