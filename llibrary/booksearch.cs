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
        public booksearch(string something)
        {
            InitializeComponent();

            label2.Text = something;
            string strconn = "Data source = XIPHORAY\\SQLEXPRESS;Initial Catalog = LIBRARY;Integrated Security = SSPI";
            string strsq1 = "select bname,writer,publish,ISBN from book where bname like '" + something + "%'" ;
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
    }
}
