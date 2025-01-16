namespace IdleBTClicker
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            usr_lbl = new Label();
            username_txt = new TextBox();
            nick = new Label();
            nickname_txt = new TextBox();
            reg_btn = new Button();
            exit_btn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gold;
            label1.Location = new Point(58, 9);
            label1.Name = "label1";
            label1.Size = new Size(178, 21);
            label1.TabIndex = 0;
            label1.Text = "User registration form";
            // 
            // usr_lbl
            // 
            usr_lbl.AutoSize = true;
            usr_lbl.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usr_lbl.ForeColor = Color.Gold;
            usr_lbl.Location = new Point(27, 84);
            usr_lbl.Name = "usr_lbl";
            usr_lbl.Size = new Size(67, 15);
            usr_lbl.TabIndex = 1;
            usr_lbl.Text = "Username:";
            // 
            // username_txt
            // 
            username_txt.Location = new Point(96, 76);
            username_txt.Name = "username_txt";
            username_txt.Size = new Size(107, 23);
            username_txt.TabIndex = 2;
            // 
            // nick
            // 
            nick.AutoSize = true;
            nick.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nick.ForeColor = Color.Gold;
            nick.Location = new Point(27, 113);
            nick.Name = "nick";
            nick.Size = new Size(66, 15);
            nick.TabIndex = 3;
            nick.Text = "Nickname:";
            // 
            // nickname_txt
            // 
            nickname_txt.Location = new Point(96, 105);
            nickname_txt.Name = "nickname_txt";
            nickname_txt.Size = new Size(107, 23);
            nickname_txt.TabIndex = 4;
            // 
            // reg_btn
            // 
            reg_btn.BackColor = Color.Green;
            reg_btn.FlatStyle = FlatStyle.Flat;
            reg_btn.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            reg_btn.ForeColor = Color.Gold;
            reg_btn.Location = new Point(96, 161);
            reg_btn.Name = "reg_btn";
            reg_btn.Size = new Size(107, 40);
            reg_btn.TabIndex = 5;
            reg_btn.Text = "Register";
            reg_btn.UseVisualStyleBackColor = false;
            reg_btn.Click += reg_btn_Click;
            // 
            // exit_btn
            // 
            exit_btn.BackColor = Color.Gold;
            exit_btn.FlatStyle = FlatStyle.Flat;
            exit_btn.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exit_btn.ForeColor = Color.Red;
            exit_btn.Location = new Point(110, 276);
            exit_btn.Name = "exit_btn";
            exit_btn.Size = new Size(75, 23);
            exit_btn.TabIndex = 6;
            exit_btn.Text = "Exit";
            exit_btn.UseVisualStyleBackColor = false;
            exit_btn.Click += exit_btn_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(284, 311);
            Controls.Add(exit_btn);
            Controls.Add(reg_btn);
            Controls.Add(nickname_txt);
            Controls.Add(nick);
            Controls.Add(username_txt);
            Controls.Add(usr_lbl);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Register";
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label usr_lbl;
        private TextBox username_txt;
        private Label nick;
        private TextBox nickname_txt;
        private Button reg_btn;
        private Button exit_btn;
    }
}