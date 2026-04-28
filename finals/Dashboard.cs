namespace finals
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard nm =  new Dashboard();
            nm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            membership nm = new membership();
            nm.Show();
        }
    }
}
