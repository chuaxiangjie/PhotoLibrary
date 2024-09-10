namespace ImageUploaderTool
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            lblFilePath = new Label();
            btnBrowse = new Button();
            button2 = new Button();
            openFileDialog1 = new OpenFileDialog();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 36);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 0;
            label1.Text = "File Path:";
            // 
            // lblFilePath
            // 
            lblFilePath.AutoSize = true;
            lblFilePath.Location = new Point(122, 38);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(0, 20);
            lblFilePath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(35, 86);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(138, 29);
            btnBrowse.TabIndex = 2;
            btnBrowse.Text = "Browse Image";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(281, 198);
            button2.Name = "button2";
            button2.Size = new Size(215, 154);
            button2.TabIndex = 3;
            button2.Text = "Upload";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(btnBrowse);
            Controls.Add(lblFilePath);
            Controls.Add(label1);
            Name = "Form1";
            Text = "ImageUploader";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblFilePath;
        private Button btnBrowse;
        private Button button2;
        private OpenFileDialog openFileDialog1;
    }
}
