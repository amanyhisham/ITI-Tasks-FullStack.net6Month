using Microsoft.Data.SqlClient;
using System.Data;

namespace ConsoleApp1
{
    internal class Program
    {
        private static object Main(string[] args)
        {


            string connectionstring =
                "Server=.\\SQLEXPRESS03;Database=ITI;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

            SqlConnection connection = new(connectionstring);
            #region connectionMode

            //Console.WriteLine(connection.State); // Closed

            //connection.Open();
            //Console.WriteLine(connection.State); // Open

            //connection.Close();
            //Console.WriteLine(connection.State); // Closed

            if (connection.State is not ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from dbo.Department", connection);//still not have any data
            //read data 
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Console.WriteLine($"{dataReader["Dept_Id"]},{dataReader["Dept_Name"]}");
            }
            #endregion

            #region disconnection
            SqlCommand sqlcommand = new SqlCommand("sp_tedt", connection);
            sqlcommand.Parameters.AddWithValue("@dept_id", 1);
            sqlcommand.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter dataadapter = new(sqlcommand);
            DataTable dt = new DataTable();
            dataadapter.Fill(dt);//open connection, execute command, fill data, close connection
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Console.WriteLine($"{dt.Rows[i]["Dept_Id"]},{dt.Rows[i]["Dept_Name"]}");
            }
            sqlcommand.CommandText = "sp_te12";//make new proceduger
            sqlcommand.Parameters.Clear();//newparmeters

            #endregion

            #region insert
            SqlCommand sqlcommand1 = new SqlCommand("insert into dbo.Department values(@dept_id,@dept_name)", connection);
            int rowsaffected = sqlcommand1.ExecuteNonQuery();
            Console.WriteLine($"Rows affected{rowsaffected}");
            #endregion
            return 0;
        }
    }
}