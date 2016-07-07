using System;

namespace Symber.Data.Tests.Business.DataDef
{

	public class Department
	{

		public virtual uint DepartmentId { get; set; }
		public virtual int? ParentId { get; set; }
		public virtual string DepartmentName { get; set; }
		public virtual DateTime CreateDate { get; set; }
		public virtual DateTime? CancelDate { get; set; }
		public virtual bool State { get; set; }

	}

}
