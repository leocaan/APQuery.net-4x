#if Test_SqlSyntex
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueryFramework.Business.DbDef;
using QueryFramework.Query;
using QueryFramework.Query.SqlSyntex;
using System;

namespace QueryFramework.Tests.Query
{

   [TestClass]
   public class Select_SelectClause_Test
   {

      [TestMethod]
      public virtual void Column_Expr()
      {
         var t = CrmDbDef.department;

         APQuery
            .select(t.DepartmentId, t.ParentId, t.DepartmentName, t.CreateDate, t.CancelDate, t.State)
            .from(t)
            .print("SELECT table_source.column_name");
      }


      [TestMethod]
      public virtual void ProjectStar_Expr()
      {
         var t = CrmDbDef.department;

         APQuery
            .select(SqlExpr.Star)
            .from(t)
            .print("SELECT *");

         APQuery
            .select("*")
            .from(t)
            .print("string '*'");

         APQuery
            .select(t.ProjectStar)
            .from(t)
            .print("SELECT table_source.*");
      }


      [TestMethod]
      public virtual void Constant_Expr()
      {
         var t = CrmDbDef.department;

         // direct

         int? maybeNull = null;

         APQuery
            .select(
               maybeNull,              // may by null
               null,                   // null
               5,                      // number
               true,                   // boolean
               "Tom's name",           // string
               DateTime.Now,           // DateTime
               DateTimeOffset.Now,     // DateTimeOffset
               Guid.NewGuid(),         // Guid
               TimeSpan.Zero           // TimeSpan
               )
            .print("Kinds of Constant");


         // exact

         APQuery
            .select(
               SqlExpr.Constant(maybeNull),              // may by null
               SqlExpr.Constant(null),                   // null
               SqlExpr.Constant(5),                      // number
               SqlExpr.Constant(true),                   // boolean
               SqlExpr.Constant("Tom's name"),           // string
               SqlExpr.Constant(DateTime.Now),           // DateTime
               SqlExpr.Constant(DateTimeOffset.Now),     // DateTimeOffset
               SqlExpr.Constant(Guid.NewGuid()),         // Guid
               SqlExpr.Constant(TimeSpan.Zero)           // TimeSpan
               )
            .print("Kinds of Constant use SqlExpr.Constant(obj)");

      }


      [TestMethod]
      public virtual void Alias_Expr()
      {
         var t = CrmDbDef.department;

         APQuery
            .select(t.DepartmentId.As("id"), t.ParentId.As("pid"), t.DepartmentName.As("name"))
            .from(t)
            .print("SELECT table_source.column_name AS column_alias");
      }


      [TestMethod]
      public virtual void Binary_Expr()
      {
         var t = CrmDbDef.department;

         APQuery
            .select(SqlExpr.Add(3, 5))
            .print("... + ...");

      }

   }

}
#endif