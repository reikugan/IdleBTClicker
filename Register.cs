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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void reg_btn_Click(object sender, EventArgs e)
        {
            if (username_txt.Text != null && nickname_txt.Text != null)
            {
                Program.RegPlayer(username_txt.Text, nickname_txt.Text);
            }
        }
    }
}
