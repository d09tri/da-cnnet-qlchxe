namespace DA_CNNET_QLCHXE
{
    partial class FrmChiTietHoaDon
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
            this.crvChiTietHoaDon = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvChiTietHoaDon
            // 
            this.crvChiTietHoaDon.ActiveViewIndex = -1;
            this.crvChiTietHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvChiTietHoaDon.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvChiTietHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvChiTietHoaDon.Location = new System.Drawing.Point(0, 0);
            this.crvChiTietHoaDon.Name = "crvChiTietHoaDon";
            this.crvChiTietHoaDon.Size = new System.Drawing.Size(912, 500);
            this.crvChiTietHoaDon.TabIndex = 0;
            this.crvChiTietHoaDon.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FrmChiTietHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 500);
            this.Controls.Add(this.crvChiTietHoaDon);
            this.Name = "FrmChiTietHoaDon";
            this.Text = "FrmChiTietHoaDon";
            this.Load += new System.EventHandler(this.FrmChiTietHoaDon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvChiTietHoaDon;
    }
}