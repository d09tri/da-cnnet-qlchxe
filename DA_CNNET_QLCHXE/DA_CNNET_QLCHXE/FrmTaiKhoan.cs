using DA_CNNET_QLCHXE.Controllers;
using DA_CNNET_QLCHXE.Models;
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
    public partial class FrmTaiKhoan : Form
    {
        public FrmTaiKhoan()
        {
            InitializeComponent();
        }

        Services sv = new Services();
        QuanTriVienController qtvCtrl = new QuanTriVienController();
        NhanVienController nvCtrl = new NhanVienController();
        string tt = "Mac dinh";

        private void FrmTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadListView();
            grbThongTin.Controls.OfType<TextBox>().ToList().ForEach(t => t.Enabled = false);
            cmbNhanVien.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLuu.Enabled = false;
        }

        public void LoadListView()
        {
            lstDSTaiKhoan.Items.Clear();
            DataTable dtc = qtvCtrl.TableQuanTriVien();
            foreach (DataRow row in dtc.Rows)
            {
                string tenDangNhap = row.ItemArray[0].ToString();
                string maNV = row.ItemArray[2].ToString();
                string quyenHan = row.ItemArray[3].ToString();

                ListViewItem item = new ListViewItem(new[] { tenDangNhap, maNV, quyenHan });
                lstDSTaiKhoan.Items.Add(item);
            }

            nvCtrl.LoadNhanVienCoTaiKhoan();
            cmbNhanVien.DataSource = nvCtrl.TableNhanVienCoTaiKhoan();
            cmbNhanVien.DisplayMember = "TenNV";
            cmbNhanVien.ValueMember = "MaNV";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cmbNhanVien.DataSource = null;

            nvCtrl.LoadNhanVienKoLaQTV();
            cmbNhanVien.DataSource = nvCtrl.TableNhanVienKoLaQTV();
            cmbNhanVien.DisplayMember = "TenNV";
            cmbNhanVien.ValueMember = "MaNV";

            btnLuu.Enabled = cmbNhanVien.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;

            lstDSTaiKhoan.SelectedIndices.Clear();
            grbThongTin.Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
            grbThongTin.Controls.OfType<TextBox>().Where(t => t != txtQuyenHan).ToList().ForEach(t => t.Enabled = true);
            grbThongTin.Controls.OfType<ComboBox>().ToList().ForEach(t => t.Enabled = true);
            lstDSTaiKhoan.Enabled = false;
            tt = "Them";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lstDSTaiKhoan.SelectedItems.Count > 0)
            {
                DialogResult r = MessageBox.Show("Xác nhận xoá", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    try
                    {
                        qtvCtrl.XoaQuanTriVien(txtTenDangNhap.Text);
                        MessageBox.Show("Xoá tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        cmbNhanVien.Enabled = btnXoa.Enabled = false;

                        lstDSTaiKhoan.SelectedIndices.Clear();
                        grbThongTin.Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
                        grbThongTin.Controls.OfType<TextBox>().ToList().ForEach(t => t.Enabled = false);
                        cmbNhanVien.SelectedIndex = 0;

                        LoadListView();
                    }
                    catch
                    {
                        MessageBox.Show("Xoá tài khoản thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = false;

            lstDSTaiKhoan.SelectedIndices.Clear();
            grbThongTin.Controls.OfType<TextBox>().Where(t => t != txtTenDangNhap && t != txtQuyenHan).ToList().ForEach(t => t.Enabled = true);
            lstDSTaiKhoan.Enabled = false;

            tt = "Sua";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (grbThongTin.Controls.OfType<TextBox>().Where(t => t != txtQuyenHan).Any(t => t.Text.Length == 0))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Không còn nhân viên khả dụng để tạo tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                
                if (tt == "Them")
                {
                    if (qtvCtrl.KiemTraTenDangNhap(txtTenDangNhap.Text))
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    QuanTriVien qtv = new QuanTriVien(txtTenDangNhap.Text, sv.Hash(txtMatKhau.Text), Int32.Parse(cmbNhanVien.SelectedValue.ToString()), "NhanVien");
                    if (qtvCtrl.ThemQuanTriVien(qtv))
                    {
                        MessageBox.Show("Thêm tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadListView();
                    }
                    else
                    {
                        MessageBox.Show("Thêm tài khoản thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (tt == "Sua")
                {
                    QuanTriVien qtv = new QuanTriVien(txtTenDangNhap.Text, sv.Hash(txtMatKhau.Text), Int32.Parse(cmbNhanVien.SelectedValue.ToString()), "NhanVien");
                    if (qtvCtrl.SuaQuanTriVien(qtv))
                    {
                        MessageBox.Show("Sửa tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadListView();
                    }
                    else
                    {
                        MessageBox.Show("Sửa tài khoản thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            cmbNhanVien.DataSource = null;

            nvCtrl.LoadNhanVienCoTaiKhoan();
            cmbNhanVien.DataSource = nvCtrl.TableNhanVienCoTaiKhoan();
            cmbNhanVien.DisplayMember = "TenNV";
            cmbNhanVien.ValueMember = "MaNV";

            lstDSTaiKhoan.SelectedIndices.Clear();
            lstDSTaiKhoan.Enabled = true;
            grbThongTin.Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
            grbThongTin.Controls.OfType<TextBox>().ToList().ForEach(t => t.Enabled = false);
            grbThongTin.Controls.OfType<ComboBox>().ToList().ForEach(t => t.Enabled = false);
            cmbNhanVien.SelectedIndex = 0;

            btnThem.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = btnLuu.Enabled = false;
            tt = "Mac dinh";
        }

        private void lstDSTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDSTaiKhoan.SelectedItems.Count > 0)
            {
                ListViewItem item = lstDSTaiKhoan.SelectedItems[0];
                txtTenDangNhap.Text = item.SubItems[0].Text;
                cmbNhanVien.SelectedValue = item.SubItems[1].Text;
                txtQuyenHan.Text = item.SubItems[2].Text;
                txtMatKhau.Text = qtvCtrl.MatKhau(txtTenDangNhap.Text);
                btnSua.Enabled = btnXoa.Enabled = true;
            }
        }
    }
}
