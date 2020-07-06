using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Stopwatch_C
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //定义全局变量
         public int currentCount = 0;
         //定义Timer类
         System.Threading.Timer threadTimer;
         //定义委托
         public delegate void SetControlValue(object value);
 
        private void Form1_Load(object sender, EventArgs e)
        {
            InitTimer();
        }
         /// <summary>
         /// 初始化Timer类
         /// </summary>
         private void InitTimer()
         {
             threadTimer = new System.Threading.Timer(new TimerCallback(TimerUp), null, Timeout.Infinite, 1000);
         }
 
         /// <summary>
         /// 定时到点执行的事件
         /// </summary>
         /// <param name="value"></param>
         private void TimerUp(object value)
         {
             currentCount += 1;
             this.Invoke(new SetControlValue(SetTextBoxValue), currentCount);
         }

         /// <summary>
         /// 给文本框赋值
         /// </summary>
         /// <param name="value"></param>
         private void SetTextBoxValue(object value)
         {
             this.label1.Text = value.ToString();
         }

       
        private void button1_Click(object sender, EventArgs e)
        {
            //立即开始计时，时间间隔1000毫秒
             threadTimer.Change(0, 1000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //停止计时
             threadTimer.Change(Timeout.Infinite, 1000);
        }

    }
}
