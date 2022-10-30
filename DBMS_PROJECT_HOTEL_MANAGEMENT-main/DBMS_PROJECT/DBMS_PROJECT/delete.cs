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
    public partial class delete : Form
    {
        OracleConnection conn;
        public delete()
        {
            InitializeComponent();
        }
        public void DB_Connect()
        {

            string db = "Data Source=LAPTOP-VD1P25GN;User ID=ganesh;Password=ganesh";
            conn = new OracleConnection(db);
            conn.Open();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) { 
            label1.Visible = true;
                textBox2.Visible = true;
                label2.Visible = false;
                textBox1.Visible =  false;
                label4.Visible = false;
                textBox3.Visible = false;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                label1.Visible = true;
                textBox2.Visible = true;
                label2.Visible = false;
                textBox1.Visible = false;
                label4.Visible = true;
                textBox3.Visible = true;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                label1.Visible =false;
                textBox2.Visible = false;
                label2.Visible = true;
                textBox1.Visible = true;
                label4.Visible = false;
                textBox3.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) {
                try
                {
                    DB_Connect();
                    OracleCommand cm = new OracleCommand("DELETECUSTOMER");
                    cm.Connection = conn;
                    cm.CommandType = CommandType.StoredProcedure;
                    OracleParameter a = new OracleParameter();
                    a.ParameterName = "mail";
                    a.DbType = DbType.String;
                    a.Value = textBox2.Text;
                    cm.Parameters.Add(a);
                    cm.Connection = conn;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Delete Successful!");
                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("server error");
                }
            }
            if (comboBox1.SelectedIndex == 1)
            {
                try
                {
                    DB_Connect();
                    OracleCommand cm = new OracleCommand("DELETEBOOK");
                    cm.Connection = conn;
                    cm.CommandType = CommandType.StoredProcedure;
                    OracleParameter a = new OracleParameter();
                    OracleParameter b = new OracleParameter();
                    a.ParameterName = "mail";
                    a.DbType = DbType.String;
                    a.Value = textBox2.Text;
                    b.ParameterName = "id";
                    b.DbType = DbType.Int64;
                    b.Value = int.Parse(textBox3.Text);
                    cm.Parameters.Add(a);
                    cm.Parameters.Add(b);
                    cm.Connection = conn;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Delete Successful!");
                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("server error");
                }
            }
            if (comboBox1.SelectedIndex == 2)
            {
                try
                {
                    DB_Connect();
                    OracleCommand cm = new OracleCommand("DELETEHOTEL");
                    cm.Connection = conn;
                    cm.CommandType = CommandType.StoredProcedure;
                    OracleParameter a = new OracleParameter();
                    a.ParameterName = "HOTEl";
                    a.DbType = DbType.Int64;
                    a.Value = textBox2.Text;
                    cm.Parameters.Add(a);
                    cm.Connection = conn;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Delete Successful!");
                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("server error");
                }
            }
        }
    }
}
