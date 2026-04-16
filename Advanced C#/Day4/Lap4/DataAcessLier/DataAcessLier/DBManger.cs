using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAcessLier
{
    public class DBManger
    {
        SqlConnection _connection;
        SqlCommand _command;

        public DBManger()
        {
            _connection = new SqlConnection(
                "Server=.\\SQLEXPRESS03;Database=pubs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;"
            );

            _command = new SqlCommand("", _connection);
        }

        // 🔹 Insert / Update / Delete
        public int ExcuteNonQuery(string sql)
        {
            _command.CommandText = sql;

            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            int rows = _command.ExecuteNonQuery();

            _connection.Close();
            return rows;
        }

        // 🔹 Select
        public DataTable SelectAll(string sql)
        {
            _command.CommandText = sql;

            SqlDataAdapter adapter = new SqlDataAdapter(_command);
            DataTable dt = new DataTable();

            adapter.Fill(dt);

            return dt;
        }
    }
}