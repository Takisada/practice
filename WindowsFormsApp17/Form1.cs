﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp17
{
    public partial class Form1 : Form
    {
        public Login login;
        public Form1()
        {
            InitializeComponent();
            login = new Login();
            login.Owner= this;
            
        }

        int usertype = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            if (sender == button1)
            {
                usertype = 1;
            }
            else if (sender == button2)
            {
                usertype = 2;
            }
            else if (sender == button3)
            {
                usertype = 3;
            }
            typick(usertype);
            login.Show();
            this.Hide();
            if (login.IsDisposed)
            {
                Close();
            }
        }

        delegate void type(int typenumber);
        type typick;
        private void Form1_Load(object sender, EventArgs e)
        {
            typick += login.logintype;
        }
    }
}
