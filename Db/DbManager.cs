using Microsoft.Extensions.Configuration;
using RedOakAPI.Models;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Data.SqlClient;

namespace RedOakAPI.Db
{
    public class DbManager
    {
        public static QueryFactory Connect()
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            DbModel connection_values = configuration.GetSection("Connection").Get<DbModel>();  

            var host = connection_values.Host;

            var username = connection_values.Username;

            var password = connection_values.Password;

            var database = connection_values.Database;

            var connection = new SqlConnection("Data Source=" + host + ";Initial Catalog=" + database + ";User Id=" + username + ";Password=" + password + ";");

            var compiler = new SqlServerCompiler();

            var db = new QueryFactory(connection, compiler);

            return db;
        }
    }
}
