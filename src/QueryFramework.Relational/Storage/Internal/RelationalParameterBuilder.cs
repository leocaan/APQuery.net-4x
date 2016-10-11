// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Utilities;
using System.Collections.Generic;

namespace QueryFramework.Storage.Internal
{

   public class RelationalParameterBuilder : IRelationalParameterBuilder
   {

      #region [ Fields ]


      private readonly List<IRelationalParameter> _parameters = new List<IRelationalParameter>();


      #endregion


      #region [ Constructors ]


      public RelationalParameterBuilder(IRelationalTypeMapper typeMapper)
      {
         Check.NotNull(typeMapper, nameof(typeMapper));


         TypeMapper = typeMapper;
      }


      #endregion


      #region [ Properties ]


      public virtual IReadOnlyList<IRelationalParameter> Parameters
         => _parameters;


      protected virtual IRelationalTypeMapper TypeMapper { get; }


      #endregion


      #region [ Methods ]


      public virtual void AddParameter(string invariantName, string name, object value)
         => _parameters.Add(
            new DynamicRelationalParameter(
               invariantName,
               name,
               value,
               TypeMapper));


      #endregion

   }

}
