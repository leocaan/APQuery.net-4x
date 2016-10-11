#if Test_SqlSyntex
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueryFramework.Business.DbDef;
using QueryFramework.Query;
using QueryFramework.Query.SqlSyntex;

namespace QueryFramework.Tests.Query
{

   [TestClass]
   public class Select_OrderByClause_Test
   {

      [TestMethod]
      public virtual void OrderBy()
      {
         var t = CrmDbDef.department;

         APQuery
            .select(t.DepartmentId, t.ParentId, t.DepartmentName, t.CreateDate, t.CancelDate, t.State)
            .from(t)
            .order_by(t.State.Asc, t.DepartmentName.Desc)
            .print("ORDER BY ...");


         APQuery
            .select(t.DepartmentId.As("id"), t.DepartmentName.As("name"))
            .from(t)
            .order_by(t.DepartmentId.As("id").Asc, SqlExpr.AsReference("name").Desc)
            .print("ORDER BY alias");
      }

   }

}
#endif