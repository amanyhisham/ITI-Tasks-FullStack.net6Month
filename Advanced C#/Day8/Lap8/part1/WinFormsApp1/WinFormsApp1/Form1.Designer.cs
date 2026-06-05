namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtEmail = new TextBox();
            lblNameError = new Label();
            lblEmailError = new Label();
            lblHobbiesError = new Label();
            lblSuccess = new Label();
            rbMale = new RadioButton();
            rbFemale = new RadioButton();
            chkFootball = new CheckBox();
            chkTennis = new CheckBox();
            chkSwimming = new CheckBox();
            btnRegister = new Button();
            lblName = new Label();
            lblEmail = new Label();
            lblGender = new Label();
            lblHobbies = new Label();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(100, 27);
            txtName.Name = "txtName";
            txtName.Size = new Size(130, 27);
            txtName.TabIndex = 1;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(100, 67);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(130, 27);
            txtEmail.TabIndex = 4;
            // 
            // lblNameError
            // 
            lblNameError.ForeColor = Color.Red;
            lblNameError.Location = new Point(245, 30);
            lblNameError.Name = "lblNameError";
            lblNameError.Size = new Size(300, 25);
            lblNameError.TabIndex = 2;
            lblNameError.Text = "Name must contain at least 5 characters";
            // 
            // lblEmailError
            // 
            lblEmailError.ForeColor = Color.Red;
            lblEmailError.Location = new Point(245, 70);
            lblEmailError.Name = "lblEmailError";
            lblEmailError.Size = new Size(200, 25);
            lblEmailError.TabIndex = 5;
            lblEmailError.Text = "Email must contain @";
            // 
            // lblHobbiesError
            // 
            lblHobbiesError.ForeColor = Color.Red;
            lblHobbiesError.Location = new Point(375, 160);
            lblHobbiesError.Name = "lblHobbiesError";
            lblHobbiesError.Size = new Size(200, 25);
            lblHobbiesError.TabIndex = 13;
            lblHobbiesError.Text = "Choose at least one hoppy";
            // 
            // lblSuccess
            // 
            lblSuccess.ForeColor = Color.Green;
            lblSuccess.Location = new Point(130, 260);
            lblSuccess.Name = "lblSuccess";
            lblSuccess.Size = new Size(300, 25);
            lblSuccess.TabIndex = 15;
            lblSuccess.Text = "Thank you. Your registeration is valid";
            // 
            // rbMale
            // 
            rbMale.Location = new Point(100, 113);
            rbMale.Name = "rbMale";
            rbMale.Size = new Size(70, 25);
            rbMale.TabIndex = 7;
            rbMale.Text = "Male";
            // 
            // rbFemale
            // 
            rbFemale.Location = new Point(185, 113);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new Size(80, 25);
            rbFemale.TabIndex = 8;
            rbFemale.Text = "Female";
            // 
            // chkFootball
            // 
            chkFootball.Location = new Point(100, 158);
            chkFootball.Name = "chkFootball";
            chkFootball.Size = new Size(80, 25);
            chkFootball.TabIndex = 10;
            chkFootball.Text = "Football";
            // 
            // chkTennis
            // 
            chkTennis.Location = new Point(190, 158);
            chkTennis.Name = "chkTennis";
            chkTennis.Size = new Size(75, 25);
            chkTennis.TabIndex = 11;
            chkTennis.Text = "Tennis";
            // 
            // chkSwimming
            // 
            chkSwimming.Location = new Point(275, 158);
            chkSwimming.Name = "chkSwimming";
            chkSwimming.Size = new Size(90, 25);
            chkSwimming.TabIndex = 12;
            chkSwimming.Text = "Swimming";
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(185, 210);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(100, 30);
            btnRegister.TabIndex = 14;
            btnRegister.Text = "Register";
            btnRegister.Click += btnRegister_Click;
            // 
            // lblName
            // 
            lblName.Location = new Point(30, 30);
            lblName.Name = "lblName";
            lblName.Size = new Size(60, 25);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(30, 70);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(60, 25);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Eamil:";
            // 
            // lblGender
            // 
            lblGender.Location = new Point(30, 115);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(60, 25);
            lblGender.TabIndex = 6;
            lblGender.Text = "Gender:";
            // 
            // lblHobbies
            // 
            lblHobbies.Location = new Point(30, 160);
            lblHobbies.Name = "lblHobbies";
            lblHobbies.Size = new Size(65, 25);
            lblHobbies.TabIndex = 9;
            lblHobbies.Text = "Hoppies:";
            // 
            // Form1
            // 
            ClientSize = new Size(983, 404);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblNameError);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblEmailError);
            Controls.Add(lblGender);
            Controls.Add(rbMale);
            Controls.Add(rbFemale);
            Controls.Add(lblHobbies);
            Controls.Add(chkFootball);
            Controls.Add(chkTennis);
            Controls.Add(chkSwimming);
            Controls.Add(lblHobbiesError);
            Controls.Add(btnRegister);
            Controls.Add(lblSuccess);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ش";
            ResumeLayout(false);
            PerformLayout();
        }

        // declare variables
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblNameError;
        private System.Windows.Forms.Label lblEmailError;
        private System.Windows.Forms.Label lblHobbiesError;
        private System.Windows.Forms.Label lblSuccess;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.CheckBox chkFootball;
        private System.Windows.Forms.CheckBox chkTennis;
        private System.Windows.Forms.CheckBox chkSwimming;
        private System.Windows.Forms.Button btnRegister;
        private Label lblName;
        private Label lblEmail;
        private Label lblGender;
        private Label lblHobbies;
    }
}