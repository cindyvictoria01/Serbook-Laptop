using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SERBOOK_LAPTOP
{
    public partial class FormProfile : Form
    {
        public FormProfile()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormHome fh = new FormHome();
            fh.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpTanggalLahir.Value.Year >= DateTime.Now.Year)
                {
                    label7.Text = "Notice:\nBirth Date is invalid";
                }
                else 
                {
                    String a = txtNama.Text.Trim();
                    String b = dtpTanggalLahir.Value.ToString();
                    String c = txtEmail.Text.Trim();
                    String d = txtNoTelp.Text.Trim();
                    String un = txtUsername.Text.Trim();
                    String pass = txtPassword.Text.Trim();
                    String notice = "Notice:";
                    if ((a == "") || (b == "") || (c=="") || (d == "") || (un == "") || (pass == "")) // not empty validation
                    {
                        label7.Text = "Notice:\nPlease fill out the entire form";
                    }
                    else
                    {
                        // phone number validation
                        if ((d.Length < 10) || (d.Length > 13))
                        {
                            notice += "\nPhone Number must be in range of 10-13 digits";
                        }
                        else
                        {
                            if (d.StartsWith("08") == false)
                            {
                                notice += "\nPhone Number is invalid";
                            }
                        }
                        // email validation
                        if (c.Length < 5) 
                        {
                            notice += "\nEmail is too short";
                        }
                        else
                        {
                            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                            Match match_email = regex.Match(c);
                            if (match_email.Success)
                            {
                            }
                            else 
                            {
                                notice += "\nEmail is invalid";
                            }
                        }
                        // password validation
                        if (pass.Length < 8)
                        {
                            notice += "\nPassword is too short";
                        }
                        else 
                        { 
                            Regex hasNumber = new Regex(@"[0-9]+");
                            Match match_pass = hasNumber.Match(pass);

                            if (match_pass.Success)
                            {
                                notice = "Notice: Data Saved Successfully";
                            }
                            else
                            {
                                notice += "\nPassword should include at least 1 number";
                            }
                        }
                        label7.Text = notice;
                    }
                }
            }
            catch (Exception ex)
            {
                label7.Text = "Notice: Failed to edit profile";
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = default(char);
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = !radioButton1.Checked;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = radioButton1.Checked ? '\0' : '*';
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            radioButton2.Checked = !radioButton2.Checked;
        }
    }
}
