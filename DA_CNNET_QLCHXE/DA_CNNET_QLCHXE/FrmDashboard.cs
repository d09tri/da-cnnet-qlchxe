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
    public partial class FrmDashboard : Form
    {
        Services sv = new Services();
        int maNV = 0;
        string tenNV = "";

        public FrmDashboard(int id, string user)
        {
            InitializeComponent();
            pnlThongTin.Visible = false;
            sv.LoadChildForm(new FrmHome(), pnlLoadForm);
            maNV = id;
            tenNV = user;
            lblUser.Text = "Xin chào " + user;
            btnReceipt.Visible = btnReceipt.Enabled = false;
        }

        /** Note 1
         * Ghi chú: Chỉnh sửa và cài đặt
         * + Đối với các btn có menu con có thể tái sử dụng
         *   hai hàm ShowSubMenu(Panel pnl) và HideSubMenu()
         *
         * Sử dụng:
         *  + Btn mở ra menu con thì ShowSubMenu(Panel chứa các btn con)
         *  + Btn menu con sẽ thực thi lệnh trước khi gọi lại HideSubMenu()
         *  + Btn không có menu con thì gọi HideSubMenu() sau thực thi lệnh
         **/

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
            if (pnlThongTin.Visible == true)
                pnlThongTin.Visible = false;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            sv.LoadChildForm(new FrmHome(), pnlLoadForm);
            HideSubMenu();
        }

        private void btnCarList_Click(object sender, EventArgs e)
        {
            sv.LoadChildForm(new FrmCarList(), pnlLoadForm);
            HideSubMenu();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            sv.LoadChildForm(new FrmKhachHang(), pnlLoadForm);
            HideSubMenu();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            sv.LoadChildForm(new FrmBanHang(maNV, tenNV), pnlLoadForm);
            HideSubMenu();
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlThongTin);
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            sv.LoadChildForm(new FrmHoaDon(), pnlLoadForm);
            HideSubMenu();
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            // ..
            HideSubMenu();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.SetVisibleCore(false);
            FrmLogin frm = new FrmLogin();
            frm.Show();
        }
    }
}
