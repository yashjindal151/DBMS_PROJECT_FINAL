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
    public partial class trans : Form
    {
        OracleConnection conn;
        public trans()
        {
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
            try
            {
                DB_Connect();
                OracleCommand cm = new OracleCommand("BOOKCONFIRM");
                cm.Connection = conn;
                cm.CommandType = CommandType.StoredProcedure;
                OracleParameter a = new OracleParameter();
                OracleParameter b = new OracleParameter();
                a.ParameterName = "mail";
                a.DbType = DbType.String;
                a.Value = textBox2.Text;
                b.ParameterName = "Room";
                b.DbType = DbType.String;
                b.Value = textBox1.Text;
                cm.Parameters.Add(a);
                cm.Parameters.Add(b);
                cm.Connection = conn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.ExecuteNonQuery();
                MessageBox.Show("Booking Confirmed!");
                conn.Close();
            }
            catch
            {
                MessageBox.Show("server error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DB_Connect();
                OracleCommand cm;
                string str = "select * from BOOK";
                cm = new OracleCommand(str);
                OracleDataAdapter adapter = new OracleDataAdapter(cm.CommandText, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show("Invalid Entry!");
            }
        }
    }
}
