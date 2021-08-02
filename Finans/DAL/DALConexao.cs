using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DALConexao
    {
        private string _server = "localhost";
        private string _database = "finans";
        private string _user = "root";
        private string _password = "";
        private string _port = "3306";
        private string _sslM = "none";
        private MySqlConnection _conn;

        public DALConexao()
        {
            string connString = String.Format("server={0}; port={1}; user id={2}; password={3}; database={4}; SslMode={5}", _server, _port, _user, _password, _database, _sslM);
            _conn = new MySqlConnection(connString);
        }

        public MySqlConnection Connection()
        {
            return this._conn;
        }


        public void Connect()
        {
            this._conn.Open();
        }

        public void Disconnect()
        {
            this._conn.Close();
        }
    }
}