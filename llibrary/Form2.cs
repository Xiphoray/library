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
        }
    }
}
