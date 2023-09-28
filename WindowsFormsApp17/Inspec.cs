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
    public partial class Inspec : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=MAGA-PC;Integrated Security=SSPI;Initial Catalog=""BIMBABOMBA""");
        public Inspec(int id)
        {
            InitializeComponent();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string query;
            query = $"Select * from DRIVERS;";
            SqlCommand sqlc = new SqlCommand(query, conn);
            DataTable dt1 = new DataTable();
            adapter.SelectCommand = sqlc;
            adapter.Fill(dt1);
            dataGridView1.DataSource = dt1;
            query = $"Select * from AUTOS;";
            SqlCommand sqlc2 = new SqlCommand(query, conn);
            DataTable dt2 = new DataTable();
            adapter.SelectCommand = sqlc2;
            adapter.Fill(dt2);
            dataGridView2.DataSource = dt2;
            query = $"Select * from VIOLATIONS;";
            SqlCommand sqlc3 = new SqlCommand(query, conn);
            DataTable dt3 = new DataTable();
            adapter.SelectCommand = sqlc3;
            adapter.Fill(dt3);
            dataGridView4.DataSource = dt3;
            query = $"Select * from FINES;";
            SqlCommand sqlc4 = new SqlCommand(query, conn);
            DataTable dt4 = new DataTable();
            adapter.SelectCommand = sqlc4;
            adapter.Fill(dt4);
            dataGridView5.DataSource = dt4;
        }
    }
}
