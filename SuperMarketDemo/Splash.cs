using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarketDemo
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }
        int startPoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startPoint += 1;
            myProgress.Value = startPoint;
            if (myProgress.Value == 100) 
            {
                myProgress.Value = 0;
                timer1.Stop();
                Form1 log = new Form1();
                this.Hide();
                log.Show();
            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void myProgress_Click(object sender, EventArgs e)
        {

        }
    }
}
