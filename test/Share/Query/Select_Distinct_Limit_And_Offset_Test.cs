#if Test_SqlSyntex
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueryFramework.Business.DbDef;
using QueryFramework.Query;
using QueryFramework.Query.SqlSyntex;

namespace QueryFramework.Tests.Query
{

   [TestClass]
   public class Select_Distinct_Limit_And_Offset_Test
   {

      [TestMethod]
      public virtual void Distinct()
      {
         var t = CrmDbDef.department;

         APQuery
            .select(t.DepartmentId, t.DepartmentName)
            .from(t)
            .distinct()
            .print("SELECT DISTINCT ...");
      }


      [TestMethod]
      public virtual void Limit_Offset()
      {
         var t = CrmDbDef.department;


         // limit

         APQuery
            .select(t.ProjectStar)
            .from(t)
            .where(t.ParentId != null)
            .take(10)
            .print("Only limit");


         // offset

         APQuery
           .select(t.ProjectStar)
           .from(t)
           .skip(100)
           .print("Only Offset");


         // limit and offset with ordery

         APQuery
            .select(t.DepartmentId, t.DepartmentName.As("name"), t.ParentId)
            .from(t)
            .order_by(t.DepartmentId.Desc, t.DepartmentName.As("name").Desc)
            .skip(100)
            .take(10)
            .print("limit and offset with order");


         // limit and offset without ordery

         APQuery
            .select(t.ProjectStar)
            .from(t)
            .skip(100)
            .take(10)
            .print("limit and offset without order");
      }

   }

}
#endif