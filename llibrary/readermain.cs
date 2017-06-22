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
    public partial class readermain : Form
    {
        public readermain()
        {
            InitializeComponent();
        }

        public void allhide()
        {
            groupBox1.Hide();
            groupBox2.Hide();
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
        }

        private void 借书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allhide();
        }

        private void 还书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allhide();
        }

        private void 订购ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allhide();
        }


    }
}
