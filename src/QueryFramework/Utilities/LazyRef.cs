// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics;

namespace QueryFramework.Utilities
{

	[DebuggerStepThrough]
	public sealed class LazyRef<T>
	{

		#region [ Fields ]


		private Func<T> _initializer;
		private T _value;


		#endregion


		#region [ Constructors ]


		public LazyRef(Func<T> initializer)
		{
			Check.NotNull(initializer, nameof(initializer));


			_initializer = initializer;
		}


		public LazyRef(T value)
		{
			_value = value;
		}


		#endregion


		#region [ Properties ]


		public T Value
		{
			get
			{
				if (_initializer != null)
				{
					_value = _initializer();
					_initializer = null;
				}

				return _value;
			}
			set
			{
				Check.NotNull(value, nameof(value));

				_value = value;
				_initializer = null;
			}
		}


		public bool HasValue
			=> _initializer == null;


		#endregion


		#region [ Methods ]


		public void Reset(Func<T> initializer)
		{
			Check.NotNull(initializer, nameof(initializer));


			_initializer = initializer;
			_value = default(T);
		}


		#endregion

	}

}
