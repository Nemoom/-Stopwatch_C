using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Stopwatch_C
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int t = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.timer1.Interval = 1;
        }
        //计时函数
        public string GetAllTime(int time)
        {
            string hh, mm, ss, fff;

            int f = time % 100; // 毫秒   
            int s = time / 100; // 转化为秒
            int m = s / 60;     // 分
            int h = m / 60;     // 时
            s = s % 60;     // 秒 

            //毫秒格式00
            if (f < 10)
            {
                fff = "0" + f.ToString();
            }
            else
            {
                fff = f.ToString();
            }

            //秒格式00
            if (s < 10)
            {
                ss = "0" + s.ToString();
            }
            else
            {
                ss = s.ToString();
            }

            //分格式00
            if (m < 10)
            {
                mm = "0" + m.ToString();
            }
            else
            {
                mm = m.ToString();
            }

            //时格式00
            if (h < 10)
            {
                hh = "0" + h.ToString();
            }
            else
            {
                hh = h.ToString();
            }

            //返回 hh:mm:ss.ff            
            return hh + ":" + mm + ":" + ss + "." + fff;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t = t + 1;//得到总的毫秒数   
            this.label1.Text = GetAllTime(t);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                this.button1.Text = "停止计时";
                this.timer1.Enabled = true;
            }
            else
            {
                this.button1.Text = "开始计时";
                this.timer1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t = 0;
            //如何正在计时，则先停止再清零，否则直接清零
            if (this.timer1.Enabled == true)
            {
                this.button1_Click(sender, e);
                label1.Text = GetAllTime(t);
            }
            else
            {
                label1.Text = GetAllTime(t);
            }
        }

    }
}
