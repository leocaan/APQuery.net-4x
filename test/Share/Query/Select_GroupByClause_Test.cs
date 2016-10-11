#if Test_SqlSyntex
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueryFramework.Business.DbDef;
using QueryFramework.Query;
using QueryFramework.Query.SqlSyntex;

namespace QueryFramework.Tests.Query
{

   [TestClass]
   public class Select_GroupByClause_Test
   {

      [TestMethod]
      public virtual void Groupby_and_Having()
      {
         var t = CrmDbDef.department;

         APQuery
            .select(t.DepartmentId, t.DepartmentName)
            .from(t)
            .group_by(t.DepartmentId, t.DepartmentName)
            .print("GROUP BY ...");


         APQuery
            .select(t.DepartmentId, t.DepartmentName)
            .from(t)
            .group_by(t.DepartmentId, t.DepartmentName)
            .having(t.DepartmentId == 0)
            .print("GROUP BY ... HAVING ...");


         APQuery
            .select(t.DepartmentId, t.DepartmentName)
            .from(t)
            .group_by(t.ParentId, SqlExpr.Rollup(t.DepartmentId, t.DepartmentName))
            .print("GROUP BY ..., ROLLUP (...)");


         APQuery
            .select(t.DepartmentId, t.DepartmentName)
            .from(t)
            .group_by(t.ParentId, SqlExpr.Cube(t.DepartmentId, t.DepartmentName))
            .print("GROUP BY ..., CUBE (...)");


         APQuery
            .select(t.DepartmentId, t.DepartmentName)
            .from(t)
            .group_by(t.ParentId, SqlExpr.GroupingSets(t.DepartmentId, t.DepartmentName))
            .print("GROUP BY ..., GROUPING SETS (...)");
      }

   }

}
#endif