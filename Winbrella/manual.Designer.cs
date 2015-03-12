namespace Winbrella
{
    partial class manual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(manual));
            this.btnok = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.cbmodel = new System.Windows.Forms.ComboBox();
            this.lblmodel = new System.Windows.Forms.Label();
            this.cbdevice = new System.Windows.Forms.ComboBox();
            this.lbldevice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnok
            // 
            this.btnok.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnok.Location = new System.Drawing.Point(209, 86);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 25);
            this.btnok.TabIndex = 0;
            this.btnok.Text = "OK";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // btncancel
            // 
            this.btncancel.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.Location = new System.Drawing.Point(128, 86);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 25);
            this.btncancel.TabIndex = 1;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // cbmodel
            // 
            this.cbmodel.BackColor = System.Drawing.Color.White;
            this.cbmodel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmodel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbmodel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.cbmodel.ForeColor = System.Drawing.Color.Black;
            this.cbmodel.FormattingEnabled = true;
            this.cbmodel.Location = new System.Drawing.Point(136, 57);
            this.cbmodel.Name = "cbmodel";
            this.cbmodel.Size = new System.Drawing.Size(148, 23);
            this.cbmodel.TabIndex = 6;
            this.cbmodel.SelectedIndexChanged += new System.EventHandler(this.cbmodel_SelectedIndexChanged);
            // 
            // lblmodel
            // 
            this.lblmodel.AutoSize = true;
            this.lblmodel.Font = new System.Drawing.Font("Calibri", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmodel.ForeColor = System.Drawing.Color.Black;
            this.lblmodel.Location = new System.Drawing.Point(149, 39);
            this.lblmodel.Name = "lblmodel";
            this.lblmodel.Size = new System.Drawing.Size(124, 17);
            this.lblmodel.TabIndex = 7;
            this.lblmodel.Text = "Select Device Model";
            // 
            // cbdevice
            // 
            this.cbdevice.BackColor = System.Drawing.Color.White;
            this.cbdevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbdevice.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbdevice.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbdevice.ForeColor = System.Drawing.Color.Black;
            this.cbdevice.FormattingEnabled = true;
            this.cbdevice.Items.AddRange(new object[] {
            "iPhone",
            "iPod",
            "iPad"});
            this.cbdevice.Location = new System.Drawing.Point(10, 57);
            this.cbdevice.Name = "cbdevice";
            this.cbdevice.Size = new System.Drawing.Size(120, 23);
            this.cbdevice.TabIndex = 4;
            this.cbdevice.SelectedIndexChanged += new System.EventHandler(this.cbdevice_SelectedIndexChanged);
            // 
            // lbldevice
            // 
            this.lbldevice.AutoSize = true;
            this.lbldevice.Font = new System.Drawing.Font("Calibri", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldevice.ForeColor = System.Drawing.Color.Black;
            this.lbldevice.Location = new System.Drawing.Point(13, 39);
            this.lbldevice.Name = "lbldevice";
            this.lbldevice.Size = new System.Drawing.Size(117, 17);
            this.lbldevice.TabIndex = 5;
            this.lbldevice.Text = "Select your iDevice";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Calibri", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "  Select the Connected iDevice and Model   ";
            // 
            // manual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 122);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbmodel);
            this.Controls.Add(this.lblmodel);
            this.Controls.Add(this.cbdevice);
            this.Controls.Add(this.lbldevice);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnok);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "manual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select iDevice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.ComboBox cbmodel;
        private System.Windows.Forms.Label lblmodel;
        private System.Windows.Forms.ComboBox cbdevice;
        private System.Windows.Forms.Label lbldevice;
        private System.Windows.Forms.Label label1;
    }
}