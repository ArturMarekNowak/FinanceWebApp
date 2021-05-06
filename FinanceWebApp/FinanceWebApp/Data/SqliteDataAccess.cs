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
    // TODO: address a problem of sql injections
    public class SqliteDataAccess
    {
        public async static void SaveUserAsync(User user)
        {
            using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());

            await cnn.ExecuteAsync("insert into Users (username, passwordHash, passwordSalt) values (@Username, @PasswordHash, @PasswordSalt)", user);
        }

        public static User GetUser(string username)
        {
            using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());

            return cnn.QueryFirstOrDefault<User>("select * from Users where username=@Username", new { Username = username });
        }

        public async static Task<User> GetUserAsync(string username)
        {
            using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());

            return await cnn.QueryFirstOrDefaultAsync<User>("select * from Users where username=@Username", new { Username = username });
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
