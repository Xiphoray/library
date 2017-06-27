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
    public partial class changecode : Form
    {
        public int pnum;
        public changecode(int p)
        {
            InitializeComponent();
            pnum = p;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strconn = "Data source = XIPHORAY\\SQLEXPRESS;Initial Catalog = LIBRARY;Integrated Security = SSPI";  //CLOUD39\\SQLEXPRESS更改
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                conn.Open();
                SqlCommand dbquery = new SqlCommand();
                dbquery.Connection = conn;
                dbquery.CommandText = "select pnum,reader,nsum from people where pnum = '" + pnum.ToString() + "' and code = '" + textBox1.Text + "'";
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
                    d.station = 23;
                    d.Show();
                    return;
                }
                dbreader.Close();
                if(textBox2.Text == textBox3.Text)
                {
                    dbquery.CommandText = "update people set code = '" + textBox3.Text + "' where pnum = '" + pnum + "'";       //更新数据
                    dbquery.ExecuteNonQuery();
                    signoutfail d = new signoutfail();
                    d.TopMost = true;
                    Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                    d.PointToScreen(p);
                    d.Location = p;
                    d.Enabled = true;
                    d.station = 25;
                    d.Show();
                    Close();
                }
                else
                {
                    signoutfail d = new signoutfail();
                    d.TopMost = true;
                    Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                    d.PointToScreen(p);
                    d.Location = p;
                    d.Enabled = true;
                    d.station = 24;
                    d.Show();
                    return;
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
                SendKeys.Send("{tab}");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                this.button1_Click(sender, e);//触发button事件  


            }
        }
    }
}
