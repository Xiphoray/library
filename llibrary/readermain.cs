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
    public partial class readermain : Form
    {
        private DataSet myset;
        private SqlDataAdapter da;
        //private SqlCommandBuilder myCbd;
        BindingSource bing1;
        public int pnum;
        public string nsum;
        public readermain(int p,string n)
        {
            InitializeComponent();
            pnum = p;
            nsum = n;
        }

        public void allhide()
        {
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
            groupBox5.Hide();
        }

        public void pershow()
        {
            string strconn = "Data source = XIPHORAY\\SQLEXPRESS;Initial Catalog = LIBRARY;Integrated Security = SSPI";
            string strsq1 = "select bname,writer,publish,ISBN from book,people where people.pnum like " + pnum.ToString() + " and book.pnum=people.pnum";
            SqlConnection conn = new SqlConnection(strconn);
            SqlCommand strCmd = new SqlCommand(strsq1, conn);
            da = new SqlDataAdapter();
            da.SelectCommand = strCmd;
            myset = new DataSet();
            bing1 = new BindingSource();
            try
            {
                da.Fill(myset, "book");
                bing1.DataSource = myset;
                bing1.DataMember = "book";
                bing1.Filter = "";
                dataGridView1.DataSource = bing1;
                dataGridView2.DataSource = bing1;
            }
            catch (SqlException ex)
            {
                signoutfail d = new signoutfail();
                d.TopMost = true;
                Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                d.PointToScreen(p);
                d.Location = p;
                d.Enabled = true;
                d.station = 0;
                d.Show();
            }
        }
        public void bosear(int e,string something)
        {
            string strconn = "Data source = XIPHORAY\\SQLEXPRESS;Initial Catalog = LIBRARY;Integrated Security = SSPI";
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                conn.Open();
                SqlCommand dbquery = new SqlCommand();
                dbquery.Connection = conn;
                if(e == 1)
                    dbquery.CommandText = "select bname,writer,publish,serachtime,station,brosum from book where ISBN = '" + something + "'";

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
                    d.station = 8;
                    d.Show();
                    return;
                }
                dbreader.Read();
                {
                    string sl1, sl2, sl3,sl4,sl6;
                    bool sl5;
                    sl1 = dbreader.GetString(0);
                    sl2 = dbreader.GetString(1);
                    sl3 = dbreader.GetString(2);
                    sl4 = dbreader.GetString(3);
                    sl6 = dbreader.GetString(5);
                    sl5 = dbreader.GetBoolean(4);

                    if(e == 1)
                    {
                        infor d = new infor(sl1, sl2, sl3, something, sl4, sl6, sl5,pnum);
                        d.Show();
                    }

                }

            }
        }

        private void 登出ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("确定登出么？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                login t = new login();
                t.Show();
                Dispose();                //释放资源
                Close();
            }
            else
            {
                return;
            }
        }
        private void readermain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定登出么？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                login t = new login();
                t.Show();
                Dispose();                //释放资源
                Close();
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出么？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Dispose();                //释放资源
                Application.Exit();            //关闭应用程序窗体
            }
            else
            {
                return;
            }
        }

        private void 按书名查找ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allhide();
            groupBox1.Show();
        }

        private void 按ISBN号查找ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allhide();
            groupBox2.Show();
        }

        private void anToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allhide();
            groupBox3.Show();
        }

        private void 借书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allhide();
            pershow();
            groupBox4.Show();
        }

        private void 还书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allhide();
            pershow();
            groupBox5.Show();
        }



        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about q = new about();
            q.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bosear(1, textBox2.Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            booksearch d = new booksearch(textBox1.Text,pnum);
            d.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            writersearch d = new writersearch(textBox3.Text,pnum);
            d.Show();

        }



        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                this.button1_Click(sender, e);//触发button事件  
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                this.button2_Click(sender, e);//触发button事件  
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                this.button3_Click(sender, e);//触发button事件  
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string strconn = "Data source = XIPHORAY\\SQLEXPRESS;Initial Catalog = LIBRARY;Integrated Security = SSPI";
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                conn.Open();
                int i,j;
                SqlCommand dbquery = new SqlCommand();
                dbquery.Connection = conn;
                dbquery.CommandText = "select COUNT(*) from book where pnum = '" + pnum.ToString() + "'";
                j = (int)dbquery.ExecuteScalar();
                if (j < 4)
                {
                    dbquery.CommandText = "select COUNT(*) from book where ISBN = '" + textBox4.Text + "' and pnum = '0'";
                    i = (int)dbquery.ExecuteScalar();
                    if (i >= 1)
                    {
                        dbquery.CommandText = "update book set pnum = '" + pnum.ToString() + "', station = 1 where ISBN = '" + textBox4.Text + "'";       //更新数据
                        dbquery.ExecuteNonQuery();
                        pershow();
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
                    d.station = 9;
                    d.Show();
                }
                    

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string strconn = "Data source = XIPHORAY\\SQLEXPRESS;Initial Catalog = LIBRARY;Integrated Security = SSPI";
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                conn.Open();
                int i = 0;
                SqlCommand dbquery = new SqlCommand();
                dbquery.Connection = conn;
                dbquery.CommandText = "select COUNT(*) from book where ISBN = '" + textBox5.Text + "' and pnum = '" + pnum.ToString() + "'";
                i = (int)dbquery.ExecuteScalar();
                if (i >= 1)
                {
                    dbquery.CommandText = "select brosum from book where ISBN = '" + textBox5.Text + "'";
                    SqlDataReader dbreader = dbquery.ExecuteReader();
                    dbreader.Read();   
                    int sl1;
                    sl1 = Convert.ToInt32(dbreader.GetString(0)) + 1;
                    dbreader.Close();
                    dbquery.CommandText = "update book set pnum = '0', brosum = '" + sl1.ToString() + "', station = 0 where ISBN = '" + textBox5.Text + "'";       //更新数据
                    dbquery.ExecuteNonQuery();

                    pershow();
                }
                else
                {
                    signoutfail d = new signoutfail();
                    d.TopMost = true;
                    Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                    d.PointToScreen(p);
                    d.Location = p;
                    d.Enabled = true;
                    d.station = 10;
                    d.Show();
                }

            }
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

                string da;
                da = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                bosear(1, da);


        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

                string da;
                da = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                bosear(1, da);

        }
    }
}
