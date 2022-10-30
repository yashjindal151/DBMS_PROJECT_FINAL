using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.DataAccess.Types;
namespace DBMS_PROJECT
{
    public partial class Signin : Form
    {
        OracleConnection conn;
        public Signin()
        {
            InitializeComponent();
        }
        public void DB_Connect()
        {

            string db = "Data Source=LAPTOP-VD1P25GN;User ID=ganesh;Password=ganesh";
            conn = new OracleConnection(db);
            conn.Open();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form forg=new forgotpassword();
                forg.Show();
           this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form signup = new signup();
            signup.Show();
            this.Close();
        }

        private void Signin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try { 
                DB_Connect();
                OracleCommand cm;
                string str = null;
                if (comboBox1.Text == "Customer")
                    str = "select SIGNUPCUSTOMER('" + textBox1.Text + "') from dual";
                else if (comboBox1.Text == "Admin")
                    str = "select SIGNUPADMIN('" + textBox1.Text + "') from dual";
                cm = new OracleCommand(str);
                OracleDataAdapter adapter = new OracleDataAdapter(cm.CommandText, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                string pass = dt.Rows[0][0].ToString();
                if (pass == textBox2.Text)
                {
                    MessageBox.Show("Welcome " + textBox1.Text);
                    Form room = new Bookordashboardcs(textBox1.Text);
                    if (comboBox1.Text == "Admin")
                        room = new adminchoose(textBox1.Text);
                    room.Show();
                    conn.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Entry!");
                    textBox1.Text = null;
                    textBox2.Text = null;
                }
                conn.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show("Invalid Entry!");
                textBox1.Text = null;
                textBox2.Text = null;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
