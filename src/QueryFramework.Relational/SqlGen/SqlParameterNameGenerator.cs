using System;
using System.Collections.Generic;

namespace QueryFramework.Relational.SqlGen
{

	public class SqlParameterNameGenerator
	{

		#region [ Fields ]


		private Dictionary<string, int> _parameterNameCounter = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
		private int _count;

		#endregion


		#region [ Methods ]


		public virtual string GenerateNext(string originalName)
		{
			if (originalName == null || originalName == "" || originalName == "p")
			{
				return "p" + _count++;
			}

			if (_parameterNameCounter.ContainsKey(originalName))
			{
				return originalName + (++_parameterNameCounter[originalName]);
			}
			else
			{
				_parameterNameCounter.Add(originalName, 0);
				return originalName;
			}
		}


		#endregion

	}

}
