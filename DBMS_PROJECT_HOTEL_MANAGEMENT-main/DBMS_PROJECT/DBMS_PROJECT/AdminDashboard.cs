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
    public partial class AdminDashboard : Form
    {
        float a = 0, b = 0, h;
        OracleConnection conn;
        public AdminDashboard()
        {
            InitializeComponent();
            try
            {
                DB_Connect();
                OracleCommand c;
                string s = "select count(*) from book where status='Booking Confirmed'";
                c = new OracleCommand(s);
                OracleDataAdapter adapt = new OracleDataAdapter(c.CommandText, conn);
                DataTable dtw = new DataTable();
                adapt.Fill(dtw);
                a = int.Parse(dtw.Rows[0]["count(*)"].ToString());
                string sta = "select count(*) from book where status='In Transit'";
                c = new OracleCommand(sta);
                OracleDataAdapter adaptp = new OracleDataAdapter(c.CommandText, conn);
                DataTable dq = new DataTable();
                adaptp.Fill(dq);
                b = int.Parse(dq.Rows[0]["count(*)"].ToString());
                conn.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show("Something  Went Wrong!");
            }
            h = 100 - (a + b);

            chart1.Titles.Add("Pie Chart");
            chart1.Series["S1"].Points.AddXY("Booking Confirmed", a);
            chart1.Series["S1"].Points.AddXY("In Transit", b);
            chart1.Series["S1"].Points.AddXY("Available", h);
            try
            {
                DB_Connect();
                OracleCommand cm;
                string st = "select * from Customer";
                cm = new OracleCommand(st);
                OracleDataAdapter adapte = new OracleDataAdapter(cm.CommandText, conn);
                DataTable d = new DataTable();
                adapte.Fill(d);
                dataGridView2.DataSource = d;
                conn.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show("Something  Went Wrong!");
            }
        }
        public void DB_Connect()
        {

            string db = "Data Source=LAPTOP-VD1P25GN;User ID=ganesh;Password=ganesh";
            conn = new OracleConnection(db);
            conn.Open();
        }
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DB_Connect();
                OracleCommand cm;
                string str = "select * from Book where Room_id in (select Room_id from Room where Hotel_id in (select Hotel_id from Hotel where Location='" + textBox1.Text + "'))";
                cm = new OracleCommand(str);
                OracleDataAdapter adapter = new OracleDataAdapter(cm.CommandText, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show("Something  Went Wrong!");
            }
          
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
