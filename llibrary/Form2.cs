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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                signoutfail signoutfail1 = new signoutfail();
                signoutfail1.TopMost = true;
                Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - signoutfail1.Width, Screen.PrimaryScreen.WorkingArea.Height - signoutfail1.Height);
                signoutfail1.PointToScreen(p);
                signoutfail1.Location = p;
                signoutfail1.Enabled = true;
                signoutfail1.station = 1;
                signoutfail1.Show();
                return;
            }
            else if (textBox1.Text == "")
            {
                signoutfail signoutfail1 = new signoutfail();
                signoutfail1.TopMost = true;
                Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - signoutfail1.Width, Screen.PrimaryScreen.WorkingArea.Height - signoutfail1.Height);
                signoutfail1.PointToScreen(p);
                signoutfail1.Location = p;
                signoutfail1.Enabled = true;
                signoutfail1.station = 2;
                signoutfail1.Show();
                return;
            }
            else if (textBox2.Text == "")
            {
                signoutfail signoutfail1 = new signoutfail();
                signoutfail1.TopMost = true;
                Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - signoutfail1.Width, Screen.PrimaryScreen.WorkingArea.Height - signoutfail1.Height);
                signoutfail1.PointToScreen(p);
                signoutfail1.Location = p;
                signoutfail1.Enabled = true;
                signoutfail1.station = 3;
                signoutfail1.Show();
                return;
            }
            else
            {
                string strconn = "Data source = XIPHORAY\\SQLEXPRESS;Initial Catalog = LIBRARY;Integrated Security = SSPI";
                using (SqlConnection conn = new SqlConnection(strconn))
                {
                    conn.Open();

                    int j = 0;
                    SqlCommand dbquery1 = new SqlCommand();
                    dbquery1.Connection = conn;
                    dbquery1.CommandText = "select COUNT(*) from people where pname = '" + textBox1.Text + "'";
                    j = (int)dbquery1.ExecuteScalar();
                    if (j >= 1)
                    {
                        signoutfail d = new signoutfail();
                        d.TopMost = true;
                        Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                        d.PointToScreen(p);
                        d.Location = p;
                        d.Enabled = true;
                        d.station = 7;
                        d.Show();
                    }
                    else
                    {
                        int i = 0;
                        SqlCommand dbquery = new SqlCommand();
                        dbquery.Connection = conn;                         //插入数据（添增数据）
                        string sql = "insert into people(pname,code,reader,brosum,nsum,csum) values('" + textBox1.Text + "','" + textBox2.Text + "','";
                        sql += "1','0','0','4')";
                        dbquery.CommandText = sql;
                        i = dbquery.ExecuteNonQuery();
                        if (i == 1)
                        {
                            signoutfail d = new signoutfail();
                            d.TopMost = true;
                            Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                            d.PointToScreen(p);
                            d.Location = p;
                            d.Enabled = true;
                            d.station = 5;
                            d.Show();
                            Dispose();
                            Close();
                            return;
                        }
                        else
                        {
                            signoutfail d = new signoutfail();
                            d.TopMost = true;
                            Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                            d.PointToScreen(p);
                            d.Location = p;
                            d.Enabled = true;
                            d.station = 6;
                            d.Show();
                        }
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
                if (textBox1.Text == "")
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
