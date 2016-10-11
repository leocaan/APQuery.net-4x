// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace QueryFramework.Storage
{

	public class DataStoreException : Exception
	{

		#region [ Constructors ]


		public DataStoreException()
		{
		}


		public DataStoreException(string message)
				: base(message)
		{
		}


		public DataStoreException(string message, Exception innerException)
				: base(message, innerException)
		{
		}


		#endregion

	}

}
