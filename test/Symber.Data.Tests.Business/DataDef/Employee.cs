using System;

namespace Symber.Data.Tests.Business.DataDef
{

	public class Employee
	{

		public virtual int EmployeeId { get; set; }
		public virtual int DepartmentId { get; set; }
		public virtual string Firstname { get; set; }
		public virtual string Lastname { get; set; }
		public virtual DateTime Birthday { get; set; }
		public virtual bool State { get; set; }

	}

}
