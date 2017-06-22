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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 signout = new Form2();
            signout.Show();
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定退出么？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Dispose();                //释放资源
                Application.Exit();            //关闭应用程序窗体
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            managermain r = new managermain();
            r.Show();
            Dispose();                //释放资源
            Close();
        }
    }
}
