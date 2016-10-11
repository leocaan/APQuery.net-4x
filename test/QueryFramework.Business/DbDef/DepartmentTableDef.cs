using QueryFramework.Business.DataDef;
using QueryFramework.DBStruct;

namespace QueryFramework.Business.DbDef
{

	public class DepartmentTableDef : TableDef<Department>
	{

		public DepartmentTableDef() : base(null, null, null)
		{
		}

		public Int32ColumnDef<Department> DepartmentId { get; } = new Int32ColumnDef<Department>(m => m.DepartmentId);
		public Int32ColumnDef<Department> ParentId { get; } = new Int32ColumnDef<Department>(m => m.ParentId);
		public StringColumnDef<Department> DepartmentName { get; } = new StringColumnDef<Department>(m => m.DepartmentName);
		public DateTimeColumnDef<Department> CreateDate { get; } = new DateTimeColumnDef<Department>(m => m.CreateDate);
		public DateTimeColumnDef<Department> CancelDate { get; } = new DateTimeColumnDef<Department>(m => m.CancelDate);
		public BooleanColumnDef<Department> State { get; } = new BooleanColumnDef<Department>(m => m.State);

	}

}
