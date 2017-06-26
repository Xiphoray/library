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
    public partial class booksearch : Form
    {

        private DataSet myset;
        private SqlDataAdapter da;
        //private SqlCommandBuilder myCbd;
        BindingSource bing1;
        public int pnum;
        public booksearch(string something,int pn)
        {
            InitializeComponent();
            pnum = pn;
            label2.Text = something;
            string strconn = "Data source = XIPHORAY\\SQLEXPRESS;Initial Catalog = LIBRARY;Integrated Security = SSPI";
            string strsq1 = "select bname as 书名,writer as 作者,publish as 出版社,ISBN as ISBN号 from book where bname like '" + something + "%'" ;
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
            }
            catch (SqlException ex)
            {
                signoutfail d = new signoutfail();
                d.TopMost = true;
                Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - d.Width, Screen.PrimaryScreen.WorkingArea.Height - d.Height);
                d.PointToScreen(p);
                d.Location = p;
                d.Enabled = true;
                d.station = 8;
                d.Show();
                this.Close();
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
                        infor d = new infor(sl1, sl2, sl3, something, sl4, sl6, sl5,pnum);
                        d.Show();
                    }

                }

            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string da;
            if(e.RowIndex>-1)
            {
                da = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                bosear(1, da);
            }

        }
    }
}
