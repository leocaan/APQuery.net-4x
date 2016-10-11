#if Test_SqlSyntex
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueryFramework.Business.DbDef;
using QueryFramework.Query;
using QueryFramework.Query.SqlSyntex;

namespace QueryFramework.Tests.Query
{

   [TestClass]
   public class Select_FromClause_Test
   {

      [TestMethod]
      public virtual void Table_Alias()
      {
         var t = CrmDbDef.department;


         APQuery
            .select(t.DepartmentId, t.ParentId)
            .from(t)
            .print("Auto generate table alias name");


         var t2 = CrmDbDef.department.As<DepartmentTableDef>("t2");
         APQuery
            .select(t2.DepartmentId, t2.ParentId)
               .from(t2)
               .print("Focus generate table alias name");
      }


      [TestMethod]
      public virtual void Join_Expr()
      {
         var t = CrmDbDef.department;
         var e = CrmDbDef.employee;


         APQuery
            .select(e.EmployeeId, t.DepartmentName, e.Firstname, e.Lastname, e.Birthday, e.State)
            .from(t)
            .innerJoin(e, t.DepartmentId == e.DepartmentId)
            .print("... INNER JOIN ...");


         APQuery
            .select(e.EmployeeId, t.DepartmentName, e.Firstname, e.Lastname, e.Birthday, e.State)
            .from(t)
            .leftJoin(e, t.DepartmentId == e.DepartmentId)
            .print("... LEFT JOIN ...");


         APQuery
           .select(e.EmployeeId, t.DepartmentName, e.Firstname, e.Lastname, e.Birthday, e.State)
           .from(t)
           .rightJoin(e, t.DepartmentId == e.DepartmentId)
           .print("... RIGHT JOIN ...");


         APQuery
            .select(e.EmployeeId, t.DepartmentName, e.Firstname, e.Lastname, e.Birthday, e.State)
            .from(t)
            .fullJoin(e, t.DepartmentId == e.DepartmentId)
            .print("... FULL JOIN ...");


         APQuery
            .select(e.EmployeeId, t.DepartmentName, e.Firstname, e.Lastname, e.Birthday, e.State)
            .from(t)
            .lateralJoin(e)
            .print("... CROSS JOIN LATERAL or CROSS APPLY ...");


         var t1 = t.As<DepartmentTableDef>("dp");

         APQuery
            .select(t.DepartmentId, t.DepartmentName, t1.DepartmentName)
            .from(t)
            .innerJoin(t1, t.ParentId == t1.DepartmentId)
            .print("Self join with table alias");
      }

   }

}
#endif