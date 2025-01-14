namespace IdleBTClicker
{
    partial class Imageupload
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
            select_btn = new Button();
            openfile = new OpenFileDialog();
            txtbox = new TextBox();
            label1 = new Label();
            upld = new Button();
            SuspendLayout();
            // 
            // select_btn
            // 
            select_btn.Location = new Point(45, 72);
            select_btn.Name = "select_btn";
            select_btn.Size = new Size(75, 23);
            select_btn.TabIndex = 0;
            select_btn.Text = "Select";
            select_btn.UseVisualStyleBackColor = true;
            select_btn.Click += select_btn_Click;
            // 
            // openfile
            // 
            openfile.FileName = "openFileDialog1";
            // 
            // txtbox
            // 
            txtbox.Location = new Point(45, 131);
            txtbox.Name = "txtbox";
            txtbox.Size = new Size(100, 23);
            txtbox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 98);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // upld
            // 
            upld.Location = new Point(114, 205);
            upld.Name = "upld";
            upld.Size = new Size(78, 38);
            upld.TabIndex = 3;
            upld.Text = "Upload";
            upld.UseVisualStyleBackColor = true;
            upld.Click += upld_Click;
            // 
            // Imageupload
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(305, 255);
            Controls.Add(upld);
            Controls.Add(label1);
            Controls.Add(txtbox);
            Controls.Add(select_btn);
            Name = "Imageupload";
            Text = "Imageupload";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button select_btn;
        private OpenFileDialog openfile;
        private TextBox txtbox;
        private Label label1;
        private Button upld;
    }
}