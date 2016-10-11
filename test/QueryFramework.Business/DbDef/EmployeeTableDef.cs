using QueryFramework.Business.DataDef;
using QueryFramework.DBStruct;

namespace QueryFramework.Business.DbDef
{

	public class EmployeeTableDef : TableDef<Employee>
	{

		public EmployeeTableDef() : base(null, null, null)
		{
		}

		public Int32ColumnDef<Employee> EmployeeId { get; } = new Int32ColumnDef<Employee>(m => m.EmployeeId);
		public Int32ColumnDef<Employee> DepartmentId { get; } = new Int32ColumnDef<Employee>(m => m.DepartmentId);
		public StringColumnDef<Employee> Firstname { get; } = new StringColumnDef<Employee>(m => m.Firstname);
		public StringColumnDef<Employee> Lastname { get; } = new StringColumnDef<Employee>(m => m.Lastname);
		public DateTimeColumnDef<Employee> Birthday { get; } = new DateTimeColumnDef<Employee>(m => m.Birthday);
		public BooleanColumnDef<Employee> State { get; } = new BooleanColumnDef<Employee>(m => m.State);

	}

}
