using Symber.Data.SqlSyntex;
using System.Collections.Generic;
using System.Linq;

namespace Symber.Data.SqlGen
{

	public class SqlTableAliasGenerator
	{

		#region [ Helper Class ]


		class SourceAlias
		{

			public SqlQuerySourceExpr Table { get; set; }


			public string Alias { get; set; }

		}

		
		#endregion


		#region [ Fields ]


		private List<SourceAlias> _sourceAlias = new List<SourceAlias>();
		private Dictionary<string, int> _hash = new Dictionary<string, int>();


		#endregion


		#region [ Methods ]


		public virtual string GetAlias(SqlQuerySourceExpr table)
		{
			var alias = _sourceAlias.Find(m => m.Table == table)?.Alias;

			if (alias != null)
			{
				return alias;
			}


			string firstChar = table.Alias?? "t";
			if (table.Alias == null)
			{
				var isTable = table as SqlTableExpr;

				if (isTable != null)
				{
					firstChar = isTable.Name.First().ToString().ToLower();
				}
			}

			SourceAlias newSourceAlias = null;

			if (_hash.ContainsKey(firstChar))
			{
				newSourceAlias = new SourceAlias
				{
					Table = table,
					Alias = firstChar + _hash[firstChar]++
				};
			}
			else
			{
				newSourceAlias = new SourceAlias
				{
					Table = table,
					Alias = firstChar
				};
				_hash.Add(firstChar, 1);
			}
			_sourceAlias.Add(newSourceAlias);

			return newSourceAlias.Alias;
		}


		#endregion

	}

}
