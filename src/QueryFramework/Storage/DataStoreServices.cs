// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Infrastructure;
using QueryFramework.Utilities;

namespace QueryFramework.Storage
{

	public abstract class DataStoreServices : IDataStoreServices
	{

		#region [ Constructors ]


		protected DataStoreServices(IDataStoreOptions options)
		{
			Check.NotNull(options, nameof(options));
		}


		#endregion


		#region [ Properties ]


		public abstract IDataStoreConnection Connection { get; }


		#endregion

	}

}
