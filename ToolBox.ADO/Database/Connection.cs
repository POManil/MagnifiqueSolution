using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;

namespace ToolBox.ADO.Database
{
   public class Connection
   {
      private readonly DbProviderFactory _Factory;

      public readonly string _ConnectionString;

      public Connection(string connectionString, string invariantName)
      {
         _Factory = DbProviderFactories.GetFactory(invariantName);
         _ConnectionString = connectionString;
      }

      private IDbConnection CreateConnection()
      {
         IDbConnection connection = _Factory.CreateConnection();
         connection.ConnectionString = _ConnectionString;
         return connection;
      }


      private IDbCommand CreateCommand(IDbConnection conn, Command cmd)
      {
         IDbCommand command = conn.CreateCommand();
         command.CommandText = cmd._Query;
         foreach (KeyValuePair<string,object> kvp in cmd._Parameters)
         {
            IDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = kvp.Key;
            parameter.Value = kvp.Value;
            command.Parameters.Add(parameter);
         }
         return command;
      }

      public IEnumerable<T> ExecuteReader<T>(Command cmd, Func<IDataReader,T> selector)
      {
         using (IDbConnection conn = CreateConnection())
         {
            conn.Open();
            using (IDbCommand command = CreateCommand(conn, cmd))
            {
               IDataReader reader = command.ExecuteReader();
               while (reader.Read())
               {
                  yield return selector(reader);
               }
            }
         }
      }

      public int ExecuteNonQuery(Command cmd)
      {
         using (IDbConnection conn = CreateConnection())
         {
            conn.Open();
            using (IDbCommand command = CreateCommand(conn, cmd))
            {
               return command.ExecuteNonQuery();
            }
         }
      }

      public object ExecuteScalar(Command cmd)
      {
         using (IDbConnection conn = CreateConnection())
         {
            conn.Open();
            using (IDbCommand command = CreateCommand(conn, cmd))
            {
               return command.ExecuteScalar();
            }
         }
      }
   }
}
