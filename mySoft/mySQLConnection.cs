using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; //potrebno podesavanja mySQL konekcije
using MySql.Data;
using MySql.Data.MySqlClient;

namespace mySoft
{
    public class mySQLConnection
    {
        public static string mySqlExecute(String command)
        {
            string server = ConfigurationManager.AppSettings["server"].ToString();
            string username = ConfigurationManager.AppSettings["username"].ToString();
            string password = ConfigurationManager.AppSettings["password"].ToString();
            string database = ConfigurationManager.AppSettings["database"].ToString();

            MySqlConnection conn = new MySqlConnection(@"server=" + server + ";userid=" + username + ";"
            + "password=" + password + ";database=" + database);
            conn.Open();
            MySqlCommand sqlCommand = new MySqlCommand(@command, conn);
            string com = "0";
            if (sqlCommand.ExecuteScalar() != null)
            {
                com = sqlCommand.ExecuteScalar().ToString();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return com;
        }

    }

}
