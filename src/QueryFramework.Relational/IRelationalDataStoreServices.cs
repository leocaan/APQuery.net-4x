using QueryFramework.Relational.SqlGen;
using QueryFramework.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryFramework.Relational
{

	public interface IRelationalDataStoreServices : IDataStoreServices
	{

		IRelationalConnection RelationalConnection { get; }


		ISqlGenerator SqlGenerator { get; }

	}

}
