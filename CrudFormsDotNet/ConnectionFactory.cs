using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CrudFormsDotNet
{
    public class ConnectionFactory
    {
        private static string connectionString =
     "server=localhost;port=3310;uid=root;pwd=;database=db_agenda;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
        }
}
