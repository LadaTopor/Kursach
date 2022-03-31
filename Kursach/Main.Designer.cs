namespace Kursach
{
    partial class Steganography
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bEncode = new System.Windows.Forms.Button();
            this.bDecode = new System.Windows.Forms.Button();
            this.pbPicture = new System.Windows.Forms.PictureBox();
            this.bImport = new System.Windows.Forms.Button();
            this.tbText = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // bEncode
            // 
            this.bEncode.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bEncode.Location = new System.Drawing.Point(103, 342);
            this.bEncode.Name = "bEncode";
            this.bEncode.Size = new System.Drawing.Size(92, 38);
            this.bEncode.TabIndex = 0;
            this.bEncode.Text = "Encode";
            this.bEncode.UseVisualStyleBackColor = true;
            this.bEncode.Click += new System.EventHandler(this.bEncode_Click);
            // 
            // bDecode
            // 
            this.bDecode.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bDecode.Location = new System.Drawing.Point(583, 342);
            this.bDecode.Name = "bDecode";
            this.bDecode.Size = new System.Drawing.Size(88, 38);
            this.bDecode.TabIndex = 1;
            this.bDecode.Text = "Decode";
            this.bDecode.UseVisualStyleBackColor = true;
            this.bDecode.Click += new System.EventHandler(this.bDecode_Click);
            // 
            // pbPicture
            // 
            this.pbPicture.Location = new System.Drawing.Point(209, 37);
            this.pbPicture.Name = "pbPicture";
            this.pbPicture.Size = new System.Drawing.Size(371, 281);
            this.pbPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPicture.TabIndex = 3;
            this.pbPicture.TabStop = false;
            // 
            // bImport
            // 
            this.bImport.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bImport.Location = new System.Drawing.Point(327, 342);
            this.bImport.Name = "bImport";
            this.bImport.Size = new System.Drawing.Size(134, 38);
            this.bImport.TabIndex = 4;
            this.bImport.Text = "Import photo";
            this.bImport.UseVisualStyleBackColor = true;
            this.bImport.Click += new System.EventHandler(this.bImport_Click);
            // 
            // tbText
            // 
            this.tbText.Location = new System.Drawing.Point(170, 393);
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(446, 128);
            this.tbText.TabIndex = 5;
            this.tbText.Text = "";
            // 
            // Steganography
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 533);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.bImport);
            this.Controls.Add(this.pbPicture);
            this.Controls.Add(this.bDecode);
            this.Controls.Add(this.bEncode);
            this.Name = "Steganography";
            this.Text = "Steganography";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Button bEncode;
        private Button bDecode;
        private PictureBox pbPicture;
        private Button bImport;
        private RichTextBox tbText;
    }
}