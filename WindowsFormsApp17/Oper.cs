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
using ClassLibrary5;

namespace WindowsFormsApp17
{
    public partial class Oper : Form
    {
        private int x = -1;
        private int ryad;
        SqlConnection conn = new SqlConnection(@"Data Source=MAGA-PC;Integrated Security=SSPI;Initial Catalog=""BIMBABOMBA""");
        string row;
        List<string> list = new List<string>();


        public Oper()
        {
            InitializeComponent();
            dataGridView1.DataSource = Class1.tableLoad("DRIVERS");
            dataGridView2.DataSource = Class1.tableLoad("AUTOS");
            dataGridView3.DataSource = Class1.tableLoad("INSPECTORS");
            dataGridView4.DataSource = Class1.tableLoad("VIOLATIONS");;
            dataGridView5.DataSource = Class1.tableLoad("FINES");
            dataGridView6.DataSource = Class1.tableLoad("Operators");
            dataGridView7.DataSource = Class1.tableLoad("[История входа]");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (x != -1)
            { 
                NeworChange noc = new NeworChange(1, list);
                noc.Owner = this;
                this.Hide();
                noc.ShowDialog();
                if (noc.IsDisposed)
                {
                    dataGridView1.DataSource = Class1.tableLoad("DRIVERS");
                    this.Show();
                }
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            if(sender == dataGridView1)
            {
                ryad = e.RowIndex;
                row = Convert.ToInt32(dataGridView1.Rows[ryad].Cells[0].Value).ToString() + " "
                    + Convert.ToString(dataGridView1.Rows[ryad].Cells[2].Value) + " " 
                    + Convert.ToString(dataGridView1.Rows[ryad].Cells[3].Value) + " " 
                    + Convert.ToString(dataGridView1.Rows[ryad].Cells[4].Value);
                list = Class1.Changelog(row);
            }
            else if(sender == dataGridView2)
            {
                row = Convert.ToString(dataGridView2.Rows[ryad].Cells[1].Value).ToString() + " "
                    + Convert.ToString(dataGridView2.Rows[ryad].Cells[2].Value) + " "
                    + Convert.ToString(dataGridView2.Rows[ryad].Cells[3].Value) + " "
                    + Convert.ToString(dataGridView2.Rows[ryad].Cells[4].Value) + " "
                    + Convert.ToString(dataGridView2.Rows[ryad].Cells[5].Value.ToString()) + " "
                    + Convert.ToInt32(dataGridView2.Rows[ryad].Cells[6].Value) + " ";
            }
            /*else if (sender == dataGridView3)
            {
                id = Convert.ToInt32(dataGridView3.Rows[x].Cells[0].Value);
                rayon = Convert.ToString(dataGridView3.Rows[x].Cells[1].Value);
                name = Convert.ToString(dataGridView3.Rows[x].Cells[2].Value);
                address = Convert.ToString(dataGridView3.Rows[x].Cells[3].Value);
                phone = Convert.ToString(dataGridView3.Rows[x].Cells[4].Value);
            }
            else if (sender == dataGridView4)
            {
                id = Convert.ToInt32(dataGridView4.Rows[x].Cells[0].Value);
                name = Convert.ToString(dataGridView4.Rows[x].Cells[1].Value);
                shtraf = Convert.ToString(dataGridView4.Rows[x].Cells[2].Value);
                aware = Convert.ToBoolean(dataGridView4.Rows[x].Cells[3].Value);
                OTOBRALI = Convert.ToInt32(dataGridView4.Rows[x].Cells[4].Value);
            }
            else if (sender == dataGridView5)
            {
                id = Convert.ToInt32(dataGridView5.Rows[x].Cells[0].Value);
                foreign = Convert.ToInt32(dataGridView5.Rows[x].Cells[1].Value);
                foreign2 = Convert.ToInt32(dataGridView5.Rows[x].Cells[2].Value);
                narushil = Convert.ToDateTime(dataGridView5.Rows[x].Cells[3].Value);
                shtraf = Convert.ToString(dataGridView5.Rows[x].Cells[4].Value);
                oplata = Convert.ToBoolean(dataGridView5.Rows[x].Cells[5].Value);
                noprava = Convert.ToInt32(dataGridView5.Rows[x].Cells[6].Value);
                shtrafmoney = Convert.ToInt32(dataGridView5.Rows[x].Cells[7].Value);
                foreign3 = Convert.ToInt32(dataGridView5.Rows[x].Cells[8].Value);
            }
            else if (sender == dataGridView6)
            {
                id = Convert.ToInt32(dataGridView6.Rows[x].Cells[0].Value);
                login = Convert.ToString(dataGridView6.Rows[x].Cells[1].Value);
                password = Convert.ToString(dataGridView6.Rows[x].Cells[2].Value);
            }*/

        }

        private void button3_Click(object sender, EventArgs e)
        {
            NeworChange noc = new NeworChange(0);
            noc.Owner = this;
            noc.ShowDialog();
        }
    }
}
