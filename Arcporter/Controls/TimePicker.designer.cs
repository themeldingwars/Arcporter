namespace Arcporter.Controls
{
    partial class TimePicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTrack = new System.Windows.Forms.Panel();
            this.pnlThumb = new System.Windows.Forms.Panel();
            this.lblTime = new DarkUI.Controls.DarkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.pnlTrack.SuspendLayout();
            this.pnlThumb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTrack
            // 
            this.pnlTrack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTrack.Controls.Add(this.pnlThumb);
            this.pnlTrack.Location = new System.Drawing.Point(44, 0);
            this.pnlTrack.Name = "pnlTrack";
            this.pnlTrack.Size = new System.Drawing.Size(141, 18);
            this.pnlTrack.TabIndex = 1;
            // 
            // pnlThumb
            // 
            this.pnlThumb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.pnlThumb.Controls.Add(this.lblTime);
            this.pnlThumb.Location = new System.Drawing.Point(0, 1);
            this.pnlThumb.Name = "pnlThumb";
            this.pnlThumb.Size = new System.Drawing.Size(52, 14);
            this.pnlThumb.TabIndex = 0;
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblTime.Location = new System.Drawing.Point(-4, -1);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(60, 14);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "10:00 AM";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.lblTime.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.lblTime.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Arcporter.Properties.Resources.right;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(187, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(14, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Arcporter.Properties.Resources.left;
            this.pictureBox2.Location = new System.Drawing.Point(28, -2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(14, 19);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.darkLabel1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(1, 2);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(31, 13);
            this.darkLabel1.TabIndex = 5;
            this.darkLabel1.Text = "Time";
            // 
            // TimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.Controls.Add(this.darkLabel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlTrack);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "TimePicker";
            this.Size = new System.Drawing.Size(200, 18);
            this.Resize += new System.EventHandler(this.OnResize);
            this.pnlTrack.ResumeLayout(false);
            this.pnlThumb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlTrack;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pnlThumb;
        private DarkUI.Controls.DarkLabel lblTime;
        private DarkUI.Controls.DarkLabel darkLabel1;
    }
}
