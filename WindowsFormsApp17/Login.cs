using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary5;

namespace WindowsFormsApp17
{
    public partial class Login : Form
    {
        private int x = 0;
        private int y;
        private int t;
        public Login()
        {
            InitializeComponent();
        }
        int type = 0;
        private void Login_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
        public void logintype(int tip)
        {
            if (tip == 1)
            {
                label1.Text = "Логин:";
                label2.Text = "Пароль:";
                type = 1;
            }
            else if (tip == 2)
            {
                label1.Text = "Номер инспекторского жетона:";
                type = 2;
            }
            else if (tip == 3)
            {
                label1.Text = "Номер ВУ:";
                type = 3;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var id = textBox1.Text;
            var password = textBox2.Text;
            y = Class1.Login(type, id, password);

            if (y == 1)
            {
                if (type == 1)
                {
                    Oper oper = new Oper();
                    this.Hide();
                    oper.ShowDialog();
                }
                else if (type == 2)
                {
                    Inspec inspec = new Inspec(Convert.ToInt32(id));
                    this.Hide();
                    inspec.ShowDialog();
                }
                else if (type == 3)
                {
                    Driver client = new Driver(Convert.ToInt32(id));
                    this.Hide();
                    client.ShowDialog();
                }
            }
            else
            {
                if(x == 0)
                {
                    PROGRAMMAYAROBOT pyr = new PROGRAMMAYAROBOT(0);
                    pyr.ShowDialog();
                    if (pyr.IsDisposed)
                    {
                        MessageBox.Show("Вы не прошли проверку капчей два раза! Попробуйте снова через 180 сек.");
                        textBox1.ReadOnly = true;
                        textBox2.ReadOnly = true;
                        button1.Enabled = false;
                        button2.Enabled = false;
                        timer1.Interval = 1000;
                        timer1.Start();
                        x++;
                    }
                }
                else if(x == 1)
                {
                    PROGRAMMAYAROBOT pyr = new PROGRAMMAYAROBOT(1);
                    pyr.ShowDialog();
                    if (pyr.IsDisposed)
                    {
                        MessageBox.Show("Вы не прошли проврку капчей три раза! Перезапустите приложение и попробуйте снова.");
                        Dispose();
                    }
                }
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '\0';
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t++;
            if (t == 180)
            {
                timer1.Stop();
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }
    }
}
