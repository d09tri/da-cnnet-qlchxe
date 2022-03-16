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
    public partial class FrmNhanVien : Form
    {
        public FrmNhanVien()
        {
            InitializeComponent();
        }

        Services sv = new Services();
        NhanVienController nv = new NhanVienController();
        string tt = "Mac dinh";

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            LoadListView();
            pnlMain.Controls.OfType<TextBox>().ToList().ForEach(t => t.Enabled = false);
            cboGioiTinh.Enabled = false;
            dtpNgaySinh.Enabled = false;

            btnSua.Enabled = btnXoa.Enabled = btnLuu.Enabled = false;

            dtpNgaySinh.MaxDate = DateTime.Now;
        }

        public void LoadListView()
        {
            lstDSNhanVien.Items.Clear();
            DataTable dtc = nv.TableNhanVien();
            foreach (DataRow row in dtc.Rows)
            {
                string maNV = row.ItemArray[0].ToString();
                string tenNV = row.ItemArray[1].ToString();
                string ngaySinh = row.ItemArray[2].ToString();
                string gioiTinh = row.ItemArray[3].ToString();
                string diaChi = row.ItemArray[4].ToString();
                string dienThoai = row.ItemArray[5].ToString();
                string email = row.ItemArray[6].ToString();

                ListViewItem item = new ListViewItem(new[] { maNV, tenNV, ngaySinh, gioiTinh, diaChi, dienThoai, email });
                lstDSNhanVien.Items.Add(item);
            }
        }

        private void lstDSNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDSNhanVien.SelectedItems.Count > 0)
            {
                ListViewItem item = lstDSNhanVien.SelectedItems[0];
                txtMaNV.Text = item.SubItems[0].Text;
                txtHoTen.Text = item.SubItems[1].Text;
                dtpNgaySinh.Text = item.SubItems[2].Text;
                cboGioiTinh.Text = item.SubItems[3].Text;
                txtDiaChi.Text = item.SubItems[4].Text;
                txtDienThoai.Text = item.SubItems[5].Text;
                txtEmail.Text = item.SubItems[6].Text;

                btnSua.Enabled = btnXoa.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = cboGioiTinh.Enabled = dtpNgaySinh.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            cboGioiTinh.SelectedIndex = 0;

            lstDSNhanVien.SelectedIndices.Clear();
            pnlMain.Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
            pnlMain.Controls.OfType<TextBox>().Where(t => t != txtMaNV).ToList().ForEach(t => t.Enabled = true);

            tt = "Them";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lstDSNhanVien.SelectedItems.Count > 0)
            {
                DialogResult r = MessageBox.Show("Xác nhận xoá", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    if (nv.KiemTraKhoaNgoai(Int32.Parse(txtMaNV.Text)))
                    {
                        MessageBox.Show("Không thể xoá nhân viên này", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        try
                        {
                            nv.XoaNhanVien(Int32.Parse(txtMaNV.Text));
                            MessageBox.Show("Xoá nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            cboGioiTinh.Enabled = btnXoa.Enabled = dtpNgaySinh.Enabled = false;

                            lstDSNhanVien.SelectedIndices.Clear();
                            pnlMain.Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
                            pnlMain.Controls.OfType<TextBox>().Where(t => t != txtMaNV).ToList().ForEach(t => t.Enabled = false);
                            cboGioiTinh.SelectedIndex = 0;

                            LoadListView();
                        }
                        catch
                        {
                            MessageBox.Show("Xoá nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = cboGioiTinh.Enabled = dtpNgaySinh.Enabled = true;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = false;

            lstDSNhanVien.SelectedIndices.Clear();
            pnlMain.Controls.OfType<TextBox>().Where(t => t != txtMaNV).ToList().ForEach(t => t.Enabled = true);

            tt = "Sua";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (pnlMain.Controls.OfType<TextBox>().Where(t => t != txtMaNV).Any(t => t.Text.Length == 0))
            {
                MessageBox.Show("Vui lòng nhập đủ dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Default();
                return;
            }
            if (!sv.CheckEmail(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng kiểm tra định dạng email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (tt == "Them")
                {
                    NhanVien nhanVien = new NhanVien(txtHoTen.Text, dtpNgaySinh.Value, cboGioiTinh.Text,
                        txtDiaChi.Text, txtDienThoai.Text, txtEmail.Text);
                    if (nv.ThemNhanVien(nhanVien))
                    {
                        MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadListView();
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (tt == "Sua")
                {
                    NhanVien nhanVien = new NhanVien(txtHoTen.Text, dtpNgaySinh.Value, cboGioiTinh.Text,
                        txtDiaChi.Text, txtDienThoai.Text, txtEmail.Text);
                    nhanVien.MaNV = Int32.Parse(txtMaNV.Text);

                    if (nv.SuaNhanVien(nhanVien))
                    {
                        MessageBox.Show("Sửa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadListView();
                    }
                    else
                    {
                        MessageBox.Show("Sửa nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            Default();
        }

        private void Default()
        {
            lstDSNhanVien.SelectedIndices.Clear();
            pnlMain.Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
            pnlMain.Controls.OfType<TextBox>().Where(t => t != txtMaNV).ToList().ForEach(t => t.Enabled = false);
            cboGioiTinh.SelectedIndex = 0;

            btnThem.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = btnLuu.Enabled = cboGioiTinh.Enabled = dtpNgaySinh.Enabled = false;
            tt = "Mac dinh";
        }

        FormWindowState LastWindowState = FormWindowState.Minimized;
        private void FrmNhanVien_Resize(object sender, EventArgs e)
        {
            if (WindowState != LastWindowState)
            {
                LastWindowState = WindowState;

                if (WindowState == FormWindowState.Maximized)
                {
                    lstDSNhanVien.Columns[6].Width = 230;
                }
                if (WindowState == FormWindowState.Normal)
                {
                    lstDSNhanVien.Columns[6].Width = 180;
                }
            }
        }

        private void lstDSNhanVien_SizeChanged(object sender, EventArgs e)
        {
            if (lstDSNhanVien.Width == 912)
            {
                lstDSNhanVien.Columns[2].Width = 180;
                lstDSNhanVien.Columns[6].Width = 180;
            }
            if (lstDSNhanVien.Width > 912)
            {
                lstDSNhanVien.Columns[2].Width = 300;
                lstDSNhanVien.Columns[6].Width = 300;
            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
