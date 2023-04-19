namespace SocketCommT
{
    partial class Main
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
            this.bclient = new System.Windows.Forms.Button();
            this.bserver = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bclient
            // 
            this.bclient.Location = new System.Drawing.Point(131, 12);
            this.bclient.Name = "bclient";
            this.bclient.Size = new System.Drawing.Size(112, 35);
            this.bclient.TabIndex = 3;
            this.bclient.Text = "Client";
            this.bclient.UseVisualStyleBackColor = true;
            this.bclient.Click += new System.EventHandler(this.bclient_Click);
            // 
            // bserver
            // 
            this.bserver.Location = new System.Drawing.Point(13, 12);
            this.bserver.Name = "bserver";
            this.bserver.Size = new System.Drawing.Size(112, 35);
            this.bserver.TabIndex = 2;
            this.bserver.Text = "Server";
            this.bserver.UseVisualStyleBackColor = true;
            this.bserver.Click += new System.EventHandler(this.bserver_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(9, 54);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(28, 13);
            this.label.TabIndex = 4;
            this.label.Text = "Log:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 70);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(231, 149);
            this.textBox1.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 231);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.bclient);
            this.Controls.Add(this.bserver);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bclient;
        private System.Windows.Forms.Button bserver;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox textBox1;
    }
}

