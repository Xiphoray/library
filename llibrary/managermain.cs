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
    public partial class managermain : Form
    {
        public int pnum;
        public managermain(int p)
        {
            InitializeComponent();
            pnum = p;
        }
        private DataSet myset,myset1;
        private SqlDataAdapter da,da1;
        //private SqlCommandBuilder myCbd;
        BindingSource bing1,bing;
        public void allbookshow()
        {
            string strconn = "Data source = XIPHORAY\\SQLEXPRESS;Initial Catalog = LIBRARY;Integrated Security = SSPI";
            string strsq1 = "select bname as 书名,writer as 作者,publish as 出版社,ISBN as ISBN号 from book";
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

        public void allhide()
        {
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
        }
        
        public void checkpeo()
        {
            string strconn = "Data source = XIPHORAY\\SQLEXPRESS;Initial Catalog = LIBRARY;Integrated Security = SSPI";
            string strsq1 = "select pnum as 编号 ,pname as 姓名 ,code as 密码,brosum as 借阅总次数 ,nsum as 当前借阅数量 from people where reader = 1";
            SqlConnection conn = new SqlConnection(strconn);
            SqlCommand strCmd = new SqlCommand(strsq1, conn);
            da1 = new SqlDataAdapter();
            da1.SelectCommand = strCmd;
            myset1 = new DataSet();
            bing = new BindingSource();
            try
            {
                da1.Fill(myset1, "people");
                bing.DataSource = myset1;
                bing.DataMember = "people";
                bing.Filter = "";
                dataGridView1.DataSource = bing;
                dataGridView1.Rows[0].Selected = false;
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

        public void bosear(int e, string something)
        {
            string strconn = "Data source = XIPHORAY\\SQLEXPRESS;Initial Catalog = LIBRARY;Integrated Security = SSPI";
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                conn.Open();
                SqlCommand dbquery = new SqlCommand();
                dbquery.Connection = conn;
                if (e == 1)
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
                    string sl1, sl2, sl3, sl4, sl6;
                    bool sl5;
                    sl1 = dbreader.GetString(0);
                    sl2 = dbreader.GetString(1);
                    sl3 = dbreader.GetString(2);
                    sl4 = dbreader.GetString(3);
                    sl6 = dbreader.GetString(5);
                    sl5 = dbreader.GetBoolean(4);

                    if (e == 1)
                    {
                        infor d = new infor(sl1, sl2, sl3, something, sl4, sl6, sl5, pnum);
                        d.m = 1;
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
        private void managermain_FormClosing(object sender, FormClosingEventArgs e)
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
        private void 添增新书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allhide();
            groupBox1.Show();
        }
        private void 删减旧书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allhide();
            allbookshow();
            groupBox2.Show();
        }

        private void 书籍信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allhide();
            groupBox3.Show();
        }

        private void 查看在录人员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allhide();
            checkpeo();
            groupBox4.Show();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about q = new about();
            q.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                signoutfail d = new signoutfail();
                d.TopMost = true;
                Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                d.PointToScreen(p);
                d.Location = p;
                d.Enabled = true;
                d.station = 12;
                d.Show();
            }
            else if(textBox1.Text.Length > 20 || textBox2.Text.Length >10 || textBox3.Text.Length >20 || textBox4.Text.Length >20)
            {
                signoutfail d = new signoutfail();
                d.TopMost = true;
                Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                d.PointToScreen(p);
                d.Location = p;
                d.Enabled = true;
                d.station = 13;
                d.Show();
            }
            else
            {
                string strconn = "Data source = XIPHORAY\\SQLEXPRESS;Initial Catalog = LIBRARY;Integrated Security = SSPI";
                using (SqlConnection conn = new SqlConnection(strconn))
                {
                    conn.Open();
                    int i = 0,j;
                    SqlCommand dbquery = new SqlCommand();
                    dbquery.Connection = conn;                         //插入数据（添增数据）

                    dbquery.CommandText = "select COUNT(*) from book where ISBN = '" + textBox4.Text + "'";
                    j = (int)dbquery.ExecuteScalar();
                    if(j == 0)
                    {
                        string sql = "insert into book(bname,writer,publish,ISBN,serachtime,station,pnum,brosum) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','0',0,'0','0')";
                        dbquery.CommandText = sql;
                        i = dbquery.ExecuteNonQuery();
                        if(i == 1)
                        {
                            signoutfail d = new signoutfail();
                            d.TopMost = true;
                            Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                            d.PointToScreen(p);
                            d.Location = p;
                            d.Enabled = true;
                            d.station = 14;
                            d.Show();
                        }
                        else
                        {
                            signoutfail d = new signoutfail();
                            d.TopMost = true;
                            Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                            d.PointToScreen(p);
                            d.Location = p;
                            d.Enabled = true;
                            d.station = 15;
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
                        d.station = 16;
                        d.Show();
                    }
                    

                }
            }
        }
        int chooser, choosec;

        private void contextMenuStrip1_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            this.dataGridView1.Rows[chooser].Cells[choosec].Selected = false;
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkpeo();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strconn = "Data source = XIPHORAY\\SQLEXPRESS;Initial Catalog = LIBRARY;Integrated Security = SSPI";
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                conn.Open();
                int i = 0, j;
                SqlCommand dbquery = new SqlCommand();
                dbquery.Connection = conn;

                dbquery.CommandText = "select COUNT(*) from book where pnum = '" + dataGridView1.Rows[chooser].Cells[0].Value + "'";
                j = (int)dbquery.ExecuteScalar();
                if (j >= 1)
                {
                    signoutfail d = new signoutfail();
                    d.TopMost = true;
                    Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                    d.PointToScreen(p);
                    d.Location = p;
                    d.Enabled = true;
                    d.station = 22;
                    d.Show();
                    checkpeo();
                }
                else
                {
                    dbquery.CommandText = "delete from people where pnum ='" + dataGridView1.Rows[chooser].Cells[0].Value + "'";
                    i = (int)dbquery.ExecuteNonQuery();
                    if (i == 1)
                    {
                        signoutfail d = new signoutfail();
                        d.TopMost = true;
                        Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                        d.PointToScreen(p);
                        d.Location = p;
                        d.Enabled = true;
                        d.station = 17;
                        d.Show();
                        checkpeo();
                    }
                    else
                    {
                        signoutfail d = new signoutfail();
                        d.TopMost = true;
                        Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                        d.PointToScreen(p);
                        d.Location = p;
                        d.Enabled = true;
                        d.station = 18;
                        d.Show();
                    }
                }
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.ColumnIndex > -1 && e.RowIndex > -1)  //点击的是鼠标右键，并且不是表头
            {
                //右键选中单元格
                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                chooser = e.RowIndex;
                choosec = e.ColumnIndex;
                this.contextMenuStrip1.Show(MousePosition.X, MousePosition.Y); //MousePosition.X, MousePosition.Y 是为了让菜单在所选行的位置显示

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strconn = "Data source = XIPHORAY\\SQLEXPRESS;Initial Catalog = LIBRARY;Integrated Security = SSPI";
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                conn.Open();
                int i = 0;
                SqlCommand dbquery = new SqlCommand();
                dbquery.Connection = conn;
                dbquery.CommandText = "delete from book where ISBN ='" + textBox5.Text + "'";
                i = dbquery.ExecuteNonQuery();
                if(i == 1)
                {
                    signoutfail d = new signoutfail();
                    d.TopMost = true;
                    Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                    d.PointToScreen(p);
                    d.Location = p;
                    d.Enabled = true;
                    d.station = 17;
                    d.Show();
                    allbookshow();
                }
                else
                {
                    signoutfail d = new signoutfail();
                    d.TopMost = true;
                    Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                    d.PointToScreen(p);
                    d.Location = p;
                    d.Enabled = true;
                    d.station = 18;
                    d.Show();
                }
            }
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string da;
            da = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            bosear(1, da);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool flag1 = false,flag2 = false,flag3 = false;
            int i;
            if(textBox6.Text == "")
            {
                signoutfail d = new signoutfail();
                d.TopMost = true;
                Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                d.PointToScreen(p);
                d.Location = p;
                d.Enabled = true;
                d.station = 19;
                d.Show();
            }
            else if(textBox7.Text == "" && textBox8.Text == "" && textBox9.Text == "")
            {
                signoutfail d = new signoutfail();
                d.TopMost = true;
                Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                d.PointToScreen(p);
                d.Location = p;
                d.Enabled = true;
                d.station = 12;
                d.Show();
            }
            else
            {
                if(textBox7.Text != "")
                {
                    flag1 = true;
                }
                if (textBox8.Text != "")
                {
                    flag2 = true;
                }
                if (textBox9.Text != "")
                {
                    flag3 = true;
                }
                string strconn = "Data source = XIPHORAY\\SQLEXPRESS;Initial Catalog = LIBRARY;Integrated Security = SSPI";
                using (SqlConnection conn = new SqlConnection(strconn))
                {
                    conn.Open();

                    string sql;
                    SqlCommand dbquery = new SqlCommand();
                    dbquery.Connection = conn;                         //插入数据（添增数据）
                    sql = "update book set ";
                    if (flag3)
                    {
                        sql += "bname = '" + textBox9.Text + "'";
                        if(flag2)
                        {
                            sql += ", writer = '" + textBox8.Text + "'";
                            if(flag1)
                            {
                                sql += ", publish = '" + textBox7.Text + "'";
                            }
                        }
                        else
                        {
                            if (flag1)
                            {
                                sql += ", publish = '" + textBox7.Text + "'";
                            }
                        }
                    }
                    else
                    {
                        if (flag2)
                        {
                            sql += "writer = '" + textBox8.Text + "'";
                            if (flag1)
                            {
                                sql += ", publish = '" + textBox7.Text + "'";
                            }
                        }
                        else
                        {
                            if (flag1)
                            {
                                sql += "publish = '" + textBox7.Text + "'";
                            }
                        }
                    }
                    sql += "where ISBN = '" + textBox6.Text + "'";
                    dbquery.CommandText = sql;

                    //dbquery.CommandText = "update xsgluser set password='1234',username = 'teacher' where username = 'teacher777'";       //更新数据
                    i = dbquery.ExecuteNonQuery();
                    if(i == 1)
                    {
                        signoutfail d = new signoutfail();
                        d.TopMost = true;
                        Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                        d.PointToScreen(p);
                        d.Location = p;
                        d.Enabled = true;
                        d.station = 20;
                        d.Show();
                    }
                    else
                    {
                        signoutfail d = new signoutfail();
                        d.TopMost = true;
                        Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                        d.PointToScreen(p);
                        d.Location = p;
                        d.Enabled = true;
                        d.station = 21;
                        d.Show();
                    }

                }
            }
        }
    }

    
}
