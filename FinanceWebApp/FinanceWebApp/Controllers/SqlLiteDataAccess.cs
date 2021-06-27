using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using FinanceWebApp.Models;
using Microsoft.Data.Sqlite;

namespace FinanceWebApp.Controllers
{
    public class SqlLiteDataAccess
    {

        public static List<AppUser> LoadUsers()
        {
            var retList = new List<AppUser>();

            var connectionStringBuilder = new SqliteConnectionStringBuilder();

            //Use DB in project directory.  If it does not exist, create it:
            connectionStringBuilder.DataSource = "./AppDatabase.db";

            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = "SELECT * FROM User";

                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retList.Add(new AppUser() { Id = reader.GetInt16(0),
                                                    Email = reader.GetString(1),
                                                    FirstName = reader.GetString(2),
                                                    LastName = reader.GetString(3),
                                                    SaltHash = reader.GetString(4),
                                                    PasswordHash = reader.GetString(5)
                        });
                    }
                }
            }

            return retList;
           }

            /*
            public static void SaveUsers(AppUser user)
            {

            }


            private static string LoadConnectionString()
            {

            }
            */
    }
}
