// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace QueryFramework.Storage
{

   public interface IRelationalCommand
   {

      #region [ Properties ]


      string CommandText { get; }


      IReadOnlyList<IRelationalParameter> Parameters { get; }


      #endregion


      #region [ Methods ]

      // todo
      //int ExecuteNonQuery(
      //		IRelationalConnection connection,
      //		IReadOnlyDictionary<string, object> parameterValues = null,
      //		bool manageConnection = true);

      //Task<int> ExecuteNonQueryAsync(
      //	 IRelationalConnection connection,
      //	 IReadOnlyDictionary<string, object> parameterValues = null,
      //	 bool manageConnection = true,
      //	 CancellationToken cancellationToken = default(CancellationToken));

      //object ExecuteScalar(
      //	IRelationalConnection connection,
      //	IReadOnlyDictionary<string, object> parameterValues = null,
      //	bool manageConnection = true);

      //Task<object> ExecuteScalarAsync(
      //	IRelationalConnection connection,
      //	IReadOnlyDictionary<string, object> parameterValues = null,
      //	bool manageConnection = true,
      //	CancellationToken cancellationToken = default(CancellationToken));

      //RelationalDataReader ExecuteReader(
      //	 IRelationalConnection connection,
      //	 IReadOnlyDictionary<string, object> parameterValues = null,
      //	 bool manageConnection = true);

      //Task<RelationalDataReader> ExecuteReaderAsync(
      //	IRelationalConnection connection,
      //	IReadOnlyDictionary<string, object> parameterValues = null,
      //	bool manageConnection = true,
      //	CancellationToken cancellationToken = default(CancellationToken));


      #endregion

   }

}
