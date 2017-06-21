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
                MessageBox.Show("未输入姓名及密码");
                return;
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("未输入姓名");
                return;
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("未输入密码");
                return;
            }
        }
    }
}
