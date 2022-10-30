using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_PROJECT
{
    public partial class Form1 : Form
    {
        int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form sign = new Signin();
            sign.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count < 3)
            {
                pictureBox1.Image = imageList1.Images[count];
                count++;
            }
            else
                count = 0;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("RECREATION AREA- Our recreation area is one of the coolest place and is the best when talking about comfortability");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DINING AREA- Our Dining section serves and offers you all kind of food varities");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Get in touch with us - \n 7525904457");
        }
    }
}
