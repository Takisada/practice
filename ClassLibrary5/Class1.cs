using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary5
{
    public static class Class1
    {
        static string query;
        static SqlConnection sqlConnection = new SqlConnection(@"Data Source=MAGA-PC; Integrated Security=SSPI; Initial Catalog = BIMBABOMBA;");
        static SqlDataAdapter adapter = new SqlDataAdapter();
        static DataTable dt = new DataTable();
        static SqlCommand sqlc = new SqlCommand();
        public static void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
                sqlConnection.Open();
        }

        public static void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
                sqlConnection.Close();
        }

        public static SqlConnection getConnection()
        {
            return sqlConnection;
        }

        public static int SQLcommand(string queryString)
        {
            openConnection();
            SqlCommand command = new SqlCommand(queryString, getConnection());
            command.ExecuteNonQuery();
            closeConnection();
            return 1;
        }
        public static DataTable tableLoad(string Table)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            string query;
            query = $"Select * from " + Table + ";";
            DataTable dt = new DataTable();
            sqlc = new SqlCommand(query, getConnection());
            adapter.SelectCommand = sqlc;
            adapter.Fill(dt);
            return dt;
        }

        public static List<string> Changelog(string row)
        {
            List<string> list = new List<string>();
            list.Add(row.Split(' ').ToString());
            return list;
        }
        public static int Login (int type, string login, string password)
        {
            try
            {
                if (type == 1)
                {
                    query = $"SELECT operator_login, operator_password from Operators where operator_login = '{login}' and operator_password = '{password}'";
                    sqlc = new SqlCommand(query, getConnection());
                }
                else if (type == 2)
                {
                    query = $"Select [Номер жетона], [Район юрисдикции инспектора], ФИО, Адрес, Телефон from INSPECTORS where [Номер жетона] = {Convert.ToInt32(login)} and Пароль = '{password}'";
                    sqlc = new SqlCommand(query, getConnection());
                }
                else if (type == 3)
                {
                    query = $"Select [Номер ВУ], ФИО, Адрес, Телефон from DRIVERS where [Номер ВУ] = {Convert.ToInt32(login)} and Пароль = '{password}'";
                    sqlc = new SqlCommand(query, getConnection());
                }
                else
                {
                    throw new Exception("ЕГО ДАННЫЕ ПОЛНАЯ ХУЙНЯ.");
                }
                adapter.SelectCommand = sqlc;
                adapter.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    query = $"INSERT INTO [История Входа] VALUES ('{DateTime.Now}', '{Convert.ToString(login)}', 'Успешный')";
                    SQLcommand(query);
                    return 1;
                }

                else
                {
                    query = $"INSERT INTO [История Входа] VALUES ('{DateTime.Now}', '{Convert.ToString(login)}', 'Неудачный')";
                    SQLcommand(query);
                    return 0;
                }
            }
            catch
            {
                return 2;
            }
        }




    }
}
