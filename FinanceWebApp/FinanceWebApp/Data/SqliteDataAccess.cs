using Dapper;
using FinanceWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceWebApp.Data
{
    public class SqliteDataAccess
    {
        public static List<User> LoadUsers()
        {
            using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());

            var output = cnn.Query<User>("select * from Users", new DynamicParameters());
            return output.ToList();
        }

        public async static void SaveUserAsync(User user)
        {
            using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
            
            await cnn.ExecuteAsync("insert into Users (username, passwordHash, passwordSalt) values (@Username, @PasswordHash, @PasswordSalt)", user);
        }

        public async static Task<IEnumerable<T>> LoadDataAsync<T>(string sql)
        {
            using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
            var a = await cnn.QueryAsync<T>(sql);
            return a;
        }

        public static string LoadConnectionString()
        {
            var csb = new SQLiteConnectionStringBuilder();
            csb.DataSource = "./Testdb.db";
            return csb.ConnectionString;
        }
    }
}
