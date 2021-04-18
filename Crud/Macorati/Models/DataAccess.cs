using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Macorati.Models
{
    public class DataAccess
    {
        public MySqlConnection connection;
        public DataAccess()
        {
            string server = "localhost";
            string database = "macorati";
            string uid = "root";
            string password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }
        public MySqlDataReader select(string sql)
        {
            try
            {
                MySqlCommand query = new MySqlCommand(sql, connection);
                connection.Open();
                MySqlDataReader myReader = query.ExecuteReader();

                return myReader;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public int sqlCommandAndGetId(string sql)
        {
            connection.Close();
            connection.Open();
            MySqlCommand command = new MySqlCommand(sql, connection);
            try
            {
                command.ExecuteNonQuery();
                int id = (int)command.LastInsertedId;
                connection.Close();
                return id;

            }
            catch (Exception e)
            {
               
                return 0;
            }
        }
        public bool sqlCommand(string sql)
        {
            connection.Close();
            connection.Open();
            MySqlCommand command = new MySqlCommand(sql, connection);
            try
            {
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
