// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace QueryFramework.Infrastructure
{

	public interface IAnnotatable
	{

		#region [ Properties ]


		object this[string name] { get; }


		#endregion


		#region [ Methods ]


		IAnnotation FindAnnotation(string name);


		IEnumerable<IAnnotation> GetAnnotations();


		#endregion

	}

}
