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
    public partial class forgotpassword : Form
    {
        OracleConnection conn;
        int flag = 0;
        public void DB_Connect()
        {

            string db = "Data Source=LAPTOP-VD1P25GN;User ID=ganesh;Password=ganesh";
            conn = new OracleConnection(db);
            conn.Open();
        }
        public forgotpassword()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form sign = new Signin();
            sign.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DB_Connect();
                OracleCommand cm;
               string     str = "select Key from Customer where Email_ID='" + textBox1.Text + "'";
                cm = new OracleCommand(str);
                OracleDataAdapter adapter = new OracleDataAdapter(cm.CommandText, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                string pass = dt.Rows[0]["Key"].ToString();
                if (pass == textBox2.Text)
                {
                    MessageBox.Show("Verified!");
                    flag = 1;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (flag == 1 && textBox3.Text == textBox4.Text)
            {
                try { 
                DB_Connect();
                OracleCommand cm = new OracleCommand("FORGOTPASSWORD");
                cm.Connection = conn;
                cm.CommandType = CommandType.StoredProcedure;
                OracleParameter a = new OracleParameter();
                OracleParameter b = new OracleParameter();
                a.ParameterName = "mail";
                a.DbType = DbType.String;
                a.Value = textBox1.Text;
                b.ParameterName = "pass";
                b.DbType = DbType.String;
                b.Value = textBox3.Text;
                cm.Parameters.Add(a);
                cm.Parameters.Add(b);
                cm.Connection = conn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.ExecuteNonQuery();
                MessageBox.Show("Update Successful!");
                conn.Close(); }
               catch {
                    MessageBox.Show("server error");
                }
            }
            else
            {
                if (flag == 0)
                {
                    MessageBox.Show("Who will Verify??");
                }
                else
                MessageBox.Show("Password  and Re-Enter Password Doesn't Match!");
            }
          
        }
    }
}
