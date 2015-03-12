namespace Winbrella
{
    partial class winbrella
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(winbrella));
            this.Statusbotton = new System.Windows.Forms.StatusStrip();
            this.toolstripconnectinfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolstripinternet = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusblob = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstcydiablobs = new System.Windows.Forms.ListBox();
            this.devicecontainer = new System.Windows.Forms.ListView();
            this.gbdevinfo = new System.Windows.Forms.GroupBox();
            this.btnexitrecovery = new System.Windows.Forms.Button();
            this.btnrecovery = new System.Windows.Forms.Button();
            this.txtbuildver = new System.Windows.Forms.TextBox();
            this.lbliosbuild = new System.Windows.Forms.Label();
            this.lblchipidhex = new System.Windows.Forms.Label();
            this.txtchipidhex = new System.Windows.Forms.TextBox();
            this.lblcydiadown = new System.Windows.Forms.Label();
            this.lblChipIDdec = new System.Windows.Forms.Label();
            this.txtChipid = new System.Windows.Forms.TextBox();
            this.lblboarmodel = new System.Windows.Forms.Label();
            this.btncheck = new System.Windows.Forms.Button();
            this.lblmodelid = new System.Windows.Forms.Label();
            this.txtboardmodel = new System.Windows.Forms.TextBox();
            this.txtimei = new System.Windows.Forms.TextBox();
            this.lblimei = new System.Windows.Forms.Label();
            this.txtserialno = new System.Windows.Forms.TextBox();
            this.lblserial = new System.Windows.Forms.Label();
            this.txtecidhex = new System.Windows.Forms.TextBox();
            this.lblecidhex = new System.Windows.Forms.Label();
            this.txteciddec = new System.Windows.Forms.TextBox();
            this.lbleciddec = new System.Windows.Forms.Label();
            this.txtbbversion = new System.Windows.Forms.TextBox();
            this.lblbaseband = new System.Windows.Forms.Label();
            this.txtversion = new System.Windows.Forms.TextBox();
            this.lblversion = new System.Windows.Forms.Label();
            this.txtdevicemodel = new System.Windows.Forms.TextBox();
            this.lbldeviceinformation = new System.Windows.Forms.Label();
            this.lblcydiaheader = new System.Windows.Forms.Label();
            this.lblifaithheader = new System.Windows.Forms.Label();
            this.lstifaithblobs = new System.Windows.Forms.ListBox();
            this.lblappleheader = new System.Windows.Forms.Label();
            this.lstappleblobs = new System.Windows.Forms.ListBox();
            this.lblbetashsh = new System.Windows.Forms.Label();
            this.lstbetaapple = new System.Windows.Forms.ListBox();
            this.savefolder = new System.Windows.Forms.FolderBrowserDialog();
            this.btncydiadownload = new System.Windows.Forms.Button();
            this.btnifaithdownload = new System.Windows.Forms.Button();
            this.btnappledownload = new System.Windows.Forms.Button();
            this.btnbetaapledownload = new System.Windows.Forms.Button();
            this.shshinfo = new System.Windows.Forms.GroupBox();
            this.Statusbotton.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gbdevinfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // Statusbotton
            // 
            this.Statusbotton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Statusbotton.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Statusbotton.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.Statusbotton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripconnectinfo,
            this.toolstripinternet,
            this.toolStripStatusblob});
            this.Statusbotton.Location = new System.Drawing.Point(0, 566);
            this.Statusbotton.Name = "Statusbotton";
            this.Statusbotton.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Statusbotton.Size = new System.Drawing.Size(576, 22);
            this.Statusbotton.SizingGrip = false;
            this.Statusbotton.TabIndex = 0;
            this.Statusbotton.Text = "statusStrip1";
            // 
            // toolstripconnectinfo
            // 
            this.toolstripconnectinfo.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolstripconnectinfo.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.toolstripconnectinfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolstripconnectinfo.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolstripconnectinfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolstripconnectinfo.Name = "toolstripconnectinfo";
            this.toolstripconnectinfo.Size = new System.Drawing.Size(4, 17);
            this.toolstripconnectinfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolstripinternet
            // 
            this.toolstripinternet.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolstripinternet.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.toolstripinternet.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolstripinternet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolstripinternet.Name = "toolstripinternet";
            this.toolstripinternet.Size = new System.Drawing.Size(4, 17);
            this.toolstripinternet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusblob
            // 
            this.toolStripStatusblob.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusblob.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.toolStripStatusblob.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusblob.Name = "toolStripStatusblob";
            this.toolStripStatusblob.Size = new System.Drawing.Size(4, 17);
            this.toolStripStatusblob.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.menuStrip1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(576, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creditsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.creditsToolStripMenuItem.Text = "Credits";
            this.creditsToolStripMenuItem.Click += new System.EventHandler(this.creditsToolStripMenuItem_Click);
            // 
            // lstcydiablobs
            // 
            this.lstcydiablobs.BackColor = System.Drawing.Color.Silver;
            this.lstcydiablobs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstcydiablobs.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstcydiablobs.FormattingEnabled = true;
            this.lstcydiablobs.ItemHeight = 15;
            this.lstcydiablobs.Location = new System.Drawing.Point(22, 338);
            this.lstcydiablobs.Name = "lstcydiablobs";
            this.lstcydiablobs.Size = new System.Drawing.Size(120, 197);
            this.lstcydiablobs.TabIndex = 3;
            // 
            // devicecontainer
            // 
            this.devicecontainer.BackColor = System.Drawing.SystemColors.Control;
            this.devicecontainer.Enabled = false;
            this.devicecontainer.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.devicecontainer.Location = new System.Drawing.Point(428, 46);
            this.devicecontainer.Name = "devicecontainer";
            this.devicecontainer.Size = new System.Drawing.Size(104, 25);
            this.devicecontainer.TabIndex = 1;
            this.devicecontainer.UseCompatibleStateImageBehavior = false;
            this.devicecontainer.View = System.Windows.Forms.View.List;
            // 
            // gbdevinfo
            // 
            this.gbdevinfo.Controls.Add(this.btnexitrecovery);
            this.gbdevinfo.Controls.Add(this.btnrecovery);
            this.gbdevinfo.Controls.Add(this.devicecontainer);
            this.gbdevinfo.Controls.Add(this.txtbuildver);
            this.gbdevinfo.Controls.Add(this.lbliosbuild);
            this.gbdevinfo.Controls.Add(this.lblchipidhex);
            this.gbdevinfo.Controls.Add(this.txtchipidhex);
            this.gbdevinfo.Controls.Add(this.lblcydiadown);
            this.gbdevinfo.Controls.Add(this.lblChipIDdec);
            this.gbdevinfo.Controls.Add(this.txtChipid);
            this.gbdevinfo.Controls.Add(this.lblboarmodel);
            this.gbdevinfo.Controls.Add(this.btncheck);
            this.gbdevinfo.Controls.Add(this.lblmodelid);
            this.gbdevinfo.Controls.Add(this.txtboardmodel);
            this.gbdevinfo.Controls.Add(this.txtimei);
            this.gbdevinfo.Controls.Add(this.lblimei);
            this.gbdevinfo.Controls.Add(this.txtserialno);
            this.gbdevinfo.Controls.Add(this.lblserial);
            this.gbdevinfo.Controls.Add(this.txtecidhex);
            this.gbdevinfo.Controls.Add(this.lblecidhex);
            this.gbdevinfo.Controls.Add(this.txteciddec);
            this.gbdevinfo.Controls.Add(this.lbleciddec);
            this.gbdevinfo.Controls.Add(this.txtbbversion);
            this.gbdevinfo.Controls.Add(this.lblbaseband);
            this.gbdevinfo.Controls.Add(this.txtversion);
            this.gbdevinfo.Controls.Add(this.lblversion);
            this.gbdevinfo.Controls.Add(this.txtdevicemodel);
            this.gbdevinfo.Controls.Add(this.lbldeviceinformation);
            this.gbdevinfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbdevinfo.Font = new System.Drawing.Font("Calibri", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbdevinfo.ForeColor = System.Drawing.Color.Black;
            this.gbdevinfo.Location = new System.Drawing.Point(12, 31);
            this.gbdevinfo.Name = "gbdevinfo";
            this.gbdevinfo.Size = new System.Drawing.Size(554, 264);
            this.gbdevinfo.TabIndex = 2;
            this.gbdevinfo.TabStop = false;
            this.gbdevinfo.Text = "iDevice Information";
            // 
            // btnexitrecovery
            // 
            this.btnexitrecovery.Font = new System.Drawing.Font("Calibri", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexitrecovery.Location = new System.Drawing.Point(264, 233);
            this.btnexitrecovery.Name = "btnexitrecovery";
            this.btnexitrecovery.Size = new System.Drawing.Size(107, 25);
            this.btnexitrecovery.TabIndex = 27;
            this.btnexitrecovery.Text = "Exit Recovery";
            this.btnexitrecovery.UseVisualStyleBackColor = true;
            this.btnexitrecovery.Click += new System.EventHandler(this.btnexitrecovery_Click);
            // 
            // btnrecovery
            // 
            this.btnrecovery.Font = new System.Drawing.Font("Calibri", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrecovery.Location = new System.Drawing.Point(151, 233);
            this.btnrecovery.Name = "btnrecovery";
            this.btnrecovery.Size = new System.Drawing.Size(107, 25);
            this.btnrecovery.TabIndex = 26;
            this.btnrecovery.Text = "Enter Recovery";
            this.btnrecovery.UseVisualStyleBackColor = true;
            this.btnrecovery.Click += new System.EventHandler(this.btnrecovery_Click);
            // 
            // txtbuildver
            // 
            this.txtbuildver.BackColor = System.Drawing.Color.Gainsboro;
            this.txtbuildver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbuildver.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbuildver.Location = new System.Drawing.Point(387, 77);
            this.txtbuildver.Name = "txtbuildver";
            this.txtbuildver.ReadOnly = true;
            this.txtbuildver.Size = new System.Drawing.Size(144, 25);
            this.txtbuildver.TabIndex = 25;
            // 
            // lbliosbuild
            // 
            this.lbliosbuild.AutoSize = true;
            this.lbliosbuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbliosbuild.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbliosbuild.ForeColor = System.Drawing.Color.Black;
            this.lbliosbuild.Location = new System.Drawing.Point(313, 81);
            this.lbliosbuild.Name = "lbliosbuild";
            this.lbliosbuild.Size = new System.Drawing.Size(68, 18);
            this.lbliosbuild.TabIndex = 24;
            this.lbliosbuild.Text = "iOS Build:";
            // 
            // lblchipidhex
            // 
            this.lblchipidhex.AutoSize = true;
            this.lblchipidhex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblchipidhex.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblchipidhex.ForeColor = System.Drawing.Color.Black;
            this.lblchipidhex.Location = new System.Drawing.Point(448, 25);
            this.lblchipidhex.Name = "lblchipidhex";
            this.lblchipidhex.Size = new System.Drawing.Size(77, 18);
            this.lblchipidhex.TabIndex = 23;
            this.lblchipidhex.Text = "ChipId-Hex";
            this.lblchipidhex.Visible = false;
            // 
            // txtchipidhex
            // 
            this.txtchipidhex.BackColor = System.Drawing.Color.Gainsboro;
            this.txtchipidhex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtchipidhex.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtchipidhex.Location = new System.Drawing.Point(448, 46);
            this.txtchipidhex.Name = "txtchipidhex";
            this.txtchipidhex.ReadOnly = true;
            this.txtchipidhex.Size = new System.Drawing.Size(83, 25);
            this.txtchipidhex.TabIndex = 22;
            this.txtchipidhex.Visible = false;
            // 
            // lblcydiadown
            // 
            this.lblcydiadown.AutoSize = true;
            this.lblcydiadown.Location = new System.Drawing.Point(11, 239);
            this.lblcydiadown.Name = "lblcydiadown";
            this.lblcydiadown.Size = new System.Drawing.Size(0, 18);
            this.lblcydiadown.TabIndex = 18;
            // 
            // lblChipIDdec
            // 
            this.lblChipIDdec.AutoSize = true;
            this.lblChipIDdec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblChipIDdec.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChipIDdec.ForeColor = System.Drawing.Color.Black;
            this.lblChipIDdec.Location = new System.Drawing.Point(339, 25);
            this.lblChipIDdec.Name = "lblChipIDdec";
            this.lblChipIDdec.Size = new System.Drawing.Size(76, 18);
            this.lblChipIDdec.TabIndex = 19;
            this.lblChipIDdec.Text = "ChipId-Dec";
            // 
            // txtChipid
            // 
            this.txtChipid.BackColor = System.Drawing.Color.Gainsboro;
            this.txtChipid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChipid.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChipid.Location = new System.Drawing.Point(339, 46);
            this.txtChipid.Name = "txtChipid";
            this.txtChipid.ReadOnly = true;
            this.txtChipid.Size = new System.Drawing.Size(83, 25);
            this.txtChipid.TabIndex = 18;
            // 
            // lblboarmodel
            // 
            this.lblboarmodel.AutoSize = true;
            this.lblboarmodel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblboarmodel.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblboarmodel.ForeColor = System.Drawing.Color.Black;
            this.lblboarmodel.Location = new System.Drawing.Point(248, 26);
            this.lblboarmodel.Name = "lblboarmodel";
            this.lblboarmodel.Size = new System.Drawing.Size(85, 17);
            this.lblboarmodel.TabIndex = 17;
            this.lblboarmodel.Text = "Board Model";
            // 
            // btncheck
            // 
            this.btncheck.Enabled = false;
            this.btncheck.Font = new System.Drawing.Font("Calibri", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncheck.Location = new System.Drawing.Point(428, 232);
            this.btncheck.Name = "btncheck";
            this.btncheck.Size = new System.Drawing.Size(107, 25);
            this.btncheck.TabIndex = 7;
            this.btncheck.Text = "Check Blobs";
            this.btncheck.UseVisualStyleBackColor = true;
            this.btncheck.Click += new System.EventHandler(this.btncheck_Click);
            // 
            // lblmodelid
            // 
            this.lblmodelid.AutoSize = true;
            this.lblmodelid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblmodelid.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmodelid.ForeColor = System.Drawing.Color.Black;
            this.lblmodelid.Location = new System.Drawing.Point(154, 25);
            this.lblmodelid.Name = "lblmodelid";
            this.lblmodelid.Size = new System.Drawing.Size(65, 18);
            this.lblmodelid.TabIndex = 16;
            this.lblmodelid.Text = "Model ID";
            // 
            // txtboardmodel
            // 
            this.txtboardmodel.BackColor = System.Drawing.Color.Gainsboro;
            this.txtboardmodel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtboardmodel.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtboardmodel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboardmodel.Location = new System.Drawing.Point(250, 46);
            this.txtboardmodel.Name = "txtboardmodel";
            this.txtboardmodel.ReadOnly = true;
            this.txtboardmodel.Size = new System.Drawing.Size(83, 25);
            this.txtboardmodel.TabIndex = 15;
            // 
            // txtimei
            // 
            this.txtimei.BackColor = System.Drawing.Color.Gainsboro;
            this.txtimei.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtimei.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtimei.Location = new System.Drawing.Point(151, 201);
            this.txtimei.Name = "txtimei";
            this.txtimei.ReadOnly = true;
            this.txtimei.Size = new System.Drawing.Size(381, 25);
            this.txtimei.TabIndex = 14;
            // 
            // lblimei
            // 
            this.lblimei.AutoSize = true;
            this.lblimei.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblimei.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblimei.ForeColor = System.Drawing.Color.Black;
            this.lblimei.Location = new System.Drawing.Point(52, 205);
            this.lblimei.Name = "lblimei";
            this.lblimei.Size = new System.Drawing.Size(95, 18);
            this.lblimei.TabIndex = 13;
            this.lblimei.Text = "Device IMEI #:";
            // 
            // txtserialno
            // 
            this.txtserialno.BackColor = System.Drawing.Color.Gainsboro;
            this.txtserialno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtserialno.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtserialno.Location = new System.Drawing.Point(151, 170);
            this.txtserialno.Name = "txtserialno";
            this.txtserialno.ReadOnly = true;
            this.txtserialno.Size = new System.Drawing.Size(381, 25);
            this.txtserialno.TabIndex = 12;
            // 
            // lblserial
            // 
            this.lblserial.AutoSize = true;
            this.lblserial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblserial.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblserial.ForeColor = System.Drawing.Color.Black;
            this.lblserial.Location = new System.Drawing.Point(34, 174);
            this.lblserial.Name = "lblserial";
            this.lblserial.Size = new System.Drawing.Size(113, 18);
            this.lblserial.TabIndex = 11;
            this.lblserial.Text = "Device Serial No:";
            // 
            // txtecidhex
            // 
            this.txtecidhex.BackColor = System.Drawing.Color.Gainsboro;
            this.txtecidhex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtecidhex.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtecidhex.Location = new System.Drawing.Point(387, 139);
            this.txtecidhex.Name = "txtecidhex";
            this.txtecidhex.ReadOnly = true;
            this.txtecidhex.Size = new System.Drawing.Size(144, 25);
            this.txtecidhex.TabIndex = 10;
            // 
            // lblecidhex
            // 
            this.lblecidhex.AutoSize = true;
            this.lblecidhex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblecidhex.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblecidhex.ForeColor = System.Drawing.Color.Black;
            this.lblecidhex.Location = new System.Drawing.Point(304, 143);
            this.lblecidhex.Name = "lblecidhex";
            this.lblecidhex.Size = new System.Drawing.Size(77, 18);
            this.lblecidhex.TabIndex = 9;
            this.lblecidhex.Text = "ECID (Hex):";
            // 
            // txteciddec
            // 
            this.txteciddec.BackColor = System.Drawing.Color.Gainsboro;
            this.txteciddec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txteciddec.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txteciddec.Location = new System.Drawing.Point(151, 139);
            this.txteciddec.Name = "txteciddec";
            this.txteciddec.ReadOnly = true;
            this.txteciddec.Size = new System.Drawing.Size(146, 25);
            this.txteciddec.TabIndex = 8;
            // 
            // lbleciddec
            // 
            this.lbleciddec.AutoSize = true;
            this.lbleciddec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbleciddec.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbleciddec.ForeColor = System.Drawing.Color.Black;
            this.lbleciddec.Location = new System.Drawing.Point(71, 143);
            this.lbleciddec.Name = "lbleciddec";
            this.lbleciddec.Size = new System.Drawing.Size(76, 18);
            this.lbleciddec.TabIndex = 7;
            this.lbleciddec.Text = "ECID (Dec):";
            // 
            // txtbbversion
            // 
            this.txtbbversion.BackColor = System.Drawing.Color.Gainsboro;
            this.txtbbversion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbbversion.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbbversion.Location = new System.Drawing.Point(151, 108);
            this.txtbbversion.Name = "txtbbversion";
            this.txtbbversion.ReadOnly = true;
            this.txtbbversion.Size = new System.Drawing.Size(381, 25);
            this.txtbbversion.TabIndex = 6;
            // 
            // lblbaseband
            // 
            this.lblbaseband.AutoSize = true;
            this.lblbaseband.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblbaseband.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbaseband.ForeColor = System.Drawing.Color.Black;
            this.lblbaseband.Location = new System.Drawing.Point(25, 112);
            this.lblbaseband.Name = "lblbaseband";
            this.lblbaseband.Size = new System.Drawing.Size(122, 18);
            this.lblbaseband.TabIndex = 5;
            this.lblbaseband.Text = "Baseband Version:";
            // 
            // txtversion
            // 
            this.txtversion.BackColor = System.Drawing.Color.Gainsboro;
            this.txtversion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtversion.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtversion.Location = new System.Drawing.Point(151, 77);
            this.txtversion.Name = "txtversion";
            this.txtversion.ReadOnly = true;
            this.txtversion.Size = new System.Drawing.Size(146, 25);
            this.txtversion.TabIndex = 4;
            // 
            // lblversion
            // 
            this.lblversion.AutoSize = true;
            this.lblversion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblversion.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblversion.ForeColor = System.Drawing.Color.Black;
            this.lblversion.Location = new System.Drawing.Point(9, 81);
            this.lblversion.Name = "lblversion";
            this.lblversion.Size = new System.Drawing.Size(140, 18);
            this.lblversion.TabIndex = 3;
            this.lblversion.Text = "Installed iOS Version:";
            // 
            // txtdevicemodel
            // 
            this.txtdevicemodel.BackColor = System.Drawing.Color.Gainsboro;
            this.txtdevicemodel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdevicemodel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdevicemodel.Location = new System.Drawing.Point(151, 46);
            this.txtdevicemodel.Name = "txtdevicemodel";
            this.txtdevicemodel.ReadOnly = true;
            this.txtdevicemodel.Size = new System.Drawing.Size(93, 25);
            this.txtdevicemodel.TabIndex = 2;
            // 
            // lbldeviceinformation
            // 
            this.lbldeviceinformation.AutoSize = true;
            this.lbldeviceinformation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbldeviceinformation.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldeviceinformation.ForeColor = System.Drawing.Color.Black;
            this.lbldeviceinformation.Location = new System.Drawing.Point(18, 48);
            this.lbldeviceinformation.Name = "lbldeviceinformation";
            this.lbldeviceinformation.Size = new System.Drawing.Size(131, 18);
            this.lbldeviceinformation.TabIndex = 1;
            this.lbldeviceinformation.Text = "Device Information:";
            // 
            // lblcydiaheader
            // 
            this.lblcydiaheader.AutoSize = true;
            this.lblcydiaheader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcydiaheader.Location = new System.Drawing.Point(27, 321);
            this.lblcydiaheader.Name = "lblcydiaheader";
            this.lblcydiaheader.Size = new System.Drawing.Size(95, 13);
            this.lblcydiaheader.TabIndex = 4;
            this.lblcydiaheader.Text = "Shsh with Cydia";
            // 
            // lblifaithheader
            // 
            this.lblifaithheader.AutoSize = true;
            this.lblifaithheader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblifaithheader.Location = new System.Drawing.Point(161, 321);
            this.lblifaithheader.Name = "lblifaithheader";
            this.lblifaithheader.Size = new System.Drawing.Size(95, 13);
            this.lblifaithheader.TabIndex = 6;
            this.lblifaithheader.Text = "Shsh with iFaith";
            // 
            // lstifaithblobs
            // 
            this.lstifaithblobs.BackColor = System.Drawing.Color.Silver;
            this.lstifaithblobs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstifaithblobs.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstifaithblobs.FormattingEnabled = true;
            this.lstifaithblobs.ItemHeight = 15;
            this.lstifaithblobs.Location = new System.Drawing.Point(157, 338);
            this.lstifaithblobs.Name = "lstifaithblobs";
            this.lstifaithblobs.Size = new System.Drawing.Size(120, 197);
            this.lstifaithblobs.TabIndex = 5;
            // 
            // lblappleheader
            // 
            this.lblappleheader.AutoSize = true;
            this.lblappleheader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblappleheader.Location = new System.Drawing.Point(292, 321);
            this.lblappleheader.Name = "lblappleheader";
            this.lblappleheader.Size = new System.Drawing.Size(107, 13);
            this.lblappleheader.TabIndex = 8;
            this.lblappleheader.Text = "Latest iOS - Apple";
            // 
            // lstappleblobs
            // 
            this.lstappleblobs.BackColor = System.Drawing.Color.Silver;
            this.lstappleblobs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstappleblobs.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstappleblobs.FormattingEnabled = true;
            this.lstappleblobs.ItemHeight = 15;
            this.lstappleblobs.Location = new System.Drawing.Point(292, 338);
            this.lstappleblobs.Name = "lstappleblobs";
            this.lstappleblobs.Size = new System.Drawing.Size(120, 197);
            this.lstappleblobs.TabIndex = 7;
            // 
            // lblbetashsh
            // 
            this.lblbetashsh.AutoSize = true;
            this.lblbetashsh.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbetashsh.Location = new System.Drawing.Point(431, 321);
            this.lblbetashsh.Name = "lblbetashsh";
            this.lblbetashsh.Size = new System.Drawing.Size(97, 13);
            this.lblbetashsh.TabIndex = 10;
            this.lblbetashsh.Text = "Beta iOS - Apple";
            // 
            // lstbetaapple
            // 
            this.lstbetaapple.BackColor = System.Drawing.Color.Silver;
            this.lstbetaapple.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstbetaapple.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstbetaapple.FormattingEnabled = true;
            this.lstbetaapple.ItemHeight = 15;
            this.lstbetaapple.Location = new System.Drawing.Point(427, 337);
            this.lstbetaapple.Name = "lstbetaapple";
            this.lstbetaapple.Size = new System.Drawing.Size(120, 197);
            this.lstbetaapple.TabIndex = 9;
            // 
            // btncydiadownload
            // 
            this.btncydiadownload.Enabled = false;
            this.btncydiadownload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btncydiadownload.Font = new System.Drawing.Font("Calibri", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncydiadownload.Location = new System.Drawing.Point(22, 540);
            this.btncydiadownload.Name = "btncydiadownload";
            this.btncydiadownload.Size = new System.Drawing.Size(120, 23);
            this.btncydiadownload.TabIndex = 11;
            this.btncydiadownload.Text = "Download from Cydia";
            this.btncydiadownload.UseVisualStyleBackColor = true;
            this.btncydiadownload.Click += new System.EventHandler(this.btncydiadownload_Click);
            // 
            // btnifaithdownload
            // 
            this.btnifaithdownload.Enabled = false;
            this.btnifaithdownload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnifaithdownload.Font = new System.Drawing.Font("Calibri", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnifaithdownload.Location = new System.Drawing.Point(157, 540);
            this.btnifaithdownload.Name = "btnifaithdownload";
            this.btnifaithdownload.Size = new System.Drawing.Size(120, 23);
            this.btnifaithdownload.TabIndex = 12;
            this.btnifaithdownload.Text = "Download from iFaith";
            this.btnifaithdownload.UseVisualStyleBackColor = true;
            this.btnifaithdownload.Click += new System.EventHandler(this.btnifaithdownload_Click);
            // 
            // btnappledownload
            // 
            this.btnappledownload.Enabled = false;
            this.btnappledownload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnappledownload.Font = new System.Drawing.Font("Calibri", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnappledownload.Location = new System.Drawing.Point(292, 540);
            this.btnappledownload.Name = "btnappledownload";
            this.btnappledownload.Size = new System.Drawing.Size(120, 23);
            this.btnappledownload.TabIndex = 13;
            this.btnappledownload.Text = "Download from Apple";
            this.btnappledownload.UseVisualStyleBackColor = true;
            this.btnappledownload.Click += new System.EventHandler(this.btnappledownload_Click);
            // 
            // btnbetaapledownload
            // 
            this.btnbetaapledownload.Enabled = false;
            this.btnbetaapledownload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnbetaapledownload.Font = new System.Drawing.Font("Calibri", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbetaapledownload.Location = new System.Drawing.Point(427, 540);
            this.btnbetaapledownload.Name = "btnbetaapledownload";
            this.btnbetaapledownload.Size = new System.Drawing.Size(120, 23);
            this.btnbetaapledownload.TabIndex = 14;
            this.btnbetaapledownload.Text = "Apple Beta Download";
            this.btnbetaapledownload.UseVisualStyleBackColor = true;
            this.btnbetaapledownload.Click += new System.EventHandler(this.btnbetaapledownload_Click);
            // 
            // shshinfo
            // 
            this.shshinfo.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shshinfo.Location = new System.Drawing.Point(12, 301);
            this.shshinfo.Name = "shshinfo";
            this.shshinfo.Size = new System.Drawing.Size(554, 271);
            this.shshinfo.TabIndex = 16;
            this.shshinfo.TabStop = false;
            this.shshinfo.Text = "Shsh Information";
            // 
            // winbrella
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(576, 588);
            this.Controls.Add(this.btnbetaapledownload);
            this.Controls.Add(this.btnappledownload);
            this.Controls.Add(this.btnifaithdownload);
            this.Controls.Add(this.btncydiadownload);
            this.Controls.Add(this.lblbetashsh);
            this.Controls.Add(this.lstbetaapple);
            this.Controls.Add(this.lblappleheader);
            this.Controls.Add(this.lstappleblobs);
            this.Controls.Add(this.lblifaithheader);
            this.Controls.Add(this.lstifaithblobs);
            this.Controls.Add(this.lblcydiaheader);
            this.Controls.Add(this.gbdevinfo);
            this.Controls.Add(this.lstcydiablobs);
            this.Controls.Add(this.Statusbotton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.shshinfo);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "winbrella";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Statusbotton.ResumeLayout(false);
            this.Statusbotton.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbdevinfo.ResumeLayout(false);
            this.gbdevinfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip Statusbotton;
        private System.Windows.Forms.ToolStripStatusLabel toolstripconnectinfo;
        private System.Windows.Forms.ToolStripStatusLabel toolstripinternet;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListBox lstcydiablobs;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusblob;
        private System.Windows.Forms.ListView devicecontainer;
        private System.Windows.Forms.GroupBox gbdevinfo;
        private System.Windows.Forms.TextBox txtbuildver;
        private System.Windows.Forms.Label lbliosbuild;
        private System.Windows.Forms.Label lblchipidhex;
        private System.Windows.Forms.TextBox txtchipidhex;
        private System.Windows.Forms.Label lblcydiadown;
        private System.Windows.Forms.Label lblChipIDdec;
        private System.Windows.Forms.TextBox txtChipid;
        private System.Windows.Forms.Label lblboarmodel;
        private System.Windows.Forms.Button btncheck;
        private System.Windows.Forms.Label lblmodelid;
        private System.Windows.Forms.TextBox txtboardmodel;
        private System.Windows.Forms.TextBox txtimei;
        private System.Windows.Forms.Label lblimei;
        private System.Windows.Forms.TextBox txtserialno;
        private System.Windows.Forms.Label lblserial;
        private System.Windows.Forms.TextBox txtecidhex;
        private System.Windows.Forms.Label lblecidhex;
        private System.Windows.Forms.TextBox txteciddec;
        private System.Windows.Forms.Label lbleciddec;
        private System.Windows.Forms.TextBox txtbbversion;
        private System.Windows.Forms.Label lblbaseband;
        private System.Windows.Forms.TextBox txtversion;
        private System.Windows.Forms.Label lblversion;
        private System.Windows.Forms.TextBox txtdevicemodel;
        private System.Windows.Forms.Label lbldeviceinformation;
        private System.Windows.Forms.Label lblcydiaheader;
        private System.Windows.Forms.Label lblifaithheader;
        private System.Windows.Forms.ListBox lstifaithblobs;
        private System.Windows.Forms.Label lblappleheader;
        private System.Windows.Forms.ListBox lstappleblobs;
        private System.Windows.Forms.Label lblbetashsh;
        private System.Windows.Forms.ListBox lstbetaapple;
        private System.Windows.Forms.FolderBrowserDialog savefolder;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
        private System.Windows.Forms.Button btncydiadownload;
        private System.Windows.Forms.Button btnifaithdownload;
        private System.Windows.Forms.Button btnappledownload;
        private System.Windows.Forms.Button btnbetaapledownload;
        private System.Windows.Forms.Button btnrecovery;
        private System.Windows.Forms.Button btnexitrecovery;
        private System.Windows.Forms.GroupBox shshinfo;
    }
}

