using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // hide all error labels and success label at the start
            lblNameError.Visible = false;
            lblEmailError.Visible = false;
            lblHobbiesError.Visible = false;
            lblSuccess.Visible = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            // validate Name
            if (txtName.Text.Length < 5)
            {
                lblNameError.Visible = true;
                isValid = false;
            }
            else
            {
                lblNameError.Visible = false;
            }

            // validate Email
            if (!txtEmail.Text.Contains("@"))
            {
                lblEmailError.Visible = true;
                isValid = false;
            }
            else
            {
                lblEmailError.Visible = false;
            }

            // validate Hobbies - at least one must be checked
            if (!chkFootball.Checked && !chkTennis.Checked && !chkSwimming.Checked)
            {
                lblHobbiesError.Visible = true;
                isValid = false;
            }
            else
            {
                lblHobbiesError.Visible = false;
            }

            // if everything is valid, show success message
            if (isValid)
            {
                lblSuccess.Visible = true;
            }
            else
            {
                lblSuccess.Visible = false;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}