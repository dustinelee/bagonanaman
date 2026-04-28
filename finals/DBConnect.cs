using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace finals
{
    internal class DBConnect
    {
        private MySqlConnection connection = new MySqlConnection(
            "server=localhost;user=root;database=finals_db;port=3306;password=;"
        );

        public MySqlConnection Connection => connection;

        public void Open()
        {
            try { if (connection.State != System.Data.ConnectionState.Open) connection.Open(); }
            catch (System.Exception ex) { MessageBox.Show("Connection Error: " + ex.Message); }
        }

        public void Close()
        {
            try { if (connection.State != System.Data.ConnectionState.Closed) connection.Close(); }
            catch (System.Exception ex) { MessageBox.Show("Connection Error: " + ex.Message); }
        }
    }
}
