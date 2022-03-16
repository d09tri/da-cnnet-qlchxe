using CrystalDecisions.CrystalReports.Engine;
using DA_CNNET_QLCHXE.Controllers;
using DA_CNNET_QLCHXE.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_CNNET_QLCHXE
{
    public partial class FrmThongKeHoaDon : Form
    {
        public FrmThongKeHoaDon()
        {
            InitializeComponent();
        }

        RpHoaDon rp = new RpHoaDon();
        ThongKe tk = new ThongKe();

        private void FrmThongKeHoaDon_Load(object sender, EventArgs e)
        {
            dtpNgayLap.MaxDate = DateTime.Now;
            for (int i = 1; i < 13; i++)
            {
                cmbThang.Items.Add(i);
            }
            cmbThang.SelectedIndex = 0;
            cmbThang.Enabled = false;
        }

        private void chkThang_CheckedChanged(object sender, EventArgs e)
        {
            if (chkThang.Checked)
            {
                dtpNgayLap.Enabled = false;
                cmbThang.Enabled = true;
            }
            else
            {
                dtpNgayLap.Enabled = true;
                cmbThang.Enabled = false;
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            crvHoaDon.ReportSource = null;
            crvHoaDon.Refresh();

            if (chkThang.Checked)
            {
                tk.LoadHoaDonTheoThang(cmbThang.Text);
                DataTable dt = tk.GetTable("tbl_HoaDonTheoThang");
                rp.SetDataSource(dt);
                crvHoaDon.ReportSource = rp;
                (rp.ReportDefinition.ReportObjects["txtLoaiTK"] as TextObject).Text = "Thống kê hoá đơn tháng " + cmbThang.Text;
            }
            else
            {
                tk.LoadHoaDonTheoNgay(dtpNgayLap.Value.Date.ToString());
                DataTable dt = tk.GetTable("tbl_HoaDonTheoNgay");
                rp.SetDataSource(dt);
                crvHoaDon.ReportSource = rp;
                (rp.ReportDefinition.ReportObjects["txtLoaiTK"] as TextObject).Text = "Thống kê hoá đơn ngày " + dtpNgayLap.Text;
            }
        }
    }
}
