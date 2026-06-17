using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7224/api/Courses";

        public Form1()
        {
            InitializeComponent();

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (request, cert, chain, errors) =>
            {
                // Allow invalid SSL for localhost only
                try
                {
                    if (request?.RequestUri != null && request.RequestUri.IsLoopback)
                        return true;
                }
                catch { }
                return errors == System.Net.Security.SslPolicyErrors.None;
            };

            _httpClient = new HttpClient(handler);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadCoursesAsync();
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            await LoadCoursesAsync();
        }

        private async Task LoadCoursesAsync()
        {
            try
            {
                var resp = await _httpClient.GetAsync(BaseUrl);
                if (!resp.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Failed to load courses: {resp.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var stream = await resp.Content.ReadAsStreamAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var courses = await JsonSerializer.DeserializeAsync<List<Course>>(stream, options) ?? new List<Course>();

                // bind to grid
                dgvCourses.DataSource = null;
                dgvCourses.DataSource = courses;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            await AddCourseAsync();
        }

        private async Task AddCourseAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Name is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtDuration.Text, out var duration))
                {
                    MessageBox.Show("Duration must be an integer", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var course = new Course
                {
                    Crs_name = txtName.Text,
                    Crs_desc = txtDesc.Text,
                    Duration = duration
                };

                var options = new JsonSerializerOptions { PropertyNamingPolicy = null };
                var json = JsonSerializer.Serialize(course, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var resp = await _httpClient.PostAsync(BaseUrl, content);
                if (resp.IsSuccessStatusCode)
                {
                    MessageBox.Show("Course added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCoursesAsync();
                }
                else
                {
                    var respText = await resp.Content.ReadAsStringAsync();
                    MessageBox.Show($"Failed to add course: {resp.StatusCode}\n{respText}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCourses_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCourses.CurrentRow?.DataBoundItem is Course c)
                {
                    txtName.Text = c.Crs_name;
                    txtDesc.Text = c.Crs_desc;
                    txtDuration.Text = c.Duration.ToString();
                }
            }
            catch
            {
                // ignore
            }
        }
    }
}
