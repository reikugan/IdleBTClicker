using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdleBTClicker
{
    public partial class Imageupload : Form
    {

        string selectedFilePath;

        public Imageupload()
        {
            InitializeComponent();
            label1.Visible = false;
        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;

                label1.Text = selectedFilePath;
                label1.Visible = true;
            }
        }

        private void upld_Click(object sender, EventArgs e)
        {
            if (txtbox != null)
            {
                SaveImage(label1.Text, txtbox.Text);
            }

            this.Dispose();
        }

        public static void SaveImage(string filePath, string coin_name)
        {
            byte[] imageData = File.ReadAllBytes(filePath);
            MessageBox.Show("Image size: " + imageData.Length + " bytes");

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(Program.coinsconnect))
                {
                    con.Open();

                  
                    string query = "UPDATE coins SET img = @ImageData WHERE coin = @CoinName";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ImageData", imageData);
                        cmd.Parameters.AddWithValue("@CoinName", coin_name);
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0) {
                            MessageBox.Show($"Rows inserted {i}");
                        } else
                        {
                            MessageBox.Show("Not inserted");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
