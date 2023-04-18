namespace SocketCommT.form
{
    partial class client
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
            this.bserver = new System.Windows.Forms.Button();
            this.bclient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bserver
            // 
            this.bserver.Location = new System.Drawing.Point(27, 53);
            this.bserver.Name = "bserver";
            this.bserver.Size = new System.Drawing.Size(112, 35);
            this.bserver.TabIndex = 0;
            this.bserver.Text = "Server";
            this.bserver.UseVisualStyleBackColor = true;
            // 
            // bclient
            // 
            this.bclient.Location = new System.Drawing.Point(215, 53);
            this.bclient.Name = "bclient";
            this.bclient.Size = new System.Drawing.Size(112, 35);
            this.bclient.TabIndex = 1;
            this.bclient.Text = "Client";
            this.bclient.UseVisualStyleBackColor = true;
            // 
            // client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 283);
            this.Controls.Add(this.bclient);
            this.Controls.Add(this.bserver);
            this.Name = "client";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bserver;
        private System.Windows.Forms.Button bclient;
    }
}