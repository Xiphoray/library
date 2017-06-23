using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace llibrary
{
    public partial class infor : Form
    {
        public string bname, writer, publish, ISBN, sertime, brotime;
        public bool station;
        public infor(string bn, string wr, string pu, string IS, string se, string br,bool st)
        {
            InitializeComponent();
            bname = bn;
            writer = wr;
            publish = pu;
            ISBN = IS;
            sertime = se;
            brotime = br;
            station = st;
            timer1.Start();
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
                button1.Show();
            }

            qrCodeGraphicControl1.Text = "https://book.douban.com/subject_search?search_text=" + ISBN;

        }
    }
}
