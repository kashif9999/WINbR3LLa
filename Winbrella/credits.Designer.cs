namespace Winbrella
{
    partial class credits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(credits));
            this.label1 = new System.Windows.Forms.Label();
            this.linklbltwitter = new System.Windows.Forms.LinkLabel();
            this.lblcreated = new System.Windows.Forms.Label();
            this.lblcredits1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(174, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Credits:";
            // 
            // linklbltwitter
            // 
            this.linklbltwitter.AutoSize = true;
            this.linklbltwitter.Font = new System.Drawing.Font("Calibri", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklbltwitter.ForeColor = System.Drawing.Color.Black;
            this.linklbltwitter.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.linklbltwitter.Location = new System.Drawing.Point(294, 127);
            this.linklbltwitter.Name = "linklbltwitter";
            this.linklbltwitter.Size = new System.Drawing.Size(54, 15);
            this.linklbltwitter.TabIndex = 17;
            this.linklbltwitter.TabStop = true;
            this.linklbltwitter.Text = "@ih8x0r";
            this.linklbltwitter.VisitedLinkColor = System.Drawing.Color.White;
            this.linklbltwitter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklbltwitter_LinkClicked);
            // 
            // lblcreated
            // 
            this.lblcreated.AutoSize = true;
            this.lblcreated.Font = new System.Drawing.Font("Calibri", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcreated.ForeColor = System.Drawing.Color.Black;
            this.lblcreated.Location = new System.Drawing.Point(183, 127);
            this.lblcreated.Name = "lblcreated";
            this.lblcreated.Size = new System.Drawing.Size(112, 15);
            this.lblcreated.TabIndex = 16;
            this.lblcreated.Text = "Created by : ih8x0r";
            // 
            // lblcredits1
            // 
            this.lblcredits1.AutoSize = true;
            this.lblcredits1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcredits1.ForeColor = System.Drawing.Color.Black;
            this.lblcredits1.Location = new System.Drawing.Point(184, 103);
            this.lblcredits1.Name = "lblcredits1";
            this.lblcredits1.Size = new System.Drawing.Size(85, 17);
            this.lblcredits1.TabIndex = 15;
            this.lblcredits1.Text = "W|NbR3LL@";
            this.lblcredits1.Click += new System.EventHandler(this.lblcredits1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Winbrella.Properties.Resources.winbrellacredit;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(175, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(312, 70);
            this.label2.TabIndex = 26;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // credits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(495, 169);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linklbltwitter);
            this.Controls.Add(this.lblcreated);
            this.Controls.Add(this.lblcredits1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "credits";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credits";
            this.Load += new System.EventHandler(this.credits_Load);
            this.Click += new System.EventHandler(this.credits_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linklbltwitter;
        private System.Windows.Forms.Label lblcreated;
        private System.Windows.Forms.Label lblcredits1;
        private System.Windows.Forms.Label label2;
    }
}