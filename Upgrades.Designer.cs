namespace IdleBTClicker
{
    partial class Upgrades
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
            done_btn = new Button();
            money_lbl = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Gold;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(254, 15);
            label1.TabIndex = 0;
            label1.Text = "Purchase V.I.P upgrades to boost your profit!";
            // 
            // done_btn
            // 
            done_btn.BackColor = Color.DarkGreen;
            done_btn.FlatStyle = FlatStyle.Flat;
            done_btn.Font = new Font("Ebrima", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            done_btn.ForeColor = Color.Yellow;
            done_btn.Location = new Point(243, 570);
            done_btn.Name = "done_btn";
            done_btn.Size = new Size(100, 30);
            done_btn.TabIndex = 5;
            done_btn.Text = "Close";
            done_btn.UseVisualStyleBackColor = false;
            done_btn.Click += done_btn_Click;
            // 
            // money_lbl
            // 
            money_lbl.AutoSize = true;
            money_lbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            money_lbl.ForeColor = Color.FromArgb(0, 192, 0);
            money_lbl.Location = new Point(12, 33);
            money_lbl.Name = "money_lbl";
            money_lbl.Size = new Size(39, 15);
            money_lbl.TabIndex = 6;
            money_lbl.Text = "label2";
            // 
            // Upgrades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(584, 611);
            Controls.Add(money_lbl);
            Controls.Add(done_btn);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Upgrades";
            Text = "Upgrades";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button done_btn;
        private Label money_lbl;
    }
}