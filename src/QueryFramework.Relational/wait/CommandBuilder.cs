using QueryFramework.Query.Sql;
using QueryFramework.Query.SqlSyntex;
using QueryFramework.Relational;
using QueryFramework.Utilities;
using System;
using System.Data.Common;

namespace QueryFramework.Storage
{

   public class CommandBuilder
   {

      #region [ Fields ]


      private readonly Func<ISqlGenerator> _sqlGeneratorFactory;


      #endregion


      #region [ Constructors ]


      public CommandBuilder(Func<ISqlGenerator> sqlGeneratorFactory)
      {
         Check.NotNull(sqlGeneratorFactory, nameof(sqlGeneratorFactory));

         _sqlGeneratorFactory = sqlGeneratorFactory;
      }


      #endregion


      #region [ Methods ]


      public virtual DbCommand Build(IRelationalConnection connection, SqlSelectExpr query)
      {
         Check.NotNull(connection, nameof(connection));


         // TODO: Cache command...

         var command = connection.DbConnection.CreateCommand();

         if (connection.Transaction != null)
         {
            command.Transaction = connection.Transaction.DbTransaction;
         }

         if (connection.CommandTimeout != null)
         {
            command.CommandTimeout = (int)connection.CommandTimeout;
         }

         var sqlGenerator = _sqlGeneratorFactory();

         sqlGenerator.GenerateSelect(query);

         command.CommandText = sqlGenerator.SqlString;

         foreach (var commandParameter in sqlGenerator.Parameters)
         {
            commandParameter.AddDbParameter(command);
         }

         return command;
      }


      #endregion

   }

}
