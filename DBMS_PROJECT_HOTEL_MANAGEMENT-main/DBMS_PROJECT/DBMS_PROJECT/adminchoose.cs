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
    public partial class adminchoose : Form
    {
        string admin;
        public adminchoose(string admin)
        {
            this.admin = admin;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text== "Admin Dashboard")
            {
                Form f = new AdminDashboard();
                f.Show();
            }
            if (comboBox1.Text == "Confirm Transaction")
            {
                Form f = new trans();
                f.Show();
            }
            if (comboBox1.Text == "Add Hotel Detail")
            {
                Form f = new Addhotel(admin);
                f.Show();
            }
            if (comboBox1.Text == "Add Admin")
            {
                Form f = new Addadmin(admin);
                f.Show();
            }
            if (comboBox1.Text == "Delete Customer/Hotel/Booking")
            {
                Form f = new delete();
                f.Show();
            }
            
        }
    }
}
