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
    public partial class signup : Form
    {
        OracleConnection conn;
        public signup()
        {
            InitializeComponent();
        }
        public void DB_Connect() {

            string db = "Data Source=LAPTOP-VD1P25GN;User ID=ganesh;Password=ganesh";
            conn = new OracleConnection(db);
            conn.Open();
                }
        private void button3_Click(object sender, EventArgs e)
        {
            Form signin = new Signin();
            signin.Show();
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void signup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == textBox4.Text)
            {
                try
                {
                    DB_Connect();
                    OracleCommand cm = new OracleCommand();
                    cm.Connection = conn;
                    cm.CommandText = "insert into Customer values('" + textBox1.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                    cm.CommandType = CommandType.Text;
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Successfull SignUp!");
                    conn.Close();
                }
                catch (Exception E)
                {
                    MessageBox.Show("Already Have a Account!");
                }
            }
            else
            {
                MessageBox.Show("Password and Re-enter password Doesn't Match!");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
