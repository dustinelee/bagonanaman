using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace finals
{
    public partial class membership : Form
    {
        public membership()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dashboard nm = new Dashboard();
            nm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard nm = new Dashboard();
            nm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void membership_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Declare Inputs
            string fullname = txtFullName.Text;
            int age;
            string gender = cmbGender.SelectedItem.ToString();
            string contactnumber = txtContact.Text.ToString();
            string email = txtEmail.Text;
            string membershipplan = cmbMembershipplan.Text;
            string startdate = dtpStartdate.Text;
            string enddate = dtpEndate.Text;


            // Validate Inputs if Empty
            if (string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(email)
                || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(membershipplan)
                || string.IsNullOrEmpty(startdate) || string.IsNullOrEmpty(enddate))
            {
                MessageBox.Show("Please Fill all Field");
                return;
            }
            // Validate input for age
            if (!int.TryParse(txtAge.Text.Trim(), out age))
            {
                MessageBox.Show("Please enter a valid age");
                return;
            }

            // Call Database connection
            DBConnect db = new DBConnect();
            try
            {
                db.Open();
                string query = "INSERT INTO members (fullname,age,gender,gender,contactnumber,email,membershipplan, startdate, enddate ) VALUES (@fullname ,@age , @gender ,@contactnumber ,@email, membershipplan,@startdate,@enddate )";

                // Create MYSQL Query
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, db.Connection);
                // Add parameters
                cmd.Parameters.AddWithValue("@fullname", fullname);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@contactnumber", contactnumber);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@membershipplan", membershipplan);
                cmd.Parameters.AddWithValue("@startdate", startdate);
                cmd.Parameters.AddWithValue("@enddate", enddate);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student added successfully");
                txtFullName.Clear();
                txtAge.Clear();
                txtContact.Clear();
                txtEmail.Clear();
                cmbMembershipplan.SelectedIndex = -1;
                dtpStartdate.Value = DateTime.Now;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.Close();
            }
        }
    }
}
    
