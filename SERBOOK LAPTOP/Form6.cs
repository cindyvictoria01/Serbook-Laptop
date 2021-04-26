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

namespace SERBOOK_LAPTOP
{
    public partial class Form6 : Form
    {
        private const string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DB/database.accdb;Persist Security Info=False";
        readonly OleDbConnection dbConn = new OleDbConnection(connectString);
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        readonly DataTable dt = new DataTable();
        public Form6()
        {
            InitializeComponent();
        }

        void LoadDataHistory()
        {
            dgvHistory.Rows.Clear();
            try
            {
                String sql = "SELECT * FROM Booking";
                cmd = new OleDbCommand(sql, dbConn);
                dbConn.Open();
                adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    Booking his = new Booking
                    {
                        Booking_number = Int32.Parse(row[1].ToString()),
                        Laptop_brand = row[3].ToString(),
                        Laptop_model = row[4].ToString(),
                        Damage_type = row[6].ToString(),
                        Status = row[8].ToString()
                    };
                    Populate(his);
                }
                dbConn.Close();
                dt.Rows.Clear();
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
        private void Populate(Booking his)
        {
            dgvHistory.Rows.Add(his.Booking_number, his.Laptop_brand, his.Laptop_model, his.Damage_type, his.Status);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormHome fh = new FormHome();
            fh.Show();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            LoadDataHistory();
        }
    }
}
