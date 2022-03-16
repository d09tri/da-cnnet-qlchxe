using DA_CNNET_QLCHXE.Controllers;
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
    public partial class FrmAdmin : Form
    {
        int maNV = 0;
        string tenNV = "";

        public FrmAdmin(int id, string username)
        {
            InitializeComponent();
            maNV = id;
            tenNV = username;
            lblUsername.Text = "Xin chào " + tenNV;
            pnlQuanLySubMenu.Visible = pnlThongKeSubMenu.Visible = pnlHeThongSubMenu.Visible = false;
            sv.LoadChildForm(new FrmCarList(), pnlLoad);
        }

        Services sv = new Services();

        private void ShowSubMenu(Panel pnl)
        {
            if (pnl.Visible == false)
            {
                HideSubMenu();
                pnl.Visible = true;
            }
            else
                pnl.Visible = false;
        }

        private void HideSubMenu()
        {
            if (pnlQuanLySubMenu.Visible == true)
                pnlQuanLySubMenu.Visible = false;
            if (pnlThongKeSubMenu.Visible == true)
                pnlThongKeSubMenu.Visible = false;
            if (pnlHeThongSubMenu.Visible == true)
                pnlHeThongSubMenu.Visible = false;
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlQuanLySubMenu);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlThongKeSubMenu);
        }

        private void btnQLHoaDon_Click(object sender, EventArgs e)
        {
            FrmHoaDon frm = new FrmHoaDon();
            frm.SetColor(50, 61, 52);
            sv.LoadChildForm(frm, pnlLoad);            
            HideSubMenu();
        }

        private void btnQLMatHang_Click(object sender, EventArgs e)
        {
            sv.LoadChildForm(new FrmCarList(), pnlLoad);
            HideSubMenu();
        }

        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            sv.LoadChildForm(new FrmNhanVien(), pnlLoad);
            HideSubMenu();
        }

        private void btnQLKhachHang_Click(object sender, EventArgs e)
        {
            FrmKhachHang frmKH = new FrmKhachHang();
            frmKH.SetColor(50, 61, 52);
            sv.LoadChildForm(frmKH, pnlLoad);
            HideSubMenu();
        }

        private void btnTKHoaDon_Click(object sender, EventArgs e)
        {
            sv.LoadChildForm(new FrmThongKeHoaDon(), pnlLoad);
            HideSubMenu();
        }

        private void btnTKTonKho_Click(object sender, EventArgs e)
        {
            sv.LoadChildForm(new FrmThongKeMatHang(), pnlLoad);
            HideSubMenu();
        }

        private void btnTKBanTrongNgay_Click(object sender, EventArgs e)
        {
            sv.LoadChildForm(new FrmThongKeDoanhThuTrongNgay(), pnlLoad);
            HideSubMenu();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.SetVisibleCore(false);
            FrmLogin frm = new FrmLogin();
            frm.Show();
        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlHeThongSubMenu);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            sv.LoadChildForm(new FrmBackup(), pnlLoad);
            HideSubMenu();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            sv.LoadChildForm(new FrmRestore(), pnlLoad);
            HideSubMenu();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            sv.LoadChildForm(new FrmTaiKhoan(), pnlLoad);
            HideSubMenu();
        }
    }
}
