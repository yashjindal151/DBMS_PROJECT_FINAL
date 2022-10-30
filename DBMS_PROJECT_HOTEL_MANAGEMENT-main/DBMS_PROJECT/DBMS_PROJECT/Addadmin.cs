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
    public partial class Addadmin : Form
    {
        string admin;
        OracleConnection conn;
        public Addadmin(string admin)
        {
            this.admin = admin;
            InitializeComponent();
        }
        public void DB_Connect()
        {

            string db = "Data Source=LAPTOP-VD1P25GN;User ID=ganesh;Password=ganesh";
            conn = new OracleConnection(db);
            conn.Open();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == textBox4.Text)
            {
                try
                {
                    DB_Connect();
                    OracleCommand cm = new OracleCommand("ADDADMIN");
                    cm.Connection = conn;
                    cm.CommandType = CommandType.StoredProcedure;
                    OracleParameter a = new OracleParameter();
                    OracleParameter b = new OracleParameter();
                    OracleParameter c = new OracleParameter();
                    OracleParameter d = new OracleParameter();
                    a.ParameterName = "mail";
                    a.DbType = DbType.String;
                    a.Value = textBox5.Text;
                    b.ParameterName = "pass";
                    b.DbType = DbType.String;
                    b.Value = textBox3.Text;
                    c.ParameterName = "username";
                    c.DbType = DbType.String;
                    c.Value = textBox1.Text;
                    d.ParameterName = "mailu";
                    d.DbType = DbType.String;
                    d.Value = admin;
                    cm.Parameters.Add(a);
                    cm.Parameters.Add(b);
                    cm.Parameters.Add(c);
                    cm.Parameters.Add(d);
                    cm.Connection = conn;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Add Sucessful!");
                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("server error");
                }
            }
            else
            {
                MessageBox.Show("Password and Re-enter password Doesn't Match!");
            }
    }
    }
}
