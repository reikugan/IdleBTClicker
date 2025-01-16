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
            main_btn = new Button();
            clicklvl = new Button();
            assetbox = new GroupBox();
            panel = new Panel();
            viptab = new Button();
            layout_table = new TableLayoutPanel();
            t_layout2 = new TableLayoutPanel();
            assetbox.SuspendLayout();
            layout_table.SuspendLayout();
            SuspendLayout();
            // 
            // main_btn
            // 
            main_btn.BackColor = Color.Transparent;
            main_btn.BackgroundImageLayout = ImageLayout.Zoom;
            main_btn.CausesValidation = false;
            main_btn.Dock = DockStyle.Fill;
            main_btn.FlatAppearance.BorderSize = 0;
            main_btn.FlatStyle = FlatStyle.Flat;
            main_btn.Location = new Point(119, 59);
            main_btn.Name = "main_btn";
            main_btn.Size = new Size(344, 255);
            main_btn.TabIndex = 1;
            main_btn.Text = " ";
            main_btn.UseVisualStyleBackColor = false;
            main_btn.Click += main_btn_Click;
            // 
            // clicklvl
            // 
            clicklvl.BackColor = Color.Transparent;
            clicklvl.Dock = DockStyle.Fill;
            clicklvl.FlatStyle = FlatStyle.Popup;
            clicklvl.Font = new Font("Bernard MT Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clicklvl.ForeColor = Color.Cyan;
            clicklvl.Image = Properties.Resources.lvlupbtn;
            clicklvl.Location = new Point(469, 320);
            clicklvl.Name = "clicklvl";
            clicklvl.Size = new Size(112, 51);
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
            panel.Anchor = AnchorStyles.Top;
            panel.AutoScroll = true;
            panel.Location = new Point(6, 22);
            panel.Name = "panel";
            panel.Size = new Size(548, 291);
            panel.TabIndex = 0;
            // 
            // viptab
            // 
            viptab.BackColor = Color.Transparent;
            viptab.Dock = DockStyle.Fill;
            viptab.FlatStyle = FlatStyle.Popup;
            viptab.Font = new Font("Algerian", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viptab.ForeColor = Color.DarkOrange;
            viptab.Image = Properties.Resources.vipbtn2;
            viptab.Location = new Point(466, 0);
            viptab.Margin = new Padding(0);
            viptab.Name = "viptab";
            viptab.Size = new Size(118, 56);
            viptab.TabIndex = 12;
            viptab.UseVisualStyleBackColor = false;
            viptab.Click += viptab_Click;
            // 
            // layout_table
            // 
            layout_table.AccessibleName = "tablepaneltop";
            layout_table.BackgroundImage = Properties.Resources._27;
            layout_table.ColumnCount = 3;
            layout_table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            layout_table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            layout_table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            layout_table.Controls.Add(main_btn, 1, 1);
            layout_table.Controls.Add(viptab, 2, 0);
            layout_table.Controls.Add(clicklvl, 2, 2);
            layout_table.Controls.Add(t_layout2, 1, 0);
            layout_table.Dock = DockStyle.Top;
            layout_table.Location = new Point(0, 0);
            layout_table.Name = "layout_table";
            layout_table.RowCount = 3;
            layout_table.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            layout_table.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            layout_table.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            layout_table.Size = new Size(584, 374);
            layout_table.TabIndex = 13;
            // 
            // t_layout2
            // 
            t_layout2.BackColor = Color.Black;
            t_layout2.ColumnCount = 1;
            t_layout2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            t_layout2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            t_layout2.Dock = DockStyle.Fill;
            t_layout2.Location = new Point(119, 3);
            t_layout2.Name = "t_layout2";
            t_layout2.RowCount = 2;
            t_layout2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            t_layout2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            t_layout2.Size = new Size(344, 50);
            t_layout2.TabIndex = 13;
            // 
            // Test
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(584, 711);
            Controls.Add(layout_table);
            Controls.Add(assetbox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Test";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Idle Crypto Clicker";
            assetbox.ResumeLayout(false);
            layout_table.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button main_btn;
        private Button clicklvl;
        private GroupBox assetbox;
        private Button viptab;
        private TableLayoutPanel layout_table;
        private TableLayoutPanel t_layout2;
        public Panel panel;
    }
}