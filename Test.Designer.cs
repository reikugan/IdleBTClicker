namespace IdleBTClicker
{
    partial class Test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Test));
            main_btn = new Button();
            clicklvl = new Button();
            assetbox = new GroupBox();
            panel = new Panel();
            db_test = new Button();
            viptab = new Button();
            assetbox.SuspendLayout();
            SuspendLayout();
            // 
            // main_btn
            // 
            main_btn.BackColor = Color.Transparent;
            main_btn.BackgroundImage = (Image)resources.GetObject("main_btn.BackgroundImage");
            main_btn.BackgroundImageLayout = ImageLayout.Zoom;
            main_btn.CausesValidation = false;
            main_btn.FlatAppearance.BorderSize = 0;
            main_btn.FlatStyle = FlatStyle.Flat;
            main_btn.Location = new Point(152, 43);
            main_btn.Name = "main_btn";
            main_btn.Size = new Size(275, 275);
            main_btn.TabIndex = 1;
            main_btn.Text = " ";
            main_btn.UseVisualStyleBackColor = false;
            main_btn.Click += main_btn_Click;
            // 
            // clicklvl
            // 
            clicklvl.BackColor = Color.Gold;
            clicklvl.Font = new Font("Bernard MT Condensed", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clicklvl.ForeColor = Color.Green;
            clicklvl.Location = new Point(502, 299);
            clicklvl.Name = "clicklvl";
            clicklvl.Size = new Size(70, 50);
            clicklvl.TabIndex = 7;
            clicklvl.Text = "Level Up";
            clicklvl.UseVisualStyleBackColor = false;
            clicklvl.Click += clicklvl_Click;
            // 
            // assetbox
            // 
            assetbox.Controls.Add(panel);
            assetbox.Font = new Font("Ebrima", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            assetbox.ForeColor = Color.Gold;
            assetbox.Location = new Point(12, 380);
            assetbox.Name = "assetbox";
            assetbox.Size = new Size(560, 319);
            assetbox.TabIndex = 9;
            assetbox.TabStop = false;
            assetbox.Text = "Assets";
            // 
            // panel
            // 
            panel.AutoScroll = true;
            panel.Location = new Point(6, 22);
            panel.Name = "panel";
            panel.Size = new Size(548, 291);
            panel.TabIndex = 0;
            // 
            // db_test
            // 
            db_test.BackColor = Color.SpringGreen;
            db_test.Location = new Point(18, 268);
            db_test.Name = "db_test";
            db_test.Size = new Size(75, 68);
            db_test.TabIndex = 11;
            db_test.Text = "DB coin retrieve test";
            db_test.UseVisualStyleBackColor = false;
            db_test.Click += db_test_Click;
            // 
            // viptab
            // 
            viptab.BackColor = Color.DarkGreen;
            viptab.FlatStyle = FlatStyle.Flat;
            viptab.Font = new Font("Algerian", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viptab.ForeColor = Color.Gold;
            viptab.Location = new Point(502, 12);
            viptab.Margin = new Padding(0);
            viptab.Name = "viptab";
            viptab.Size = new Size(70, 60);
            viptab.TabIndex = 12;
            viptab.Text = "VIP";
            viptab.UseVisualStyleBackColor = false;
            viptab.Click += viptab_Click;
            // 
            // Test
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(584, 711);
            Controls.Add(viptab);
            Controls.Add(db_test);
            Controls.Add(assetbox);
            Controls.Add(clicklvl);
            Controls.Add(main_btn);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Test";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Idle Crypto Clicker";
            assetbox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button main_btn;
        private Button clicklvl;
        private GroupBox assetbox;
        private Button db_test;
        private Button viptab;
        public static Panel panel;
    }
}