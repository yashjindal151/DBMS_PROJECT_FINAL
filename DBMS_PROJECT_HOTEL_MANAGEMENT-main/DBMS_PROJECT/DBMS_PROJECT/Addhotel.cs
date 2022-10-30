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
    public partial class Addhotel : Form
    {
        string admin;
        OracleConnection conn;
        public Addhotel(string admin)
        {
            InitializeComponent();
            this.admin = admin;
        }
        public void DB_Connect()
        {

            string db = "Data Source=LAPTOP-VD1P25GN;User ID=ganesh;Password=ganesh";
            conn = new OracleConnection(db);
            conn.Open();
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DB_Connect();
                OracleCommand cm = new OracleCommand("ADDHOTEL");
                cm.Connection = conn;
                cm.CommandType = CommandType.StoredProcedure;
                OracleParameter a = new OracleParameter();
                OracleParameter b = new OracleParameter();
                OracleParameter c = new OracleParameter();
                OracleParameter d = new OracleParameter();
                OracleParameter f = new OracleParameter();
                a.ParameterName = "Hotel";
                a.DbType = DbType.Int64;
                a.Value = textBox1.Text;
                b.ParameterName = "name";
                b.DbType = DbType.String;
                b.Value = textBox5.Text;
                c.ParameterName = "location";
                c.DbType = DbType.String;
                c.Value = textBox3.Text;
                f.ParameterName = "despt";
                f.DbType = DbType.String;
                f.Value = richTextBox1.Text;
                d.ParameterName = "mailu";
                d.DbType = DbType.String;
                d.Value = admin;
                cm.Parameters.Add(a);
                cm.Parameters.Add(b);
                cm.Parameters.Add(c);
                cm.Parameters.Add(f);
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

        private void Addhotel_Load(object sender, EventArgs e)
        {

        }
    }
}
