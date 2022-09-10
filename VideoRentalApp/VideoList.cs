using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VideoRentalApp
{
    public partial class VideoList : Form
    {
        private string connectionstring = "datasource = 127.0.0.1; database = video_rental; port = 3306; username = root; password =";
        public VideoList()
        {
            InitializeComponent();
        }

        private void VideoList_Load(object sender, EventArgs e)
        {
          
                MySqlConnection con = new MySqlConnection(connectionstring);

                try
                {
                    con.Open();
                    lblcon.Text = "connected";
                    con.Close();
            
                    reset();
                    GetData("");
                    generateID();
                    dgvVideo.ClearSelection();              
            
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Not Established" + ex);
                }
            
        }
        private void reset()
        {
            generateID();
            txtTitle.Text = "";
            txtPric.Text = "";
            txtStock.Text = "";            
            rbDVD.Checked = false;
            rbVCD.Checked = false;
            btnAdd.Enabled = true;
            cmbRatings.Text = "";
            cmbRent.Text = "";
        }
        private void GetData(string search)
        {

            dgvVideo.Columns.Clear();
            dgvVideo.Columns.Add("video_id", "VID ID");
            dgvVideo.Columns.Add("video_title", "VIDEO TITLE");
            dgvVideo.Columns.Add("category", "CATEGORY");
            dgvVideo.Columns.Add("rentprice", "PRICE");
            dgvVideo.Columns.Add("ratings", "RATINGS");
            dgvVideo.Columns.Add("stock", "STOCK");
            dgvVideo.Columns.Add("daylimit", "LIMIT");
            dgvVideo.Columns.Add("dateadded", "DATE ADDED");
            dgvVideo.Rows.Clear();
            MySqlConnection con = new MySqlConnection(connectionstring);
            try
            {

                con.Open();
                string query = "SELECT videoid,title,category,rentprice,ratings,stock,daylimit,dateadded FROM videolist ";
                if (search != "")
                {
                    query += "WHERE videoid LIKE '%" + search + "%' OR" +
                              " title LIKE '%" + search + "%' OR" +
                              " category LIKE '%" + search + "%' OR" +
                              " rentprice LIKE '%" + search + "%' OR" +
                              " ratings LIKE '%" + search + "%' OR" +
                              " stock LIKE '%" + search + "%' OR" +
                              " daylimit LIKE '%" + search + "%' OR" +
                              " dateadded LIKE '%" + search + "%';";
                }
                else
                {
                    query += ";";
                }
                var cmd = new MySqlCommand(query, con);
                using MySqlDataReader row = cmd.ExecuteReader();
                while (row.Read())
                {
                    //DATE PARSING                   
                    string dateadded = row.GetDateTime(7).Year + "-" + row.GetDateTime(7).Month + "-" + row.GetDateTime(7).Day;
                    dgvVideo.Rows.Add(row.GetString(0), row.GetString(1), row.GetString(2), row.GetString(3), row.GetString(4), row.GetString(5),row.GetString(6),dateadded);

                }
                dgvVideo.ClearSelection();
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

        }
        private void generateID()
        {
            MySqlConnection con = new MySqlConnection(connectionstring);
            try
            {

                con.Open();
                string query = "SELECT CAST(RAND()*100000.00 AS INT)";

                var cmd = new MySqlCommand(query, con);


                using MySqlDataReader row = cmd.ExecuteReader();


                while (row.Read())
                {
                    lblID.Text = "VID-" + row.GetString(0);
                }

                con.Close();



            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void dgvVideo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvVideo.SelectedCells[0].Value.ToString() != "")
                {
                    getVidInfo(dgvVideo.SelectedCells[0].Value.ToString());
                }
            }
            catch (Exception err)
            {

            }
        }
        private void getVidInfo(string id)
        {

            MySqlConnection con = new MySqlConnection(connectionstring);
            try
            {

                con.Open();
                string query = "SELECT videoid,title,category,rentprice,ratings,stock,daylimit,dateadded FROM videolist WHERE videoid='" + id + "' ";
                var cmd = new MySqlCommand(query, con);
                using MySqlDataReader row = cmd.ExecuteReader();
                while (row.Read())
                {
                    lblID.Text = row.GetString(0);
                    txtTitle.Text = row.GetString(1);
                    if (row.GetString(2) == "DVD")
                    {
                        rbDVD.Checked = true;
                    }
                    else {
                        rbVCD.Checked = true;
                    }
                    txtPric.Text = row.GetString(3);
                    cmbRatings.Text = row.GetString(4);
                    txtStock.Text = row.GetString(5);
                    switch (row.GetInt16(6))
                    {
                        case 1:
                            cmbRent.Text = "1";
                            break;
                        case 2:
                            cmbRent.Text = "2";
                            break;
                        case 3:
                            cmbRent.Text = "3";
                            break;                      
                    }

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
            if (txtTitle.Text == "")
            {
                MessageBox.Show("Title cannot be empty");
                return;
            }
            else if (txtStock.Text == "")
            {
                MessageBox.Show("Stock cannot be empty");
                return;
            }
            else if (txtPric.Text == "")
            {
                MessageBox.Show("Price cannot be empty");
                return;
            }
            else if (txtPric.Text == "")
            {
                MessageBox.Show("Price cannot be empty");
                return;
            }
            else if (cmbRatings.Text == "")
            {
                MessageBox.Show("Ratings cannot be empty");
                return;
            }
            else if (cmbRent.Text == "")
            {
                MessageBox.Show("Rent cannot be empty");
                return;
            }

            else if (rbDVD.Checked == false && rbVCD.Checked == false)
            {
                MessageBox.Show("Please select category");
                return;
            }

            string category;
            if (rbDVD.Checked == true)
            {
                category = "DVD";
            }
            else
            {
                category = "VCD";
            }

            // CALL INSERT HERE
            insertVid(lblID.Text, txtTitle.Text, category, txtPric.Text, cmbRatings.Text, txtStock.Text, cmbRent.Text);
        }
        private void insertVid(string videoid, string title, string category, string rentprice, string ratings, string stock, string daylimit)
        {
            string message = "ADD NEW VIDEO?";
            string titles = "VIDEO";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, titles, buttons);
            if (result == DialogResult.Yes)
            {
                try
                {

                    MySqlConnection con = new MySqlConnection(connectionstring);
                    string query = "INSERT INTO `videolist` " +
                                        "(`videoid`," +
                                        "`title`," +
                                        "`category`," +
                                        "`rentprice`," +
                                        "`ratings`," +
                                        "`stock`," +
                                        "`daylimit`" +
                                        ")" +
                                        " VALUES " +
                                        "('" + videoid + "'," +
                                        "'" + title + "'," +
                                        "'" + category + "'," +
                                        "'" + rentprice + "'," +
                                        "'"+ ratings + "'," +
                                        "'" + stock + "'," +
                                         "'" + daylimit + "'" +
                                        ");";
                    MySqlCommand MyCommand2 = new MySqlCommand(query, con);
                    MySqlDataReader MyReader2;
                    con.Open();
                    MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.
                    MessageBox.Show("SUCCESSFUL");
                    reset();
                    GetData("");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void rbVCD_Click(object sender, EventArgs e)
        {
            if (rbVCD.Checked == true)
            {
                txtPric.Text = "25.00";
            }
            else if (rbDVD.Checked == true)
            {
                txtPric.Text = "50.00";
            }
        }

        private void rbDVD_Click(object sender, EventArgs e)
        {
            if (rbVCD.Checked == true)
            {
                txtPric.Text = "25.00";
            }
            else if (rbDVD.Checked == true)
            {
                txtPric.Text = "50.00";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == "")
            {
                MessageBox.Show("Title cannot be empty");
                return;
            }
            else if (txtStock.Text == "")
            {
                MessageBox.Show("Stock cannot be empty");
                return;
            }
            else if (txtPric.Text == "")
            {
                MessageBox.Show("Price cannot be empty");
                return;
            }
            else if (txtPric.Text == "")
            {
                MessageBox.Show("Price cannot be empty");
                return;
            }
            else if (cmbRatings.Text == "")
            {
                MessageBox.Show("Ratings cannot be empty");
                return;
            }
            else if (cmbRent.Text == "")
            {
                MessageBox.Show("Rent cannot be empty");
                return;
            }

            else if (rbDVD.Checked == false && rbVCD.Checked == false)
            {
                MessageBox.Show("Please select category");
                return;
            }

            string category;
            if (rbDVD.Checked == true)
            {
                category = "DVD";
            }
            else
            {
                category = "VCD";
            }

            // CALL UPDATE HERE
            updateVid(lblID.Text, txtTitle.Text, category, txtPric.Text, cmbRatings.Text, txtStock.Text, cmbRent.Text);
        }
        private void updateVid(string videoid, string title, string category, string rentprice, string ratings, string stock, string daylimit)
        {
            string message = "UPDATE VIDEO?";
            string titles = "VIDEO";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, titles, buttons);
            if (result == DialogResult.Yes)
            {
                try
                {

                    MySqlConnection con = new MySqlConnection(connectionstring);
                    string query = "UPDATE `videolist` SET " +

                                        "`title`='" + title + "'," +
                                        "`category`='" + category + "'," +
                                        "`rentprice`='" + rentprice + "'," +
                                        "`ratings`='" + ratings + "'," +
                                        "`stock`='" + stock + "'," +
                                        "`daylimit`='" + daylimit + "' WHERE videoid='" + videoid + "';";
                                        
                                  
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = " DELETE VIDEO?  " + lblID.Text;
            string title = "WARNING";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                try
                {

                    MySqlConnection con = new MySqlConnection(connectionstring);
                    string query = "DELETE FROM videolist WHERE `videoid`='" + lblID.Text + "';";

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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData(txtSearch.Text);
        }

    }
}
