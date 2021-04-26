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
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void laptopServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBooking1 fb1 = new FormBooking1();
            fb1.Show();
        }

        private void myAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin fl = new FormLogin();
            fl.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormProfile fp = new FormProfile();
            fp.Show();
        }

        private void otherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 fpay = new Form5();
            fpay.Show();
        }

        private void bookingHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 fHistory = new Form6();
            fHistory.Show();
        }

        private void pickUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 fPickUp = new Form7();
            fPickUp.Show();
        }
    }
}
