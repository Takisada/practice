using ClassLibrary5;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp17
{
    public partial class NeworChange : Form
    {
        string query;
        int type;
        List<string> list;
        SqlConnection conn = Class1.getConnection();
        int id;
        public NeworChange(int type, List<string> list)
        {
            this.list = list;
            this.type = type;
            InitializeComponent();
            button1.Text = "Изменить";
        }
        public NeworChange(int type)
        {
            this.type = type;
            InitializeComponent();
            button1.Text = "Добавить";
        }

        private void NeworChange_Load(object sender, EventArgs e)
        {
            if (type == 1)
            {
                id = Convert.ToInt32(list[0]);
                textBox1.Text = list[1].ToString();
                textBox2.Text = list[2].ToString();
                textBox3.Text = list[3].ToString();
                label4.Visible = false;
                textBox4.Visible = false;
            }
            else if(type == 0) 
            {
                label4.Visible = true;
                textBox4.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (type == 0)
                {
                    query = $"INSERT INTO DRIVERS([Номер ВУ], ФИО, Адрес, Телефон) VALUES({Convert.ToInt32(textBox4.Text)}, '{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}')";
                    Class1.SQLcommand(query);
                }
                else if (type == 1)
                {
                    query = $"UPDATE DRIVERS SET ФИО = '{textBox1.Text}', Адрес='{textBox2.Text}', Телефон='{textBox3.Text}' WHERE [Номер ВУ] = {id};";
                    Class1.SQLcommand(query);
                }
            }
            catch
            {
                MessageBox.Show("Введены неверные данные! Проверьте правильность заполнения и попробуйте снова!");
            }
        }
    }
}
