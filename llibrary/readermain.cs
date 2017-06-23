﻿using System;
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
            groupBox3.Hide();
            groupBox4.Hide();
            groupBox5.Hide();
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
            infor d = new infor("hehe","we","飞轮", "9787530655603","32","42",true);
            d.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            infor d = new infor("hwfsfe", "wfds", "ee", "9787530655603", "12", "2", false);
            d.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            writersearch d = new writersearch(textBox3.Text);
            d.Show();

        }
    }
}
