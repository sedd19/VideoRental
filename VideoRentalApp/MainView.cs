namespace VideoRentalApp
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerView cus = new CustomerView();
            cus.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login l = new login();
            l.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VideoList vid = new VideoList();
            vid.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry no reports available");
        }
    }
}