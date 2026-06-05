using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            // check if the value is a valid number
            if (!double.TryParse(txtValue.Text, out double input))
            {
                MessageBox.Show("Please enter a valid number!");
                return;
            }

            double result = 0;

            if (rbMeterToKm.Checked)
            {
                // 1 meter = 0.001 kilometer
                result = input * 0.001;
            }
            else if (rbMeterToMile.Checked)
            {
                // 1 meter = 0.000621371 mile
                result = input * 0.000621371;
            }
            else if (rbMileToMeter.Checked)
            {
                // 1 mile = 1609.34 meters
                result = input * 1609.34;
            }
            else
            {
                MessageBox.Show("Please choose a unit!");
                return;
            }

            txtResult.Text = result.ToString("F4");
        }
    }
}