// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Utilities;
using System;
using System.Data.Common;

namespace QueryFramework.Storage.Internal
{

   public class DynamicRelationalParameter : IRelationalParameter
   {

      #region [ Fields ]


      private readonly IRelationalTypeMapper _typeMapper;


      #endregion


      #region [ Constructors ]


      public DynamicRelationalParameter(
         string invariantName,
         string name,
         object value,
         IRelationalTypeMapper typeMapper)
      {
         Check.NotEmpty(name, nameof(name));
         Check.NotNull(typeMapper, nameof(typeMapper));


         InvariantName = invariantName;
         Name = name;
         Value = value;
         _typeMapper = typeMapper;
      }


      #endregion


      #region [ Properties ]


      public virtual string InvariantName { get; }


      public virtual string Name { get; }


      public virtual object Value { get; }


      #endregion


      #region [ Methods ]


      public virtual void AddDbParameter(DbCommand command)
      {
         Check.NotNull(command, nameof(command));


         if (Value == null)
         {
            command.Parameters
               .Add(_typeMapper.GetMappingForValue(null)
                  .CreateParameter(command, Name, null));

            return;
         }

         var dbParameter = Value as DbParameter;

         if (dbParameter != null)
         {
            command.Parameters.Add(dbParameter);

            return;
         }

         var type = Value.GetType();

         command.Parameters
            .Add(_typeMapper.GetMapping(type)
            .CreateParameter(command, Name, Value, type.IsNullableType()));
      }


      #endregion

   }

}
