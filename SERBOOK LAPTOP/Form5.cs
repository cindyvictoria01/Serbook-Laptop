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
using SERBOOK_LAPTOP.Model;
using SERBOOK_LAPTOP.DB;
using System.Text.RegularExpressions;

namespace SERBOOK_LAPTOP
{
    public partial class Form5 : Form
    {
        private const string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DB/database.accdb;Persist Security Info=False";
        readonly OleDbConnection dbConn = new OleDbConnection(connectString);
        OleDbCommand cmd;
        readonly DataTable dt = new DataTable();
        Booking bk = new Booking();
        public Form5()
        {
            InitializeComponent();
        }

        private void Add(Payment obj)
        {
            const string sql = "insert into Payment" +
                "" +
                "(Booking_number, Payment_method, Account_name, Email_address) values(@booking_number, @payment_method, @account_name, @email_address)";
            cmd = new OleDbCommand(sql, dbConn);
            cmd.Parameters.AddWithValue("@booking_number", obj.Booking_number);
            cmd.Parameters.AddWithValue("@payment_method", obj.Payment_method);
            cmd.Parameters.AddWithValue("@account_name", obj.Account_name);
            cmd.Parameters.AddWithValue("@email_address", obj.Email_address);
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
                if (dateTimePicker1.Value.Date > DateTime.Now.Date)
                {
                    labelNotice.Text = "Notice:\nPayment date is invalid";
                }
                else
                {
                    // validate not empty
                    String a = textBox1.Text.Trim();
                    String b = comboBox1.Text.Trim();
                    String c = textBox4.Text.Trim();
                    String d = textBox5.Text.Trim();
                    if ((a == "") || (b == "") || (c == "") || (d == ""))
                    {
                        labelNotice.Text = "Notice:\nPlease fill out the entire form";
                    }
                    else
                    {
                        // email validation
                        String email_temp = textBox5.Text.Trim();
                        if (email_temp.Length < 5)
                        {
                            labelNotice.Text += "\nEmail is too short";
                        }
                        else
                        {
                            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                            Match match_email = regex.Match(email_temp);
                            if (match_email.Success)
                            {
                                int payment = Int32.Parse(textBox1.Text.Trim());
                                Payment obj = new Payment();
                                obj.Booking_number = Int32.Parse(textBox1.Text.Trim());
                                obj.Payment_method = comboBox1.Text.Trim();
                                obj.Account_name = textBox4.Text.Trim();
                                obj.Email_address = textBox5.Text.Trim();
                                Add(obj);
                            }
                            else
                            {
                                labelNotice.Text += "\nEmail is invalid";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                labelNotice.Text += "Booking failed";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormHome fh = new FormHome();
            fh.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
