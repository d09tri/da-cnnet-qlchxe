namespace DA_CNNET_QLCHXE
{
    partial class FrmThongKeMatHang
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartThongKeTonKho = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTonKho = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeTonKho)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartThongKeTonKho
            // 
            this.chartThongKeTonKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(52)))));
            chartArea1.Name = "areaThongKe";
            this.chartThongKeTonKho.ChartAreas.Add(chartArea1);
            this.chartThongKeTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartThongKeTonKho.Legends.Add(legend1);
            this.chartThongKeTonKho.Location = new System.Drawing.Point(0, 100);
            this.chartThongKeTonKho.Name = "chartThongKeTonKho";
            series1.ChartArea = "areaThongKe";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.LabelBackColor = System.Drawing.Color.Transparent;
            series1.LabelBorderColor = System.Drawing.Color.Transparent;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "ThongKeTonKho";
            series1.YValuesPerPoint = 4;
            this.chartThongKeTonKho.Series.Add(series1);
            this.chartThongKeTonKho.Size = new System.Drawing.Size(1027, 479);
            this.chartThongKeTonKho.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(52)))));
            this.panel1.Controls.Add(this.lblTonKho);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1027, 100);
            this.panel1.TabIndex = 1;
            // 
            // lblTonKho
            // 
            this.lblTonKho.AutoSize = true;
            this.lblTonKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTonKho.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTonKho.Location = new System.Drawing.Point(12, 22);
            this.lblTonKho.Name = "lblTonKho";
            this.lblTonKho.Size = new System.Drawing.Size(505, 46);
            this.lblTonKho.TabIndex = 12;
            this.lblTonKho.Text = "Thống kê mặt hàng tồn kho";
            // 
            // FrmThongKeMatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 579);
            this.Controls.Add(this.chartThongKeTonKho);
            this.Controls.Add(this.panel1);
            this.Name = "FrmThongKeMatHang";
            this.Text = "FrmThongKeMatHang";
            this.Load += new System.EventHandler(this.FrmThongKeMatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeTonKho)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartThongKeTonKho;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTonKho;
    }
}