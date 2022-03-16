namespace DA_CNNET_QLCHXE
{
    partial class FrmThongKeDoanhThuTrongNgay
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartThongKe = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtpNgayBan = new System.Windows.Forms.DateTimePicker();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblMatHang = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKe)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartThongKe
            // 
            chartArea5.Name = "AreaDoanhThu";
            chartArea6.Name = "AreaSoLuong";
            this.chartThongKe.ChartAreas.Add(chartArea5);
            this.chartThongKe.ChartAreas.Add(chartArea6);
            this.chartThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chartThongKe.Legends.Add(legend3);
            this.chartThongKe.Location = new System.Drawing.Point(0, 100);
            this.chartThongKe.Name = "chartThongKe";
            series5.BorderColor = System.Drawing.Color.Transparent;
            series5.ChartArea = "AreaDoanhThu";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series5.IsValueShownAsLabel = true;
            series5.LabelForeColor = System.Drawing.Color.White;
            series5.Legend = "Legend1";
            series5.Name = "ThongKeDoanhThu";
            series5.YValuesPerPoint = 6;
            series6.ChartArea = "AreaSoLuong";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series6.IsValueShownAsLabel = true;
            series6.LabelForeColor = System.Drawing.Color.White;
            series6.Legend = "Legend1";
            series6.Name = "ThongKeSoLuong";
            series6.YValuesPerPoint = 2;
            this.chartThongKe.Series.Add(series5);
            this.chartThongKe.Series.Add(series6);
            this.chartThongKe.Size = new System.Drawing.Size(1120, 619);
            this.chartThongKe.TabIndex = 0;
            this.chartThongKe.Text = "chartThongKe";
            // 
            // dtpNgayBan
            // 
            this.dtpNgayBan.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayBan.CustomFormat = "yyyy-MM-dd";
            this.dtpNgayBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayBan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayBan.Location = new System.Drawing.Point(670, 31);
            this.dtpNgayBan.Name = "dtpNgayBan";
            this.dtpNgayBan.Size = new System.Drawing.Size(165, 22);
            this.dtpNgayBan.TabIndex = 1;
            // 
            // btnThongKe
            // 
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(670, 59);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(163, 35);
            this.btnThongKe.TabIndex = 2;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(52)))));
            this.pnlHeader.Controls.Add(this.lblMatHang);
            this.pnlHeader.Controls.Add(this.btnThongKe);
            this.pnlHeader.Controls.Add(this.dtpNgayBan);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1120, 100);
            this.pnlHeader.TabIndex = 3;
            // 
            // lblMatHang
            // 
            this.lblMatHang.AutoSize = true;
            this.lblMatHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatHang.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblMatHang.Location = new System.Drawing.Point(12, 22);
            this.lblMatHang.Name = "lblMatHang";
            this.lblMatHang.Size = new System.Drawing.Size(650, 46);
            this.lblMatHang.TabIndex = 12;
            this.lblMatHang.Text = "Thống kê doanh thu bán trong ngày";
            // 
            // FrmThongKeDoanhThuTrongNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 719);
            this.Controls.Add(this.chartThongKe);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmThongKeDoanhThuTrongNgay";
            this.Text = "FrmThongKeDoanhThuTrongNgay";
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKe)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartThongKe;
        private System.Windows.Forms.DateTimePicker dtpNgayBan;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblMatHang;
    }
}