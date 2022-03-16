namespace DA_CNNET_QLCHXE
{
    partial class FrmThongKeHoaDon
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
            this.reportDocument1 = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbThang = new System.Windows.Forms.ComboBox();
            this.chkThang = new System.Windows.Forms.CheckBox();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.crvHoaDon = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.lblMatHang = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(52)))));
            this.panel1.Controls.Add(this.lblMatHang);
            this.panel1.Controls.Add(this.btnThongKe);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbThang);
            this.panel1.Controls.Add(this.chkThang);
            this.panel1.Controls.Add(this.dtpNgayLap);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(912, 100);
            this.panel1.TabIndex = 0;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(790, 41);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(110, 31);
            this.btnThongKe.TabIndex = 4;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(450, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Theo ngày";
            // 
            // cmbThang
            // 
            this.cmbThang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbThang.FormattingEnabled = true;
            this.cmbThang.Location = new System.Drawing.Point(630, 45);
            this.cmbThang.Name = "cmbThang";
            this.cmbThang.Size = new System.Drawing.Size(121, 24);
            this.cmbThang.TabIndex = 2;
            // 
            // chkThang
            // 
            this.chkThang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkThang.AutoSize = true;
            this.chkThang.ForeColor = System.Drawing.Color.White;
            this.chkThang.Location = new System.Drawing.Point(630, 24);
            this.chkThang.Name = "chkThang";
            this.chkThang.Size = new System.Drawing.Size(103, 21);
            this.chkThang.TabIndex = 1;
            this.chkThang.Text = "Theo tháng";
            this.chkThang.UseVisualStyleBackColor = true;
            this.chkThang.CheckedChanged += new System.EventHandler(this.chkThang_CheckedChanged);
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpNgayLap.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayLap.Location = new System.Drawing.Point(453, 47);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(124, 22);
            this.dtpNgayLap.TabIndex = 0;
            // 
            // crvHoaDon
            // 
            this.crvHoaDon.ActiveViewIndex = -1;
            this.crvHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvHoaDon.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvHoaDon.Location = new System.Drawing.Point(0, 100);
            this.crvHoaDon.Name = "crvHoaDon";
            this.crvHoaDon.Size = new System.Drawing.Size(912, 400);
            this.crvHoaDon.TabIndex = 1;
            this.crvHoaDon.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // lblMatHang
            // 
            this.lblMatHang.AutoSize = true;
            this.lblMatHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatHang.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblMatHang.Location = new System.Drawing.Point(12, 22);
            this.lblMatHang.Name = "lblMatHang";
            this.lblMatHang.Size = new System.Drawing.Size(342, 46);
            this.lblMatHang.TabIndex = 12;
            this.lblMatHang.Text = "Thống kê hoá đơn";
            // 
            // FrmThongKeHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 500);
            this.Controls.Add(this.crvHoaDon);
            this.Controls.Add(this.panel1);
            this.Name = "FrmThongKeHoaDon";
            this.Text = "FrmThongKeHoaDon";
            this.Load += new System.EventHandler(this.FrmThongKeHoaDon_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbThang;
        private System.Windows.Forms.CheckBox chkThang;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvHoaDon;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Label lblMatHang;

    }
}