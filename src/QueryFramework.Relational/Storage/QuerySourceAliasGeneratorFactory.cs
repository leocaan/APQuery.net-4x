// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.


namespace QueryFramework.Storage
{

   public class QuerySourceAliasGeneratorFactory : IQuerySourceAliasGeneratorFactory
   {

      #region [ Methods ]


      public virtual QuerySourceAliasGenerator Create()
         => new QuerySourceAliasGenerator();


      #endregion

   }

}
