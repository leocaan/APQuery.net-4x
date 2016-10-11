using QueryFramework.Query.Sql;
using System;
using System.IO;

namespace QueryFramework.Query.SqlSyntex
{

   public static class TestHelper
   {
      static string lineSep = new string('-', 100);


      public static void print(ISqlGenerator generator, SqlSelectExpr query, string description = null)
      {
         if (description != null)
         {
            Console.WriteLine(description);
            Console.WriteLine(lineSep);
         }

         try
         {
            generator.GenerateSelect(query);

            Console.WriteLine("Sql: ");
            using (var reader = new StringReader(generator.SqlString))
            {
               string line;
               while ((line = reader.ReadLine()) != null)
               {
                  Console.WriteLine('\t' + line);
               }
            }


            if (generator.Parameters.Count > 0)
            {
               Console.WriteLine("Parameters: ");
               foreach (var item in generator.Parameters)
               {
                  Console.WriteLine('\t' +
                     String.Format("invariantName: {0}, name: {1}, value: {2}",
                        item.InvariantName, item.Name, item.Value));
               }
            }
         }
         catch (Exception ex)
         {
            Console.WriteLine("Has Exception occured: ");
            Console.WriteLine('\t' + ex.Message);
         }


         Console.WriteLine();
         Console.WriteLine();
      }

   }

}
