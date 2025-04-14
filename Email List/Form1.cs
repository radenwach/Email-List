using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Email_List
{
    public partial class Form1 : Form
    {
        private string connString = "server=localhost;database=email_db;uid=root;pwd=;";
        private int selectedId = -1; 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Load data dari MySQL ke DataGridView
        private void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, nama, email FROM emails";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    if (dataGridView1.Columns["id"] != null)
                    {
                        dataGridView1.Columns["id"].Visible = false;
                    }

                    dataGridView1.Columns["nama"].HeaderText = "Nama Lengkap";
                    dataGridView1.Columns["email"].HeaderText = "Alamat Email";
                    dataGridView1.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns["email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Event saat klik data di DataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (row.Cells["id"].Value != DBNull.Value && row.Cells["id"].Value != null)
                {
                    selectedId = Convert.ToInt32(row.Cells["id"].Value);
                    txtNama.Text = row.Cells["nama"].Value.ToString();
                    txtEmail.Text = row.Cells["email"].Value.ToString();
                }
                else
                {
                    selectedId = -1;
                    ClearFields();
                }
            }
        }

        // Simpan data ke MySQL (Database)
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO emails (nama, email) VALUES (@nama, @email)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Data berhasil disimpan!");
                    ClearFields();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Edit data di MySQL
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedId != -1)
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        string query = "UPDATE emails SET nama=@nama, email=@email WHERE id=@id";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedId);
                            cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Data berhasil diupdate!");
                        ClearFields();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang ingin diedit terlebih dahulu!");
            }
        }

        // Hapus data dari MySQL
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (selectedId != -1)
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM emails WHERE id=@id";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedId);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Data berhasil dihapus!");
                        ClearFields();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang ingin dihapus terlebih dahulu!");
            }
        }

        // Load ulang data
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        // Bersihkan textbox dan reset selectedId
        private void ClearFields()
        {
            txtNama.Clear();
            txtEmail.Clear();
            txtNama.Focus();
            selectedId = -1;
        }

        // Menangani perubahan seleksi di DataGridView
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                if (row.Cells["id"].Value != DBNull.Value && row.Cells["id"].Value != null)
                {
                    selectedId = Convert.ToInt32(row.Cells["id"].Value);
                    txtNama.Text = row.Cells["nama"].Value.ToString();
                    txtEmail.Text = row.Cells["email"].Value.ToString();
                }
                else
                {
                    selectedId = -1;
                    ClearFields();
                }
            }
        }
    }
}
