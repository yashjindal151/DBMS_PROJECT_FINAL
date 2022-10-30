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
    public partial class room_no : Form
    {
        OracleConnection conn;
        int room, price;
        string hotel,cus;
        public room_no(string mail)
        {
            this.cus = mail;
            InitializeComponent();
        }
        public void DB_Connect()
        {

            string db = "Data Source=LAPTOP-VD1P25GN;User ID=ganesh;Password=ganesh";
            conn = new OracleConnection(db);
            conn.Open();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DB_Connect();
                OracleCommand cm;
                string str = "select Room_id, Hotel_id from Room where BHK='" + textBox1.Text + "' and Price >='" + textBox3.Text + "' and Price<='" + textBox4.Text + "' and Hotel_id in(select Hotel_id from Hotel where Location = '" + textBox2.Text + "')";
                cm = new OracleCommand(str);
                OracleDataAdapter adapter = new OracleDataAdapter(cm.CommandText, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                int n = dt.Rows.Count;
                if (n == 0)
                {
                    MessageBox.Show("No Data Found!");
                    textBox1.Text = null;
                    textBox2.Text = null;
                    textBox3.Text = null;
                    textBox4.Text = null;
                }
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Hotel_id";
                comboBox1.ValueMember = "Room_id";
                conn.Close();
            }
            catch(Exception E)
            {
                MessageBox.Show("No Data Found!");
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void room_no_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DB_Connect();
                string str = "select Name,Location,Description from Hotel where Hotel_id= '" + comboBox1.Text + "'";
                OracleCommand cm = new OracleCommand(str);
                OracleDataAdapter adapter = new OracleDataAdapter(cm.CommandText, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                string h = "Name: " + dt.Rows[0]["Name"].ToString();
                h += ". \nLocation: " + dt.Rows[0]["Location"].ToString();
                h += ".\nDescription: " + dt.Rows[0]["Description"].ToString();
                string st = "select Room_id,Price,DescriptionR from Room where Hotel_id= '" + comboBox1.Text + "' and Room_id= '" + comboBox1.SelectedValue + "'";
                OracleCommand c = new OracleCommand(st);
                OracleDataAdapter adapt = new OracleDataAdapter(c.CommandText, conn);
                DataTable dtr = new DataTable();
                adapt.Fill(dtr);
                h += ".\nRoom_ID: " + dtr.Rows[0]["Room_id"].ToString();
                h += ".\nprice: " + dtr.Rows[0]["Price"].ToString();
                h += ".\nDescription of Room: " + dtr.Rows[0]["DescriptionR"].ToString() + ".";
                richTextBox1.Text = h;
                room = int.Parse(dtr.Rows[0]["Room_id"].ToString());
                hotel = dt.Rows[0]["Name"].ToString();
                price = int.Parse(dtr.Rows[0]["Price"].ToString());
                conn.Close();
            }
            catch(Exception E)
            {
                MessageBox.Show("Something Went Wrong!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (hotel != null)
            {
                Form f = new Transaction(price, hotel, room, cus);
                f.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Select Something");
            }
        }
    }
}
