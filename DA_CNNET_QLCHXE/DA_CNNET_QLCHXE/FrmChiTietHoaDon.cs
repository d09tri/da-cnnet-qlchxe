using CrystalDecisions.CrystalReports.Engine;
using DA_CNNET_QLCHXE.Controllers;
using DA_CNNET_QLCHXE.Models;
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
    public partial class FrmChiTietHoaDon : Form
    {
        int maHD = 0;
        public FrmChiTietHoaDon(int maHD)
        {
            InitializeComponent();
            this.maHD = maHD;
        }

        Services sv = new Services();
        ChiTietHoaDonBanController cthdCtrl = new ChiTietHoaDonBanController();
        HoaDonBanController hdCtrl = new HoaDonBanController();
        NhanVienController nvCtrl = new NhanVienController();
        KhachHangController khCtrl = new KhachHangController();
        RpChiTietHoaDon rp = new RpChiTietHoaDon();

        private void ThongTinHoaDon()
        {
            HoaDonBan hd = hdCtrl.LayThongTinHoaDon(maHD);
            (rp.ReportDefinition.ReportObjects["txtMaHD"] as TextObject).Text = hd.MaHD.ToString();
            (rp.ReportDefinition.ReportObjects["txtNhanVien"] as TextObject).Text = nvCtrl.LayTenNhanVien(hd.MaNV);
            (rp.ReportDefinition.ReportObjects["txtKhachHang"] as TextObject).Text = khCtrl.LayTenKhachHang(hd.MaKH);
            (rp.ReportDefinition.ReportObjects["txtNgayBan"] as TextObject).Text = hd.NgayBan.ToShortDateString();
            (rp.ReportDefinition.ReportObjects["txtTriGia"] as TextObject).Text = string.Format("{0:n0}", hd.TriGia);
        }

        private void FrmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            ThongTinHoaDon();
            rp.SetDatabaseLogon("sa", "123");
            cthdCtrl.LoadCTHDTimKiem(maHD);
            DataTable dt = cthdCtrl.TableTimKiem();
            rp.SetDataSource(dt);
            crvChiTietHoaDon.ReportSource = rp;
        }


    }
}
