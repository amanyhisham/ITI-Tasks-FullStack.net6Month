using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAcessLier
{
    public class DBManger
    {
 
        SqlConnection _connection;
        SqlCommand _command;
        public DBManger() {
             
            _connection = new("Server=.\\SQLEXPRESS03;Database=pubs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            _command = new SqlCommand("", _connection);//query(insert,select,updata) +connection
        }
        public int ExcuteNonQuery(string sql) {//insert,updata,delet
            _command.CommandText = sql;
            if (_connection.State is not ConnectionState.Open)
            {
                _connection.Open();
            }
            int rowsaffected = _command.ExecuteNonQuery();
            _connection.Close();
            return rowsaffected;


        }
        public DataTable SelectAll(string sqlQuery)//select disconnectedmode
        {
            _command.CommandText = sqlQuery;
            SqlDataAdapter dataadapter = new(_command);
            DataTable dt = new DataTable();
            dataadapter.Fill(dt);//open connection, execute command, fill data, close connection
           return dt;

        }

    }
}
