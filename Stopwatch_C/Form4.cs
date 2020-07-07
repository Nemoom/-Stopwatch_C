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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        System.Diagnostics.Stopwatch sw;

        private void button1_Click(object sender, EventArgs e)
        {
            sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            label1.Text = String.Format("{0}天{1}小时bai{2}分du{3}秒{4}毫秒", ts.Days, ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = sw.Elapsed;

            label1.Text = String.Format("{0}天{1}小时{2}分{3}秒{4}毫秒", ts.Days, ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
        }
    }
}
