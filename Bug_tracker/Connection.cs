using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Bug_tracker
{
    internal class Connection
    {
        private MySqlConnection conn;
        private string server;
        private string user;
        private string pass;
        private string db;
        private string port;

        public Connection() {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            db = "bug_list";
            user = "root";
            pass = "admin";
            port = "3307";
            string connectionString;
            connectionString = "Data Source=" + server + ";Port=" + port + ";Database=" + db + ";User Id=" + user + ";Password=" + pass + ";SSL Mode=0";
            conn = new MySqlConnection(connectionString);

        }
        public bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }catch(MySqlException e)
            {
                switch (e.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact admin");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password.");
                        break ;

                }
                return false;
            }
        }
        public void CloseConnection()
        {
            conn.Close();
        }
        public MySqlConnection GetConnection()
        {
            return conn;
        }
    }
}
