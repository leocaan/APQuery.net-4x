using QueryFramework.Query.Sql;
using QueryFramework.Storage;
using QueryFramework.Storage.Internal;

namespace QueryFramework.Query.SqlSyntex
{

   public static partial class SqlSelectExprExtensions
   {

      public static void print(this SqlSelectExpr query, string description = null)
      {
         var typeMapper = new SqlServerTypeMapper();
         var commandBuilderFactory = new RelationalCommandBuilderFactory(typeMapper);
         var generationHelper = new SqlServerSqlGenerationHelper();
         var parameterNameGeneratorFactory = new ParameterNameGeneratorFactory();
         var querySourceAliasGeneratorFactory = new QuerySourceAliasGeneratorFactory();


         var generator = new SqlServerSqlGenerator(
            commandBuilderFactory,
            generationHelper,
            parameterNameGeneratorFactory,
            querySourceAliasGeneratorFactory,
            typeMapper
            );


         TestHelper.print(generator, query, description);
      }

   }

}
