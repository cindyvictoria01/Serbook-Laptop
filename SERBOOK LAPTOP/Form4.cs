using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using SERBOOK_LAPTOP.DB;

namespace SERBOOK_LAPTOP
{
    public partial class FormBooking1 : Form
    {
        private const string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DB/database.accdb;Persist Security Info=False";
        readonly OleDbConnection dbConn = new OleDbConnection(connectString);
        OleDbCommand cmd;
        readonly DataTable dt = new DataTable();
        public FormBooking1()
        {
            InitializeComponent();
        }

        private void Add(Booking obj)
        {
            const string sql = "insert into Booking" +
                "" +
                "(Booking_number, Delivery_person, Laptop_brand, Laptop_model, Accessories, Damage_type, Notes) values(@booking_number, @delivery_person, @laptop_brand, @laptop_model, @accessories, @damage_type, @notes)";
            cmd = new OleDbCommand(sql, dbConn);
            cmd.Parameters.AddWithValue("@booking_number", obj.Booking_number);
            cmd.Parameters.AddWithValue("@delivery_person", obj.Delivery_person);
            cmd.Parameters.AddWithValue("@laptop_brand", obj.Laptop_brand);
            cmd.Parameters.AddWithValue("@laptop_model", obj.Laptop_model);
            cmd.Parameters.AddWithValue("@accessories", obj.Accessories);
            cmd.Parameters.AddWithValue("@damage_type", obj.Damage_type);
            cmd.Parameters.AddWithValue("@notes", obj.Notes);
            cmd.Parameters.AddWithValue("@status", obj.Status);
            try
            {
                dbConn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    label9.Text = "Notice:\nData successfully added";
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
                    label9.Text = "Notice:\nBooking date is invalid";
                }   
                else {
                    // merge checkbox into one string
                    String aksesoris = "";
                    if (checkBox1.Checked) {
                        aksesoris += "charger";
                    }
                    if (checkBox2.Checked)
                    {
                        aksesoris += " mouse";
                    }
                    if (checkBox3.Checked)
                    {
                        aksesoris += " bag";
                    }
                    // deafult status
                    String status_default = "Waiting for approval";
                    // input to database
                    int booking = Int32.Parse(txtBookingNum.Text.Trim());
                    // validate not empty
                    String a = txtBookingNum.Text.Trim();
                    String b = txtNama.Text.Trim();
                    String c = txtBrand.Text.Trim();
                    String d = txtModel.Text.Trim();
                    String f = cbDamage.Text.Trim();
                    if ((a == "") || (b == "") || (c == "") || (d == "") || (f == "")) 
                    {
                        label9.Text = "Notice:\nPlease fill out the entire form";
                    }
                    else
                    {
                        Booking obj = new Booking
                        {
                            Booking_number = Int32.Parse(txtBookingNum.Text.Trim()),
                            Delivery_person = txtNama.Text.Trim(),
                            Laptop_brand = txtBrand.Text.Trim(),
                            Laptop_model = txtModel.Text.Trim(),
                            Accessories = aksesoris.Trim(),
                            Damage_type = cbDamage.Text.Trim(),
                            Notes = rtbNote.Text.Trim(),
                            Status = status_default.Trim()
                        };
                        Add(obj);
                    }   
                }
            }
            catch(Exception ex)
            {
                label9.Text = "Notice:\nFailed to book service";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormHome fh = new FormHome();
            fh.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
