using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp17
{
    public partial class Driver : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=MAGA-PC;Integrated Security=SSPI;Initial Catalog=""BIMBABOMBA""");
        public Driver(int id)
        {
            InitializeComponent();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string query;
            query = $"Select * from FINES where [Номер ВУ] = {id};";
            SqlCommand sqlc = new SqlCommand(query, conn);
            adapter.SelectCommand = sqlc;
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
