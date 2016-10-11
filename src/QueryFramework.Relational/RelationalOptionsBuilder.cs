// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Utilities;

namespace QueryFramework.Relational
{

   public class RelationalOptionsBuilder
   {

      #region [ Constructors ]


      public RelationalOptionsBuilder(DataStoreOptionsBuilder optionsBuilder)
      {
         Check.NotNull(optionsBuilder, nameof(optionsBuilder));


         OptionsBuilder = optionsBuilder;
      }


      #endregion


      #region [ Properties ]


      protected DataStoreOptionsBuilder OptionsBuilder { get; }


      #endregion

   }

}
