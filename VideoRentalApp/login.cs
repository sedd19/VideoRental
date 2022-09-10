using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace VideoRentalApp
{
    public partial class login : Form
    {
        private string connectionstring = "datasource = 127.0.0.1; database = video_rental; port = 3306; username = root; password =";
        public login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("INCORRECT INFO");
                return;
            }

            MySqlConnection con = new MySqlConnection(connectionstring);
            try
            {

                con.Open();
                string query = "SELECT count(*) FROM customer WHERE cus_password = '"+textBox2.Text+"' AND cus_username = '"+textBox1.Text+"';";           
                var cmd = new MySqlCommand(query, con);
                using MySqlDataReader row = cmd.ExecuteReader();


                while (row.Read())
                {
                    if (row.GetString(0) == "1") {
                        RentalView rent = new RentalView();
                        
                        rent.username = textBox1.Text;
                        rent.password = textBox2.Text;
                        rent.ShowDialog();
                        this.Close();
                    }
                    else{
                        MessageBox.Show("Customer not available");
                    }
                }

                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

        }
    }
}
