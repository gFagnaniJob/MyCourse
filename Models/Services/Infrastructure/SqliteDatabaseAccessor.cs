using System.Data;
using Microsoft.Data.Sqlite;

namespace MyCourse.Models.Services.Infrastructure
{
  public class SqliteDatabaseAccessor : IDatabaseAccessor
  {
    public DataSet Query(string query)
    {
      using (var dbConnection = new SqliteConnection("Data Source=Data/MyCourse.db"))
      {
        dbConnection.Open();
        using (var cmd = new SqliteCommand(query, dbConnection))
        {
          using (var reader = cmd.ExecuteReader())
          {
            var dataSet = new DataSet();
            dataSet.EnforceConstraints = false;
            var dataTable = new DataTable();
            dataSet.Tables.Add(dataTable);
            dataTable.Load(reader);
            return dataSet;
          }
        }
      }
    }
  }
}