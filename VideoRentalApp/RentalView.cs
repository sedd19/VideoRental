using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoRentalApp
{

    public partial class RentalView : Form
    {
        private string connectionstring = "datasource = 127.0.0.1; database = video_rental; port = 3306; username = root; password =";
        public string username { get; set; }
        public string password { get; set; }

        public string price { get; set; }
        public string video_id { get; set; }

        public string rentalid { get; set; }
        public string daterented { get; set; }
        public string total { get; set; }
        public string penalty { get; set; }

        public string toReturnRentID { get; set; }

        public bool toreturn { get; set; }



        public RentalView()
        {
            InitializeComponent();
        }

        private void RentalView_Load(object sender, EventArgs e)
        {
            GetData("");
            toreturn = false;
            lblstatus.Text = "SELECT ITEM TO RENT";
            dgvVideolist.ClearSelection();
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            if (toreturn == true) {
                return;
            }

            string message = "RENT VIDEO?";
            string titles = "VIDEO";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, titles, buttons);
            if (result == DialogResult.Yes)
            {
                try
                {
                    double total = Convert.ToDouble(price) * 1;

                    insertRent(username,  video_id,  "1",   price,  "0.00", total.ToString(),  "0");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }
        private void GetData(string search)
        {

            dgvVideolist.Columns.Clear();
            dgvVideolist.Columns.Add("video_id", "VID ID");
            dgvVideolist.Columns.Add("video_title", "VIDEO TITLE");
            dgvVideolist.Columns.Add("category", "CATEGORY");
            dgvVideolist.Columns.Add("rentprice", "PRICE");
            dgvVideolist.Columns.Add("ratings", "RATINGS");
            dgvVideolist.Columns.Add("stock", "STOCK");
            dgvVideolist.Columns.Add("daylimit", "LIMIT");
            dgvVideolist.Columns.Add("dateadded", "DATE ADDED");
            dgvVideolist.Rows.Clear();
            MySqlConnection con = new MySqlConnection(connectionstring);
            try
            {

                con.Open();
                string query = "SELECT " +
    " videolist.videoid," +
    " videolist.title," +
    " videolist.category," +
    " videolist.rentprice," +
    " videolist.ratings," +
    " videolist.stock - (SELECT IFNULL(SUM( rent_history.qty),0) FROM rent_history WHERE rent_history.video_id = videolist.videoid AND rent_history.returned ='0')," +
    " videolist.daylimit," +
    " videolist.dateadded" +
    " FROM videolist;";
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
                    dgvVideolist.Rows.Add(row.GetString(0), row.GetString(1), row.GetString(2), row.GetString(3), row.GetString(4), row.GetString(5), row.GetString(6), dateadded);

                }
                dgvVideolist.ClearSelection();
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

        private void insertRent(string cus_code, string video_id, string qty,  string  price, string penalty, string total, string returned)
        {
            try { 
            MySqlConnection con = new MySqlConnection(connectionstring);
            string query = "INSERT INTO `rent_history` " +
                                        "(`rent_id`," +
                                        "`cus_code`," +
                                        "`video_id`," +
                                        "`qty`," +                                        
                                        "`price`," +
                                        "`penalty`," +
                                        "`total`," +
                                        "`returned`" +
                                        ")" +
                                        " VALUES " +
                                        "(''," +
                                        "'" + cus_code + "'," +
                                        "'" + video_id + "'," +
                                        "'" + qty + "'," +                                        
                                        "'" + price + "'," +
                                        "'" + penalty + "'," +
                                        "'" + total + "'," +
                                         "'" + returned + "'" +
                                        ");";
            MySqlCommand MyCommand2 = new MySqlCommand(query, con);
            MySqlDataReader MyReader2;
            con.Open();
            MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.
                MessageBox.Show("RENT IN TOTAL:" + total) ;
           
            GetData("");
            con.Close();
            }
        
                        catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void dgvVideolist_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvVideolist.SelectedCells[0].Value.ToString() != "")
                {
                    if (toreturn==true)
                    {
                        updateReturn((string)dgvVideolist.SelectedCells[0].Value, (string)dgvVideolist.SelectedCells[8].Value, (string)dgvVideolist.SelectedCells[7].Value);
                    }
                    else {
                        video_id = (string)dgvVideolist.SelectedCells[0].Value;
                        price = (string)dgvVideolist.SelectedCells[3].Value;
                    }


                  
                }
  
            }
            catch (Exception err)
            {

            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            lblstatus.Text = "SELECT ITEM TO RETURN";
            btnRent.Enabled = false;
            try
            {
                toreturn = true;
                dgvVideolist.Rows.Clear();
                getRentlist("");


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateReturn(string rentalid,string total,string penalty) {
            string message = "RETURN VIDEO?";
            string titles = "VIDEO";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, titles, buttons);
            if (result == DialogResult.Yes)
            {
                try
                {

                    MySqlConnection con = new MySqlConnection(connectionstring);
                    string query = "UPDATE rent_history SET " +
                                        " `penalty`='" + penalty + "'," +
                                        " `total`='" + total + "'," +
                                        " `returned`='1'" +                                       
                                        " WHERE rent_id='" + rentalid + "';";
                    MySqlCommand MyCommand2 = new MySqlCommand(query, con);
                    MySqlDataReader MyReader2;
                    con.Open();
                    MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.
                    MessageBox.Show("SUCCESSFUL" );
                    GetData("");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message );
                }
            }

        }

        private void getRentlist(string search) {
            dgvVideolist.Columns.Clear();
            dgvVideolist.Columns.Add("video_id", "RENT ID");
            dgvVideolist.Columns.Add("video_title", "VIDEO ID");
            dgvVideolist.Columns.Add("category", "TITLE");
            dgvVideolist.Columns.Add("rentprice", "CATEGORY");
            dgvVideolist.Columns.Add("ratings", "QTY");
            dgvVideolist.Columns.Add("stock", "DATE RENTED");
            dgvVideolist.Columns.Add("daylimit", "PRICE");
            dgvVideolist.Columns.Add("dateadded", "PENALTY");
            dgvVideolist.Columns.Add("dateadded", "TOTAL");
            dgvVideolist.Rows.Clear();
            MySqlConnection con = new MySqlConnection(connectionstring);
            try
            {

                con.Open();
                string query = "SELECT " +
                " r.rent_id," +
                " r.video_id," +
                " v.title," +
                " v.category," +
                " r.qty," +
                " r.date_rented," +
                " r.price," +
                " if(DATEDIFF(CURDATE(), r.date_rented) > v.daylimit, DATEDIFF(CURDATE(), r.date_rented) * 5,0) AS PENALTY," +
               " if (DATEDIFF(CURDATE(), r.date_rented) > v.daylimit, DATEDIFF(CURDATE(), r.date_rented) * 5 + r.price, r.price) AS TOTAL " +
            " FROM " +
                " rent_history r" +
                    " LEFT JOIN " +
                " videolist v ON v.videoid = r.video_id" +
            " WHERE     " +
            " r.cus_code = '"+username+"' AND r.returned = '0';";
              
                var cmd = new MySqlCommand(query, con);
                using MySqlDataReader row = cmd.ExecuteReader();
                while (row.Read())
                {
                    //DATE PARSING                   
                    string dateadded = row.GetDateTime(5).Year + "-" + row.GetDateTime(5).Month + "-" + row.GetDateTime(5).Day;
                    dgvVideolist.Rows.Add(row.GetString(0), row.GetString(1), row.GetString(2), row.GetString(3), row.GetString(4), dateadded, row.GetString(6), row.GetString(7), row.GetString(8));

                }
            
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblstatus.Text = "SELECT ITEM TO RENT";
            btnRent.Enabled = true;
            toreturn = false;
            GetData("");
        }





    }
    

}
