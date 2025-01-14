namespace IdleBTClicker
{
    partial class LogIn
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
            log = new Label();
            username_lbl = new Label();
            username_txt = new TextBox();
            enter_btn = new Button();
            button2 = new Button();
            exit_btn = new Button();
            SuspendLayout();
            // 
            // log
            // 
            log.AutoSize = true;
            log.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            log.ForeColor = Color.Gold;
            log.Location = new Point(124, 9);
            log.Name = "log";
            log.Size = new Size(61, 21);
            log.TabIndex = 0;
            log.Text = "Log In:";
            // 
            // username_lbl
            // 
            username_lbl.AutoSize = true;
            username_lbl.Font = new Font("Ebrima", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            username_lbl.ForeColor = Color.Gold;
            username_lbl.Location = new Point(12, 111);
            username_lbl.Name = "username_lbl";
            username_lbl.Size = new Size(73, 17);
            username_lbl.TabIndex = 1;
            username_lbl.Text = "Username:";
            // 
            // username_txt
            // 
            username_txt.Anchor = AnchorStyles.Top;
            username_txt.Location = new Point(95, 110);
            username_txt.Name = "username_txt";
            username_txt.Size = new Size(120, 23);
            username_txt.TabIndex = 2;
            username_txt.TextAlign = HorizontalAlignment.Center;
            // 
            // enter_btn
            // 
            enter_btn.BackColor = Color.Green;
            enter_btn.FlatStyle = FlatStyle.Flat;
            enter_btn.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            enter_btn.ForeColor = Color.Gold;
            enter_btn.Location = new Point(115, 140);
            enter_btn.Name = "enter_btn";
            enter_btn.Size = new Size(80, 30);
            enter_btn.TabIndex = 3;
            enter_btn.Text = "Enter";
            enter_btn.UseVisualStyleBackColor = false;
            enter_btn.Click += enter_btn_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Ebrima", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.RoyalBlue;
            button2.Location = new Point(12, 224);
            button2.Name = "button2";
            button2.Size = new Size(80, 25);
            button2.TabIndex = 4;
            button2.Text = "New user";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // exit_btn
            // 
            exit_btn.Font = new Font("Ebrima", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exit_btn.ForeColor = Color.Red;
            exit_btn.Location = new Point(212, 224);
            exit_btn.Name = "exit_btn";
            exit_btn.Size = new Size(80, 25);
            exit_btn.TabIndex = 5;
            exit_btn.Text = "Exit";
            exit_btn.UseVisualStyleBackColor = true;
            exit_btn.Click += exit_btn_Click;
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(304, 261);
            Controls.Add(exit_btn);
            Controls.Add(button2);
            Controls.Add(enter_btn);
            Controls.Add(username_txt);
            Controls.Add(username_lbl);
            Controls.Add(log);
            ForeColor = SystemColors.ActiveCaption;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "LogIn";
            Text = "Log In";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label log;
        private Label username_lbl;
        private TextBox username_txt;
        private Button enter_btn;
        private Button button2;
        private Button exit_btn;
    }
}