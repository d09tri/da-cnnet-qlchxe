namespace DA_CNNET_QLCHXE
{
    partial class FrmHoaDon
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnChiTietHD = new System.Windows.Forms.Button();
            this.lstDSHoaDon = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblDSHoaDon = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(101)))), ((int)(((byte)(179)))));
            this.pnlMain.Controls.Add(this.btnChiTietHD);
            this.pnlMain.Controls.Add(this.lstDSHoaDon);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 76);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1120, 643);
            this.pnlMain.TabIndex = 10;
            // 
            // btnChiTietHD
            // 
            this.btnChiTietHD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChiTietHD.Enabled = false;
            this.btnChiTietHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChiTietHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiTietHD.ForeColor = System.Drawing.Color.White;
            this.btnChiTietHD.Location = new System.Drawing.Point(699, 241);
            this.btnChiTietHD.Name = "btnChiTietHD";
            this.btnChiTietHD.Size = new System.Drawing.Size(188, 30);
            this.btnChiTietHD.TabIndex = 23;
            this.btnChiTietHD.Text = "Chi tiết hoá đơn";
            this.btnChiTietHD.UseVisualStyleBackColor = true;
            this.btnChiTietHD.Click += new System.EventHandler(this.btnChiTietHD_Click);
            // 
            // lstDSHoaDon
            // 
            this.lstDSHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDSHoaDon.BackColor = System.Drawing.Color.Azure;
            this.lstDSHoaDon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.lstDSHoaDon.FullRowSelect = true;
            this.lstDSHoaDon.GridLines = true;
            this.lstDSHoaDon.Location = new System.Drawing.Point(233, 23);
            this.lstDSHoaDon.Name = "lstDSHoaDon";
            this.lstDSHoaDon.Size = new System.Drawing.Size(654, 212);
            this.lstDSHoaDon.TabIndex = 8;
            this.lstDSHoaDon.UseCompatibleStateImageBehavior = false;
            this.lstDSHoaDon.View = System.Windows.Forms.View.Details;
            this.lstDSHoaDon.SelectedIndexChanged += new System.EventHandler(this.lstDSHoaDon_SelectedIndexChanged);
            this.lstDSHoaDon.SizeChanged += new System.EventHandler(this.lstDSHoaDon_SizeChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Mã HD";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Mã NV";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Mã KH";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Ngày bán";
            this.columnHeader9.Width = 180;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Trị giá";
            this.columnHeader10.Width = 120;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Tình trạng";
            this.columnHeader11.Width = 180;
            // 
            // lblDSHoaDon
            // 
            this.lblDSHoaDon.AutoSize = true;
            this.lblDSHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDSHoaDon.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDSHoaDon.Location = new System.Drawing.Point(12, 22);
            this.lblDSHoaDon.Name = "lblDSHoaDon";
            this.lblDSHoaDon.Size = new System.Drawing.Size(172, 46);
            this.lblDSHoaDon.TabIndex = 9;
            this.lblDSHoaDon.Text = "Hoá đơn";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblDSHoaDon);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1120, 76);
            this.pnlHeader.TabIndex = 11;
            // 
            // FrmHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(101)))), ((int)(((byte)(179)))));
            this.ClientSize = new System.Drawing.Size(1120, 719);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmHoaDon";
            this.Text = "FrmHoaDon";
            this.Load += new System.EventHandler(this.FrmHoaDon_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ListView lstDSHoaDon;
        private System.Windows.Forms.Label lblDSHoaDon;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Button btnChiTietHD;
    }
}