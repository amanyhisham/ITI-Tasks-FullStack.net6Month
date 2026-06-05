using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // async means this function can use await inside it
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Loading...";
            btnLoad.Enabled = false; // disable button while loading

            // await means: wait for this to finish WITHOUT freezing the form
            string result = await LoadDataAsync();

            listBox1.Items.Clear();
            listBox1.Items.Add(result);
            listBox1.Items.Add("Student 1 - Ahmed");
            listBox1.Items.Add("Student 2 - Sara");
            listBox1.Items.Add("Student 3 - Mohamed");

            lblStatus.Text = "Done!";
            btnLoad.Enabled = true;
        }

        // this simulates fetching data (like from a database)
        private async Task<string> LoadDataAsync()
        {
            // wait 2 seconds to simulate loading from database
            await Task.Delay(2000);
            return "Data loaded successfully!";
        }
    }
}