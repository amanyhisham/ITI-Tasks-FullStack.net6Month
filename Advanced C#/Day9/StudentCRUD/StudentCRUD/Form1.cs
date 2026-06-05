using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentCRUD
{
    public partial class Form1 : Form
    {
        string connStr = @"Data Source=.\SQLEXPRESS03;Initial Catalog=ITI;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT St_Id, St_Fname, St_Lname, St_Age, St_Address FROM dbo.Student";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                listBox1.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    listBox1.Items.Add($"{row["St_Id"]} - {row["St_Fname"]} {row["St_Lname"]}");
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"INSERT INTO dbo.Student (St_Id, St_Fname, St_Lname, St_Age, St_Address)
                                 VALUES (@id, @fname, @lname, @age, @address)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));
                cmd.Parameters.AddWithValue("@fname", txtFname.Text);
                cmd.Parameters.AddWithValue("@lname", txtLname.Text);
                cmd.Parameters.AddWithValue("@age", int.Parse(txtAge.Text));
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم الإضافة بنجاح!");
                LoadData();
                ClearFields();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"UPDATE dbo.Student 
                                 SET St_Fname=@fname, St_Lname=@lname, 
                                     St_Age=@age, St_Address=@address
                                 WHERE St_Id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));
                cmd.Parameters.AddWithValue("@fname", txtFname.Text);
                cmd.Parameters.AddWithValue("@lname", txtLname.Text);
                cmd.Parameters.AddWithValue("@age", int.Parse(txtAge.Text));
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم التعديل بنجاح!");
                LoadData();
                ClearFields();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("مؤكد الحذف؟", "تأكيد", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = "DELETE FROM dbo.Student WHERE St_Id=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم الحذف بنجاح!");
                    LoadData();
                    ClearFields();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtId.Text = row.Cells["St_Id"].Value.ToString();
                txtFname.Text = row.Cells["St_Fname"].Value.ToString();
                txtLname.Text = row.Cells["St_Lname"].Value.ToString();
                txtAge.Text = row.Cells["St_Age"].Value?.ToString();
                txtAddress.Text = row.Cells["St_Address"].Value?.ToString();
            }
        }

        private void ClearFields()
        {
            txtId.Text = txtFname.Text = txtLname.Text =
            txtAge.Text = txtAddress.Text = "";
        }
    }
}