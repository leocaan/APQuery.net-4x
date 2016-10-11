#if Test_SqlSyntex
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueryFramework.Business.DbDef;
using QueryFramework.Query;
using QueryFramework.Query.SqlSyntex;

namespace QueryFramework.Tests.Query
{

   [TestClass]
   public class Select_CombineResult_Test
   {

      [TestMethod]
      public virtual void CombineResult_Exprs()
      {
         var t = CrmDbDef.department;

         var query1 = APQuery
            .select(t.DepartmentId, t.DepartmentName)
            .from(t)
            .where(t.ParentId == 1);

         var query2 = APQuery
            .select(t.DepartmentId, t.DepartmentName)
            .from(t)
            .where(t.ParentId == 2);

         var query3 = APQuery
            .select(t.DepartmentId, t.DepartmentName)
            .from(t)
            .where(t.ParentId == 3);


         // union

         query1
            .union(query2)
            .print("... UNION ...");


         // union all

         query1.ClearCombineResults();
         query1
            .union_all(query2)
            .print("... UNION ALL ...");


         // intersect

         query1.ClearCombineResults();
         query1
            .intersect(query2)
            .print("... INTERSECT ...");


         // minus

         query1.ClearCombineResults();
         query1
            .intersect(query2)
            .print("... MINUS ...");


         // recursive union

         query1.ClearCombineResults();
         query1
            .union_all(query2
               .union(query3))
            .print("... UNION ALL ( ... UNION ... )");
      }

   }

}
#endif