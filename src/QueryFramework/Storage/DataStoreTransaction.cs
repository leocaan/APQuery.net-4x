// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace QueryFramework.Storage
{

	public abstract class DataStoreTransaction : IDisposable
	{

		#region [ Properties ]


		public abstract void Commit();


		public abstract void Rollback();


		public abstract void Dispose();


		#endregion

	}

}
