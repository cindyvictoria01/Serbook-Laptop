using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERBOOK_LAPTOP
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((txtUsername.Text == "") || (txtPassword.Text == ""))
            {
                MessageBox.Show("Notice:\nPlease fill out the entire form");
            }
            else
            {
                if (txtUsername.Text == "lara_jean" && txtPassword.Text == "covey7230")
                {
                    MessageBox.Show("Login success");
                    this.Hide();
                    FormHome fh = new FormHome();
                    fh.Show();
                }
                else
                {
                    MessageBox.Show("Sorry, your username or password is incorrect. Please try again");
                }
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

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
