using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using MySqlX.XDevAPI.Common;
using System.Linq.Expressions;

namespace VideoRentalApp
{

    public partial class CustomerView : Form
    {
        private string connectionstring = "datasource = 127.0.0.1; database = video_rental; port = 3306; username = root; password =";
        
        public CustomerView()
        {
            InitializeComponent();
            onLoad();
        }
        private void onLoad() {
            MySqlConnection con = new MySqlConnection(connectionstring);

            try
                {
                    con.Open();
                    lblcon.Text = "connected";
                    con.Close();
                    reset();
            
                    GetData("");
                    dgvcustomer.ClearSelection();
                    generateID();
            
                }
                catch (Exception ex)
                {                    
                    MessageBox.Show("Connection Not Established" + ex);
                }
        }
        private void GetData(string search)
        {
           
            dgvcustomer.Columns.Clear();
            dgvcustomer.Columns.Add("cus_code", "CODE");
            dgvcustomer.Columns.Add("cus_firstname", "FIRST NAME");
            dgvcustomer.Columns.Add("cus_middlename", "MIDDLE NAME");
            dgvcustomer.Columns.Add("cus_lastname", "LAST NAME");
            dgvcustomer.Columns.Add("cus_birthdate", "BIRHTDATE");
            dgvcustomer.Columns.Add("cus_gender", "GENDER");
            dgvcustomer.Columns.Add("cus_dateadded", "DATE ADDED");
            dgvcustomer.Rows.Clear();
            MySqlConnection con = new MySqlConnection(connectionstring);
            try
            {
               
                con.Open();
                string query = "SELECT cus_code, cus_firstname,cus_middlename,cus_lastname,cus_birthdate,cus_gender,cus_dateadded,cus_username FROM video_rental.customer ";
                if (search != "")
                {
                    query += "WHERE cus_code LIKE '%" + search + "%' OR" +
                              " cus_firstname LIKE '%" + search + "%' OR" +
                              " cus_middlename LIKE '%" + search + "%' OR" +
                              " cus_lastname LIKE '%" + search + "%' OR" +
                              " cus_birthdate LIKE '%" + search + "%' OR" +
                              " cus_gender LIKE '%" + search + "%' OR" +
                              " cus_dateadded LIKE '%" + search + "%';";
                }
                else {
                    query += ";";
                }
                var cmd = new MySqlCommand(query, con);

              
                using MySqlDataReader row = cmd.ExecuteReader();


                while (row.Read())
                {
                    //DATE PARSING
                    string bdate = row.GetDateTime(4).Year + "-" + row.GetDateTime(4).Month + "-" + row.GetDateTime(4).Day;
                    string dateadded = row.GetDateTime(6).Year + "-" + row.GetDateTime(6).Month + "-" + row.GetDateTime(6).Day;                   
                    dgvcustomer.Rows.Add(row.GetString(0), row.GetString(1), row.GetString(2), row.GetString(3), bdate, row.GetString(5), row.GetString(7), dateadded);
               
                }
               
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData(txtSearch.Text);
        }

        private void generateID()
        {
            MySqlConnection con = new MySqlConnection(connectionstring);
            try
            {
                
                con.Open();
                string query = "SELECT IFNULL(CAST(RAND()*100000.00 AS INT),00001) limit 1";
               
                var cmd = new MySqlCommand(query, con);


                using MySqlDataReader row = cmd.ExecuteReader();


                while (row.Read())
                {
                    lblID.Text = "BGV-"+row.GetString(0);
                }

                con.Close();

                

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFname.Text == "")
            {
                MessageBox.Show("First Name cannot be empty");
                return;
            }
            else if (txtMname.Text == "")
            {
                MessageBox.Show("MIddle Name cannot be empty");
                return;
            }
            else if (txtLname.Text == "")
            {
                MessageBox.Show("Last Name cannot be empty");
                return;
            }
            else if (txtUser.Text == "")
            {
                MessageBox.Show("Last Name cannot be empty");
                return;
            }
            else if (txtPass.Text == "")
            {
                MessageBox.Show("Last Name cannot be empty");
                return;
            }
            else if (rbFemale.Checked == false && rbMale.Checked == false)
            {
                MessageBox.Show("Please select gender");
                return;
            }

            int currentYear = DateTime.Now.Year;
            int dobYear = dtpBday.Value.Year;
            if (dobYear !<= currentYear && dobYear !> (currentYear - 120))
            {
               
            } else {
                MessageBox.Show("Invalid Birthdate" + dobYear +"  "+ currentYear);
                return;
            }
            string gender;
            if (rbFemale.Checked == true)
            {
                gender = "FEMALE";
            }
            else {
                gender = "MALE";
            }

            // CALL INSERT HERE
            insertCustomer(lblID.Text, txtFname.Text, txtMname.Text, txtLname.Text, dtpBday.Value, gender,txtUser.Text,txtPass.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetData("");
            reset();
            
            generateID();
            dgvcustomer.ClearSelection();
          

        }

        private void insertCustomer(string code, string fname, string mname,string lname, DateTime date, string gender, string username, string password) {
            string message = "ADD NEW CUSTOMER?";
            string title = "CUSTOMER";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                try
                {

                    MySqlConnection con = new MySqlConnection(connectionstring);
                    string query = "INSERT INTO `customer` " +
                                        "(`cus_code`," +
                                        "`cus_firstname`," +
                                        "`cus_middlename`," +
                                        "`cus_lastname`," +
                                        "`cus_birthdate`," +
                                        "`cus_gender`," +
                                        "`cus_username`," +
                                        "`cus_password`" +
                                        ")" +
                                        " VALUES " +
                                        "('" + code + "'," +
                                        "'" + fname + "'," +
                                        "'" + mname + "'," +
                                        "'" + lname + "'," +
                                        "'" + date.Year + "-" + date.Month + "-" + date.Day + "'," +
                                        "'" + gender + "',"+
                                        "'" + username + "'," +
                                        "'" + password + "'" +
                                        ");";
                    MySqlCommand MyCommand2 = new MySqlCommand(query, con);
                    MySqlDataReader MyReader2;
                    con.Open();
                    MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.
                    MessageBox.Show("SUCCESSFUL");


                    GetData("");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

          
        }
        private void reset()
        {
            generateID();
            txtFname.Text = "";
            txtMname.Text = "";
            txtLname.Text = "";
            txtUser.Text = "";
            txtPass.Text = "";
            rbFemale.Checked = false;
            rbMale.Checked = false;
            dtpBday.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            btnAdd.Enabled = true;
        }

        private void dgvcustomer_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvcustomer.SelectedCells[0].Value.ToString() != "")
                {
                    getCusInfo(dgvcustomer.SelectedCells[0].Value.ToString());                    
                }
            }
            catch (Exception err)
            {
              
            }
        }

        private void getCusInfo(string id) {
           
            MySqlConnection con = new MySqlConnection(connectionstring);
            try
            {

                con.Open();
                string query = "SELECT cus_code, cus_firstname,cus_middlename,cus_lastname,cus_birthdate,cus_gender,cus_username,cus_password FROM video_rental.customer WHERE cus_code='" + id+"' ";
                var cmd = new MySqlCommand(query, con);
                using MySqlDataReader row = cmd.ExecuteReader();
                while (row.Read())
                {
                    //DATE PARSING
                    string bdate = row.GetDateTime(4).Year + "-" + row.GetDateTime(4).Month + "-" + row.GetDateTime(4).Day;
                  


                    lblID.Text = row.GetString(0);
                    txtFname.Text = row.GetString(1);
                    txtMname.Text = row.GetString(2);
                    txtLname.Text = row.GetString(3);
                    dtpBday.Value = row.GetDateTime(4);
                    if (row.GetString(5) == "MALE")
                    {
                        rbMale.Checked = true;
                    }
                    else {
                        rbFemale.Checked = true;
                    }
                    txtUser.Text = row.GetString(6);
                    txtPass.Text = row.GetString(7);


                }

                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void dgvcustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void updateCustomer(string code, string fname, string mname, string lname, DateTime date, string gender, string username, string password)
        {

            string message = "SAVE CUSTOMER UPDATE?";
            string title = "CUSTOMER";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                try
                {

                    MySqlConnection con = new MySqlConnection(connectionstring);
                    string query = "UPDATE `customer` SET " +
                                        "`cus_firstname`='" + fname + "'," +
                                        "`cus_middlename`='" + mname + "'," +
                                        "`cus_lastname`='" + lname + "'," +
                                        "`cus_birthdate`='" + date.Year + "-" + date.Month + "-" + date.Day + "'," +
                                        "`cus_gender`='" + gender + "'," +
                                        "`cus_username`='" + username + "'," +
                                        "`cus_password`='" + password + "'" +
                                        " WHERE `cus_code`='" + code + "';";

                    MySqlCommand MyCommand2 = new MySqlCommand(query, con);
                    MySqlDataReader MyReader2;
                    con.Open();
                    MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.                   
                    GetData("");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtFname.Text == "")
            {
                MessageBox.Show("First Name cannot be empty");
                return;
            }
            else if (txtMname.Text == "")
            {
                MessageBox.Show("Middle Name cannot be empty");
                return;
            }
            else if (txtLname.Text == "")
            {
                MessageBox.Show("Last Name cannot be empty");
                return;
            }
            else if (rbFemale.Checked == false && rbMale.Checked == false)
            {
                MessageBox.Show("Please select gender");
                return;
            }
            int currentYear = DateTime.Now.Year;
            int dobYear = dtpBday.Value.Year;
            if (dobYear! <= currentYear && dobYear! > (currentYear - 120))
            {
                //none
            }
            else
            {
                MessageBox.Show("Invalid Birthdate" + dobYear + "  " + currentYear);
                return;
            }
            string gender;
            if (rbFemale.Checked == true)
            {
                gender = "FEMALE";
            }
            else
            {
                gender = "MALE";
            }


            //CALL UPDATE CUSTOMER
            updateCustomer(lblID.Text, txtFname.Text, txtMname.Text, txtLname.Text, dtpBday.Value, gender,txtUser.Text,txtPass.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = " DELETE CUSTOMER?  " + lblID.Text;
            string title = "WARNING";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                try
                {

                    MySqlConnection con = new MySqlConnection(connectionstring);
                    string query = "DELETE FROM customer WHERE `cus_code`='" + lblID.Text + "';";

                    MySqlCommand MyCommand2 = new MySqlCommand(query, con);
                    MySqlDataReader MyReader2;
                    con.Open();
                    MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.                   
                    GetData("");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


    }
}
