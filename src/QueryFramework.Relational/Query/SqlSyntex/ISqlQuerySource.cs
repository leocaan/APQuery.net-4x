// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace QueryFramework.Query.SqlSyntex
{

   public interface ISqlQuerySource
   {

      string Schema { get; }


      string Name { get; }


      string Alias { get; }

   }

}
