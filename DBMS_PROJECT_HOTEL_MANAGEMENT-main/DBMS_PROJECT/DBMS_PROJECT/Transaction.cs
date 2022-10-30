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
    public partial class Transaction : Form
    {
        int room=0, price=0;
        string hotel=null,cus;
        OracleConnection conn;
        public Transaction(int price,string hotel,int room,string cus)
        {
            this.room = room;
            this.price = price;
            this.hotel = hotel;
            this.cus = cus;
            InitializeComponent();
            richTextBox1.Text = "Room ID: " + this.room.ToString() + "\nHotel Name: " + this.hotel + " \nPrice: " + this.price.ToString();
        }
        public void DB_Connect()
        {

            string db = "Data Source=LAPTOP-VD1P25GN;User ID=ganesh;Password=ganesh";
            conn = new OracleConnection(db);
            conn.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new Dashboard(cus);
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         Form fo = new pay(price);
            fo.Show();
            try
            {
                DB_Connect();
                OracleCommand cm = new OracleCommand();
                cm.Connection = conn;
                cm.CommandText = "insert into BOOK values('" + room.ToString() + "','" + hotel + "','" + price.ToString() + "','" + cus + "','In Transit')";
                cm.CommandType = CommandType.Text;
                cm.ExecuteNonQuery();
                MessageBox.Show("Open DashBoard After Paying!");
                conn.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show("Server Error!");
            }
        }

        private void Transaction_Load(object sender, EventArgs e)
        {

        }
    }
}
