namespace StudentCRUD
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblFname;
        private System.Windows.Forms.Label lblLname;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblAddress;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblFname = new System.Windows.Forms.Label();
            this.lblLname = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // lblId
            this.lblId.Text = "ID:";
            this.lblId.Location = new System.Drawing.Point(20, 20);
            this.lblId.Size = new System.Drawing.Size(80, 20);

            // txtId
            this.txtId.Location = new System.Drawing.Point(110, 17);
            this.txtId.Size = new System.Drawing.Size(150, 22);
            this.txtId.Name = "txtId";

            // lblFname
            this.lblFname.Text = "First Name:";
            this.lblFname.Location = new System.Drawing.Point(20, 55);
            this.lblFname.Size = new System.Drawing.Size(80, 20);

            // txtFname
            this.txtFname.Location = new System.Drawing.Point(110, 52);
            this.txtFname.Size = new System.Drawing.Size(150, 22);
            this.txtFname.Name = "txtFname";

            // lblLname
            this.lblLname.Text = "Last Name:";
            this.lblLname.Location = new System.Drawing.Point(20, 90);
            this.lblLname.Size = new System.Drawing.Size(80, 20);

            // txtLname
            this.txtLname.Location = new System.Drawing.Point(110, 87);
            this.txtLname.Size = new System.Drawing.Size(150, 22);
            this.txtLname.Name = "txtLname";

            // lblAge
            this.lblAge.Text = "Age:";
            this.lblAge.Location = new System.Drawing.Point(20, 125);
            this.lblAge.Size = new System.Drawing.Size(80, 20);

            // txtAge
            this.txtAge.Location = new System.Drawing.Point(110, 122);
            this.txtAge.Size = new System.Drawing.Size(150, 22);
            this.txtAge.Name = "txtAge";

            // lblAddress
            this.lblAddress.Text = "Address:";
            this.lblAddress.Location = new System.Drawing.Point(20, 160);
            this.lblAddress.Size = new System.Drawing.Size(80, 20);

            // txtAddress
            this.txtAddress.Location = new System.Drawing.Point(110, 157);
            this.txtAddress.Size = new System.Drawing.Size(150, 22);
            this.txtAddress.Name = "txtAddress";

            // btnInsert
            this.btnInsert.Text = "Insert";
            this.btnInsert.Location = new System.Drawing.Point(20, 200);
            this.btnInsert.Size = new System.Drawing.Size(75, 30);
            this.btnInsert.BackColor = System.Drawing.Color.LightGreen;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);

            // btnUpdate
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Location = new System.Drawing.Point(110, 200);
            this.btnUpdate.Size = new System.Drawing.Size(75, 30);
            this.btnUpdate.BackColor = System.Drawing.Color.LightBlue;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnDelete
            this.btnDelete.Text = "Delete";
            this.btnDelete.Location = new System.Drawing.Point(200, 200);
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.BackColor = System.Drawing.Color.LightCoral;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // dataGridView1
            this.dataGridView1.Location = new System.Drawing.Point(20, 250);
            this.dataGridView1.Size = new System.Drawing.Size(600, 200);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);

            // listBox1
            this.listBox1.Location = new System.Drawing.Point(650, 250);
            this.listBox1.Size = new System.Drawing.Size(200, 200);
            this.listBox1.Name = "listBox1";

            // Form1
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Text = "Student CRUD";
            this.Load += new System.EventHandler(this.Form1_Load);

            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblFname);
            this.Controls.Add(this.txtFname);
            this.Controls.Add(this.lblLname);
            this.Controls.Add(this.txtLname);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.listBox1);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}