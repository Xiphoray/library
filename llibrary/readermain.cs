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

        public void bosear(int e,string something)
        {
            string strconn = "Data source = XIPHORAY\\SQLEXPRESS;Initial Catalog = LIBRARY;Integrated Security = SSPI";
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                conn.Open();
                SqlCommand dbquery = new SqlCommand();
                dbquery.Connection = conn;
                if(e == 1)
                    dbquery.CommandText = "select bname,writer,publish,serachtime,station,brosum from book where ISBN like '" + something + "[^charlist]%'";

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
                        infor d = new infor(sl1, sl2, sl3, something, sl4, sl6, sl5);
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
            groupBox4.Show();
        }

        private void 还书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allhide();
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
            booksearch d = new booksearch(textBox1.Text);
            d.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            writersearch d = new writersearch(textBox3.Text);
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
    }
}
