using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using Dapper;

namespace WinFormsNetFwSqlRedo
{
    public class SQLConnectionHandler
    {
        public static List<GameEntry> GetEntriesFromDatabase()
        {
            var retEntries = new List<GameEntry>();
            
            var conStr = GetConnectionString();

            using (var con = new SQLiteConnection(conStr))
            {
                con.Open();

                var sql = "select * from Games";
                var input = con.Query<GameEntry>(sql, new DynamicParameters());
                
                retEntries.AddRange(input);
            }
            
            return retEntries;
        }

        public static void SaveNewEntry(GameEntry entry)
        {
            var conStr = GetConnectionString();

            using (var con = new SQLiteConnection(conStr))
            {
                con.Open();

                var sql = "insert into Games ('Name', 'Publisher', 'ProductionStudio', 'ReleaseDate', 'AverageCost')" 
                + " values (@Name, @Publisher, @ProductionStudio, @ReleaseDate, @AverageCost)";

                con.Execute(sql, entry);
            }
        }
        
        private static string GetConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}