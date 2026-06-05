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
            txtValue = new System.Windows.Forms.TextBox();
            txtResult = new System.Windows.Forms.TextBox();
            rbMeterToKm = new System.Windows.Forms.RadioButton();
            rbMeterToMile = new System.Windows.Forms.RadioButton();
            rbMileToMeter = new System.Windows.Forms.RadioButton();
            btnConvert = new System.Windows.Forms.Button();

            // ---- Form ----
            this.Text = "Converter";
            this.Size = new System.Drawing.Size(380, 260);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // ---- "Choose Unit" title label ----
            var lblTitle = new System.Windows.Forms.Label();
            lblTitle.Text = "Choose Unit";
            lblTitle.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            lblTitle.Location = new System.Drawing.Point(220, 20);
            lblTitle.Size = new System.Drawing.Size(110, 25);

            // ---- Value Label ----
            var lblValue = new System.Windows.Forms.Label();
            lblValue.Text = "Value:";
            lblValue.Location = new System.Drawing.Point(30, 55);
            lblValue.Size = new System.Drawing.Size(55, 25);

            // ---- Value TextBox ----
            txtValue.Location = new System.Drawing.Point(90, 52);
            txtValue.Size = new System.Drawing.Size(110, 25);

            // ---- Result Label ----
            var lblResult = new System.Windows.Forms.Label();
            lblResult.Text = "Result:";
            lblResult.Location = new System.Drawing.Point(30, 100);
            lblResult.Size = new System.Drawing.Size(55, 25);

            // ---- Result TextBox (read only) ----
            txtResult.Location = new System.Drawing.Point(90, 97);
            txtResult.Size = new System.Drawing.Size(110, 25);
            txtResult.ReadOnly = true;

            // ---- Radio Buttons ----
            rbMeterToKm.Text = "Meter to Kilometer";
            rbMeterToKm.Location = new System.Drawing.Point(220, 50);
            rbMeterToKm.Size = new System.Drawing.Size(150, 25);

            rbMeterToMile.Text = "Meter to Mile";
            rbMeterToMile.Location = new System.Drawing.Point(220, 80);
            rbMeterToMile.Size = new System.Drawing.Size(150, 25);

            rbMileToMeter.Text = "Mile to Meter";
            rbMileToMeter.Location = new System.Drawing.Point(220, 110);
            rbMileToMeter.Size = new System.Drawing.Size(150, 25);

            // ---- Convert Button ----
            btnConvert.Text = "Convert";
            btnConvert.Location = new System.Drawing.Point(130, 155);
            btnConvert.Size = new System.Drawing.Size(90, 30);
            btnConvert.Click += new System.EventHandler(this.btnConvert_Click);

            // ---- Add everything to the Form ----
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblTitle,
                lblValue, txtValue,
                lblResult, txtResult,
                rbMeterToKm, rbMeterToMile, rbMileToMeter,
                btnConvert
            });
        }

        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.RadioButton rbMeterToKm;
        private System.Windows.Forms.RadioButton rbMeterToMile;
        private System.Windows.Forms.RadioButton rbMileToMeter;
        private System.Windows.Forms.Button btnConvert;
    }
}