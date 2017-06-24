using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace llibrary
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        public string pnum;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 signout = new Form2();
            signout.Show();
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定退出么？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Dispose();                //释放资源
                Application.Exit();            //关闭应用程序窗体
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strconn = "Data source = XIPHORAY\\SQLEXPRESS;Initial Catalog = LIBRARY;Integrated Security = SSPI";  //CLOUD39\\SQLEXPRESS更改
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                conn.Open();
                int i = 0;
                SqlCommand dbquery = new SqlCommand();
                dbquery.Connection = conn;
                dbquery.CommandText = "select COUNT(*) from people where pname = '" + textBox1.Text + "' and code = '" + textBox2.Text + "'";
                i = (int)dbquery.ExecuteScalar();
                if (i >= 1)
                {
                    this.Hide();
                }
                else
                {
                    signoutfail d = new signoutfail();
                    d.TopMost = true;
                    Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                    d.PointToScreen(p);
                    d.Location = p;
                    d.Enabled = true;
                    d.station = 4;
                    d.Show();
                    return;
                }
            }

            //managermain r = new managermain();
            //r.Show();
            readermain b = new readermain();
            b.Show();
            Dispose();                //释放资源
            Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }
    }
}
