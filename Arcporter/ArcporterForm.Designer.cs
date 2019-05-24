namespace Arcporter
{
    sealed partial class ArcporterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArcporterForm));
            this.btnBrowse = new DarkUI.Controls.DarkButton();
            this.dtbPath = new DarkUI.Controls.DarkTextBox();
            this.dlvZones = new DarkUI.Controls.DarkListView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnInfo = new DarkUI.Controls.DarkButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtbTitle = new DarkUI.Controls.DarkTextBox();
            this.dtbInfo = new DarkUI.Controls.DarkTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(232, 342);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Padding = new System.Windows.Forms.Padding(5);
            this.btnBrowse.Size = new System.Drawing.Size(32, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.Click += new System.EventHandler(this.DarkButton1_Click);
            // 
            // dtbPath
            // 
            this.dtbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtbPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.dtbPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtbPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.dtbPath.Location = new System.Drawing.Point(-1, 342);
            this.dtbPath.Name = "dtbPath";
            this.dtbPath.ReadOnly = true;
            this.dtbPath.Size = new System.Drawing.Size(232, 20);
            this.dtbPath.TabIndex = 1;
            this.dtbPath.Text = "Please locate FirefallClient.exe";
            // 
            // dlvZones
            // 
            this.dlvZones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dlvZones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.dlvZones.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dlvZones.Location = new System.Drawing.Point(0, 0);
            this.dlvZones.Name = "dlvZones";
            this.dlvZones.Size = new System.Drawing.Size(284, 340);
            this.dlvZones.TabIndex = 0;
            this.dlvZones.Text = "darkListView1";
            this.dlvZones.Visible = false;
            this.dlvZones.DoubleClick += new System.EventHandler(this.DarkListView1_DoubleClick);
            this.dlvZones.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DarkListView1_KeyUp);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "FirefallClient.exe";
            this.openFileDialog1.Filter = "Game Client | FirefallClient.exe";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
            // 
            // btnInfo
            // 
            this.btnInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInfo.Location = new System.Drawing.Point(265, 342);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Padding = new System.Windows.Forms.Padding(5);
            this.btnInfo.Size = new System.Drawing.Size(20, 23);
            this.btnInfo.TabIndex = 3;
            this.btnInfo.Text = "?";
            this.btnInfo.Click += new System.EventHandler(this.DarkButton2_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.panel1.Controls.Add(this.dtbTitle);
            this.panel1.Controls.Add(this.dtbInfo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(286, 340);
            this.panel1.TabIndex = 4;
            // 
            // dtbTitle
            // 
            this.dtbTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.dtbTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtbTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtbTitle.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.dtbTitle.Location = new System.Drawing.Point(10, 10);
            this.dtbTitle.Multiline = true;
            this.dtbTitle.Name = "dtbTitle";
            this.dtbTitle.ReadOnly = true;
            this.dtbTitle.Size = new System.Drawing.Size(266, 24);
            this.dtbTitle.TabIndex = 2;
            this.dtbTitle.Text = "ARCPORTER";
            this.dtbTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtbInfo
            // 
            this.dtbInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.dtbInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtbInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtbInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtbInfo.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtbInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.dtbInfo.Location = new System.Drawing.Point(10, 31);
            this.dtbInfo.Multiline = true;
            this.dtbInfo.Name = "dtbInfo";
            this.dtbInfo.Size = new System.Drawing.Size(266, 299);
            this.dtbInfo.TabIndex = 1;
            this.dtbInfo.Text = resources.GetString("dtbInfo.Text");
            this.dtbInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ArcporterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.dtbPath);
            this.Controls.Add(this.dlvZones);
            this.MinimumSize = new System.Drawing.Size(300, 400);
            this.Name = "ArcporterForm";
            this.Text = "Arcporter";
            this.Load += new System.EventHandler(this.ArcporterForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkListView dlvZones;
        private DarkUI.Controls.DarkTextBox dtbPath;
        private DarkUI.Controls.DarkButton btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DarkUI.Controls.DarkButton btnInfo;
        private System.Windows.Forms.Panel panel1;
        private DarkUI.Controls.DarkTextBox dtbInfo;
        private DarkUI.Controls.DarkTextBox dtbTitle;
    }
}

