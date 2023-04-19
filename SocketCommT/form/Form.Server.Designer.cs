namespace SocketCommT.form
{
    partial class FormServer
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
            this.loglabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bexit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loglabel
            // 
            this.loglabel.AutoSize = true;
            this.loglabel.Location = new System.Drawing.Point(0, 0);
            this.loglabel.Name = "loglabel";
            this.loglabel.Size = new System.Drawing.Size(28, 13);
            this.loglabel.TabIndex = 0;
            this.loglabel.Text = "Log:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 16);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(268, 71);
            this.textBox1.TabIndex = 1;
            // 
            // bexit
            // 
            this.bexit.Location = new System.Drawing.Point(3, 93);
            this.bexit.Name = "bexit";
            this.bexit.Size = new System.Drawing.Size(75, 23);
            this.bexit.TabIndex = 2;
            this.bexit.Text = "Exit";
            this.bexit.UseVisualStyleBackColor = true;
            this.bexit.Click += new System.EventHandler(this.bexit_Click);
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 121);
            this.Controls.Add(this.bexit);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.loglabel);
            this.Name = "FormServer";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loglabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bexit;
    }
}