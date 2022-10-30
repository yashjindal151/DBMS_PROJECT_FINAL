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
    public partial class Bookordashboardcs : Form
    {
        string cus;
        public Bookordashboardcs(string cus)
        {
            this.cus = cus;
            InitializeComponent();
            label1.Text = "Welcome " + cus;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new Dashboard(cus);
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form g = new room_no(cus);
            g.Show();
        }

        private void Bookordashboardcs_Load(object sender, EventArgs e)
        {

        }
    }
}
