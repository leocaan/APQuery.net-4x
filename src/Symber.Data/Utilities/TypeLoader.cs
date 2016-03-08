﻿using System;
using System.Reflection;

namespace Symber.Data.Utilities
{

	internal class TypeLoader
	{

		public static Type LoadType(string typeName)
		{
			Check.NotEmpty(typeName, nameof(typeName));

			Type type;

			if (null != (type = Type.GetType(typeName)))
				return type;

			if (null != (type = Assembly.GetExecutingAssembly().GetType(typeName)))
				return type;

			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				if (null != (type = assembly.GetType(typeName)))
					return type;
			}

			return null;
		}

	}

}
