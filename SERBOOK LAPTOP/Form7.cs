using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using SERBOOK_LAPTOP.DB;
using SERBOOK_LAPTOP.Model;

namespace SERBOOK_LAPTOP
{
    public partial class Form7 : Form
    {
        private const string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DB/database.accdb;Persist Security Info=False";
        readonly OleDbConnection dbConn = new OleDbConnection(connectString);
        OleDbCommand cmd;
        readonly DataTable dt = new DataTable();
        Pickup pu = new Pickup();
        public Form7()
        {
            InitializeComponent();
        }
        private void Add(Pickup obj)
        {
            const string sql = "insert into Pickup" +
                "" +
                "(Booking_number, Delivery_person, Notes) values(@booking_number, @delivery_person, @notes)";
            cmd = new OleDbCommand(sql, dbConn);
            cmd.Parameters.AddWithValue("@booking_number", obj.Booking_number);
            cmd.Parameters.AddWithValue("@delivery_person", obj.Delivery_person);
            cmd.Parameters.AddWithValue("@notes", obj.Notes);
            try
            {
                dbConn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    labelNotice.Text = "Notice:\nData successfully added";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConn.Close();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtp1.Value.Date < DateTime.Now.Date)
                {
                    labelNotice.Text = "Notice:\nPick-up date is invalid";
                }
                else
                {
                    if ((txtBook.Text == "") || (txtNama.Text == ""))
                    {
                        labelNotice.Text = "Notice:\nPlease fill out the entire form";
                    }
                    else 
                    {
                        Pickup obj = new Pickup();
                        obj.Booking_number = Int32.Parse(txtBook.Text.Trim());
                        obj.Delivery_person = txtNama.Text.Trim();
                        obj.Notes = rtbNotes.Text.Trim();
                        Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                labelNotice.Text = "Failed to book pickup";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormHome fh = new FormHome();
            fh.Show();
        }
    }
}
