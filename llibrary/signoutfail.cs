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
    public partial class signoutfail : Form
    {
        public int station;
        public signoutfail()
        {
            InitializeComponent();
            timer3.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Opacity > 0 && Opacity <= 1)//开始执行弹出窗渐渐透明  
            {
                Opacity = Opacity - 0.05;//透明频度0.05  
            }
            if (Opacity == 0)
            {
                timer2.Stop();
                Dispose();                //释放资源
                Close();
            }
            if (Control.MousePosition.X >= Location.X && Control.MousePosition.Y >= Location.Y)
            {
                Opacity = 1;
                timer2.Stop();
                timer1.Start();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();
            if (this.station == 1)
            {
                label1.Text = "未输入姓名及密码";
            }
            else if(this.station == 2)
            {
                label1.Text = "未输入姓名";
            }
            else if (this.station == 3)
            {
                label1.Text = "未输入密码";
            }
            else if(station == 4)
            {
                label1.Text = "用户名或密码错误";
            }
            else if(station == 5)
            {
                label1.Text = "注册成功";
            }
            else if(station == 6)
            {
                label1.Text = "注册失败，请重试";
            }
            else if(station == 7)
            {
                label1.Text = "用户名已存在";
            }
            else if(station == 8)
            {
                label1.Text = "书库内没有这本书";
            }
            else if(station == 0)
            {
                label1.Text = "出错了";
            }
            else if(station == 9)
            {
                label1.Text = "该书不存在或已借出";
            }
            else if(station == 10)
            {
                label1.Text = "该书未借或不存在";
            }
            else if(station == 11)
            {
                label1.Text = "借书已满4本";
            }
            timer1.Start();
        }
    }
}
