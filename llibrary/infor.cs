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
    public partial class infor : Form
    {
        public string bname, writer, publish, ISBN, sertime, brotime;
        public int pnum;
        private void button1_Click(object sender, EventArgs e)
        {
            string strconn = "Data source = XIPHORAY\\SQLEXPRESS;Initial Catalog = LIBRARY;Integrated Security = SSPI";
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                conn.Open();
                int i, j;
                SqlCommand dbquery = new SqlCommand();
                dbquery.Connection = conn;
                dbquery.CommandText = "select COUNT(*) from book where pnum = '" + pnum.ToString() + "'";
                j = (int)dbquery.ExecuteScalar();
                if (j < 4)
                {
                    dbquery.CommandText = "select COUNT(*) from book where ISBN = '" + ISBN + "' and pnum = '0'";
                    i = (int)dbquery.ExecuteScalar();
                    if (i >= 1)
                    {
                        dbquery.CommandText = "update book set pnum = '" + pnum.ToString() + "', station = 1 where ISBN = '" + ISBN+ "'";       //更新数据
                        dbquery.ExecuteNonQuery();
                        button1.Hide();
                        label15.Text = "已借出";
                    }
                    else
                    {
                        signoutfail d = new signoutfail();
                        d.TopMost = true;
                        Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                        d.PointToScreen(p);
                        d.Location = p;
                        d.Enabled = true;
                        d.station = 9;
                        d.Show();
                    }
                }
                else
                {
                    signoutfail d = new signoutfail();
                    d.TopMost = true;
                    Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                    d.PointToScreen(p);
                    d.Location = p;
                    d.Enabled = true;
                    d.station = 11;
                    d.Show();
                }


            }
        }

        public int ser;
        public bool station;
        public int m = 0;
        public infor(string bn, string wr, string pu, string IS, string se, string br, bool st,int pn)
        {
            InitializeComponent();
            bname = bn;
            writer = wr;
            publish = pu;
            ISBN = IS;
            sertime = se;
            brotime = br;
            station = st;
            pnum = pn;
            timer1.Start();
            ser = Convert.ToInt32(sertime) + 1;
            string strconn = "Data source = XIPHORAY\\SQLEXPRESS;Initial Catalog = LIBRARY;Integrated Security = SSPI";
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                conn.Open();
                SqlCommand dbquery = new SqlCommand();
                dbquery.Connection = conn;
                dbquery.CommandText = "update book set serachtime = '" + ser.ToString() + "' where ISBN = '" + ISBN + "'";       //更新数据
                dbquery.ExecuteNonQuery();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            label9.Text = bname;
            label10.Text = writer;
            label11.Text = publish;
            label12.Text = ISBN;
            label13.Text = sertime;
            label14.Text = brotime;
            if (station)
            {
                label15.Text = "已借出";
                button1.Hide();
            }
            else
            {
                label15.Text = "可借";
                if (m == 1)
                    button1.Hide();
                else
                    button1.Show();
            }

            qrCodeGraphicControl1.Text = "https://book.douban.com/subject_search?search_text=" + ISBN;

        }
    }
}
