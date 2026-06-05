namespace AsyncForm
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
            btnLoad = new System.Windows.Forms.Button();
            lblStatus = new System.Windows.Forms.Label();
            listBox1 = new System.Windows.Forms.ListBox();

            // ---- Form ----
            this.Text = "Async & Await Demo";
            this.Size = new System.Drawing.Size(400, 350);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // ---- Button ----
            btnLoad.Text = "Load Data";
            btnLoad.Location = new System.Drawing.Point(140, 20);
            btnLoad.Size = new System.Drawing.Size(100, 35);
            btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            // ---- Status Label ----
            lblStatus.Text = "Press Load Data to start";
            lblStatus.Location = new System.Drawing.Point(100, 65);
            lblStatus.Size = new System.Drawing.Size(250, 25);
            lblStatus.ForeColor = System.Drawing.Color.Blue;

            // ---- ListBox ----
            listBox1.Location = new System.Drawing.Point(50, 100);
            listBox1.Size = new System.Drawing.Size(280, 180);

            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                btnLoad, lblStatus, listBox1
            });
        }

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox listBox1;
    }
}