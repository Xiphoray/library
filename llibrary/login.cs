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
        public int pnum;
        public bool reader;
        public string nsum;
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
                SqlCommand dbquery = new SqlCommand();
                dbquery.Connection = conn;
                dbquery.CommandText = "select pnum,reader,nsum from people where pname = '" + textBox1.Text + "' and code = '" + textBox2.Text + "'";
                SqlDataReader dbreader = dbquery.ExecuteReader();
                bool hasrow = dbreader.HasRows;
                if (!hasrow)
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
                dbreader.Read();
                {
                     pnum = dbreader.GetInt32(0);
                     reader = dbreader.GetBoolean(1);
                    if(reader)
                    {
                        nsum = dbreader.GetString(2);
                        readermain b = new readermain(pnum,nsum);
                        b.Show();
                        Dispose();                //释放资源
                        Close();
                    }
                    else
                    {
                        managermain r = new managermain(pnum);
                        r.Show();
                        Dispose();                //释放资源
                        Close();
                    }
                }
            }



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
                if(textBox1.Text == "")
                {
                    SendKeys.Send("{tab}");
                }
                else
                {
                    this.button1_Click(sender, e);//触发button事件  
                }

            }
        }
    }
}
