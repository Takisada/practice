using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp17
{
    internal class SQLCON
    {
        SqlConnection sqlConnection = new SqlConnection(@"""Data Source=MAGA-PC;Integrated Security=SSPI;Initial Catalog=""BIMBABOMBA"", Integrated Security = True");

        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
                sqlConnection.Open();
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
                sqlConnection.Close();
        }

        public SqlConnection getConnection()
        {
            return sqlConnection;
        }

        public void SQLcommand(string queryString)
        {
            openConnection();
            SqlCommand command = new SqlCommand(queryString, getConnection());
            command.ExecuteNonQuery();
            closeConnection();
        }
    }
}
