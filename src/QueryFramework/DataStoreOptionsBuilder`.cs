// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace QueryFramework
{

   public class DataStoreOptionsBuilder<TContext> : DataStoreOptionsBuilder
      where TContext : DbContext
   {

      #region [ Constructors ]


      public DataStoreOptionsBuilder()
         : this(new DataStoreOptions<TContext>())
      {
      }

      public DataStoreOptionsBuilder(DataStoreOptions<TContext> options)
         : base(options)
      {
      }


      #endregion


      #region [ Properties ]


      public new virtual DataStoreOptions<TContext> Options
         => (DataStoreOptions<TContext>)base.Options;


      #endregion

   }

}
