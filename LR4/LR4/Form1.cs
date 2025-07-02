using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LR4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadComputers();
        }

        private static string connectionString = "Server=localhost;Database=computer_store;Uid=simon;Pwd=12345;";
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        private void LoadComputers()
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM Computers";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView2.DataSource = dt.Copy();
                    dataGridView3.DataSource = dt.Copy();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load computer catalog. Check your database connection.", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO Computers (Name, CPUType, FrequencyGHz, GPU, CDType, SoundCard, HDD_GB) 
                                     VALUES (@Name, @CPUType, @FrequencyGHz, @GPU, @CDType, @SoundCard, @HDD)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@CPUType", textBox2.Text);
                    cmd.Parameters.AddWithValue("@FrequencyGHz", Convert.ToDecimal(textBox3.Text));
                    cmd.Parameters.AddWithValue("@GPU", textBox4.Text);
                    cmd.Parameters.AddWithValue("@CDType", textBox5.Text);
                    cmd.Parameters.AddWithValue("@SoundCard", textBox6.Text);
                    cmd.Parameters.AddWithValue("@HDD", Convert.ToInt32(textBox7.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Computer has been successfully added to the catalog.", "Add Computer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadComputers();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding a computer. Please check your input data.", "Add Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            textBox1.Text = textBox2.Text = textBox3.Text =
            textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                var row = dataGridView3.SelectedRows[0];
                textBox8.Text = row.Cells["Name"].Value.ToString();
                textBox9.Text = row.Cells["CPUType"].Value.ToString();
                textBox10.Text = row.Cells["FrequencyGHz"].Value.ToString();
                textBox11.Text = row.Cells["GPU"].Value.ToString();
                textBox12.Text = row.Cells["CDType"].Value.ToString();
                textBox13.Text = row.Cells["SoundCard"].Value.ToString();
                textBox14.Text = row.Cells["HDD_GB"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a computer from the list to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = Convert.ToInt32(dataGridView3.SelectedRows[0].Cells["ID"].Value);
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE Computers 
                                     SET Name = @Name, CPUType = @CPUType, FrequencyGHz = @FrequencyGHz,
                                         GPU = @GPU, CDType = @CDType, SoundCard = @SoundCard, HDD_GB = @HDD
                                     WHERE ID = @ID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Name", textBox8.Text);
                    cmd.Parameters.AddWithValue("@CPUType", textBox9.Text);
                    cmd.Parameters.AddWithValue("@FrequencyGHz", Convert.ToDecimal(textBox10.Text));
                    cmd.Parameters.AddWithValue("@GPU", textBox11.Text);
                    cmd.Parameters.AddWithValue("@CDType", textBox12.Text);
                    cmd.Parameters.AddWithValue("@SoundCard", textBox13.Text);
                    cmd.Parameters.AddWithValue("@HDD", Convert.ToInt32(textBox14.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Computer information updated successfully.", "Update Computer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadComputers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating computer details. Please try again.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM Computers WHERE Name LIKE @keyword OR CPUType LIKE @keyword";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + textBox15.Text + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed. Please check your input or try again later.", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
