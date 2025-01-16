using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdleBTClicker
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var reg = new Register();
            reg.Show();
        }

        private void enter_btn_Click(Object sender, EventArgs e)
        {
            if (username_txt.Text != null)
            {
                Player player = Program.LogPlayer(username_txt.Text);
                if (player != null)
                {
                    var test = new Test(player);
                    test.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Please enter your username");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var upload = new Imageupload();
            upload.Show();
        }
    }
}
