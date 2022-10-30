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
    public partial class Dashboard : Form
    {
        string cus;
        OracleConnection conn;
        public Dashboard(string cus)
        {
            this.cus = cus;
            InitializeComponent();
        }
        public void DB_Connect()
        {

            string db = "Data Source=LAPTOP-VD1P25GN;User ID=ganesh;Password=ganesh";
            conn = new OracleConnection(db);
            conn.Open();
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DB_Connect();
                OracleCommand cm;
               string  str = "select * from BOOK where Email_ID='" + cus + "'";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
