namespace DA_CNNET_QLCHXE
{
    partial class CarItem
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
            this.lblChiTietXe = new System.Windows.Forms.LinkLabel();
            this.picHinhAnhXe = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnhXe)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChiTietXe
            // 
            this.lblChiTietXe.AutoEllipsis = true;
            this.lblChiTietXe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblChiTietXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChiTietXe.LinkColor = System.Drawing.Color.Gainsboro;
            this.lblChiTietXe.Location = new System.Drawing.Point(0, 180);
            this.lblChiTietXe.Name = "lblChiTietXe";
            this.lblChiTietXe.Size = new System.Drawing.Size(210, 40);
            this.lblChiTietXe.TabIndex = 2;
            this.lblChiTietXe.TabStop = true;
            this.lblChiTietXe.Text = "linkLabel";
            this.lblChiTietXe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblChiTietXe.Click += new System.EventHandler(this.lblChiTietXe_Click);
            // 
            // picHinhAnhXe
            // 
            this.picHinhAnhXe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picHinhAnhXe.Location = new System.Drawing.Point(51, 19);
            this.picHinhAnhXe.Name = "picHinhAnhXe";
            this.picHinhAnhXe.Size = new System.Drawing.Size(267, 188);
            this.picHinhAnhXe.TabIndex = 3;
            this.picHinhAnhXe.TabStop = false;
            // 
            // CarItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(110)))), ((int)(((byte)(194)))));
            this.Controls.Add(this.picHinhAnhXe);
            this.Controls.Add(this.lblChiTietXe);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(210, 220);
            this.Name = "CarItem";
            this.Size = new System.Drawing.Size(210, 220);
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnhXe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblChiTietXe;
        private System.Windows.Forms.PictureBox picHinhAnhXe;
    }
}
