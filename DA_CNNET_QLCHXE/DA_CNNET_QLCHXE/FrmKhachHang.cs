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
    public partial class FrmKhachHang : Form
    {
        public FrmKhachHang()
        {
            InitializeComponent();
        }

        Services sv = new Services();
        KhachHangController kh = new KhachHangController();
        string tt = "Mac dinh";
        DataView dv;
        DataTable dt = new DataTable();

        public void SetColor(int r, int g, int b)
        {
            this.BackColor = this.pnlMain.BackColor = Color.FromArgb(r, g, b);
            this.BackColor = this.pnlHeader.BackColor = Color.FromArgb(r, g, b);
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            LoadListView();
            pnlMain.Controls.OfType<TextBox>().Where(t => t != txtTimKiem).ToList().ForEach(t => t.Enabled = false);

            btnSua.Enabled = btnXoa.Enabled = btnLuu.Enabled = false;
        }

        private void LoadListView()
        {
            lstDSKhachHang.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                dt.Clear();
            }

            kh.LoadKhachHang();
            dt = kh.TableKhachHang();
            dv = new DataView(dt);

            foreach (DataRow r in dt.Rows)
            {
                string maKH = r.ItemArray[0].ToString();
                string tenKH = r.ItemArray[1].ToString();
                string diaChi = r.ItemArray[2].ToString();
                string dienThoai = r.ItemArray[3].ToString();
                string email = r.ItemArray[4].ToString();


                ListViewItem item = new ListViewItem(new[] { maKH, tenKH, diaChi, dienThoai, email });
                lstDSKhachHang.Items.Add(item);
            }
        }

        private void Default()
        {
            lstDSKhachHang.SelectedIndices.Clear();
            pnlMain.Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
            pnlMain.Controls.OfType<TextBox>().Where(t => t != txtMaKH && t != txtTimKiem).ToList().ForEach(t => t.Enabled = false);

            btnThem.Enabled = lstDSKhachHang.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = btnLuu.Enabled = false;
            tt = "Mac dinh";
        }

        private void lstDSKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDSKhachHang.SelectedItems.Count > 0)
            {
                ListViewItem item = lstDSKhachHang.SelectedItems[0];
                txtMaKH.Text = item.SubItems[0].Text;
                txtHoTen.Text = item.SubItems[1].Text;
                txtDiaChi.Text = item.SubItems[2].Text;
                txtDienThoai.Text = item.SubItems[3].Text;
                txtEmail.Text = item.SubItems[4].Text;

                btnSua.Enabled = btnXoa.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = lstDSKhachHang.Enabled = false;

            lstDSKhachHang.SelectedIndices.Clear();
            pnlMain.Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
            pnlMain.Controls.OfType<TextBox>().Where(t => t != txtMaKH).ToList().ForEach(t => t.Enabled = true);

            tt = "Them";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lstDSKhachHang.SelectedItems.Count > 0)
            {
                DialogResult r = MessageBox.Show("Xác nhận xoá", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    if (kh.KiemTraKhoaNgoai(Int32.Parse(txtMaKH.Text)))
                    {
                        MessageBox.Show("Không thể xoá khách hàng này", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        try
                        {
                            kh.XoaKhachHang(Int32.Parse(txtMaKH.Text));
                            MessageBox.Show("Xoá khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lstDSKhachHang.SelectedIndices.Clear();
                            pnlMain.Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
                            pnlMain.Controls.OfType<TextBox>().Where(t => t != txtMaKH).ToList().ForEach(t => t.Enabled = false);
                        }
                        catch
                        {
                            MessageBox.Show("Xoá khách hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }

                Default();
                LoadListView();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = lstDSKhachHang.Enabled = false;

            lstDSKhachHang.SelectedIndices.Clear();
            pnlMain.Controls.OfType<TextBox>().Where(t => t != txtMaKH).ToList().ForEach(t => t.Enabled = true);

            tt = "Sua";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (pnlMain.Controls.OfType<TextBox>().Where(t => t != txtMaKH && t != txtTimKiem).Any(t => t.Text.Length == 0))
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
                    KhachHang khachHang = new KhachHang(txtHoTen.Text, txtDiaChi.Text, txtDienThoai.Text, txtEmail.Text);
                    if (kh.ThemKhachHang(khachHang))
                    {
                        MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm khách hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (tt == "Sua")
                {
                    KhachHang khachHang = new KhachHang(txtHoTen.Text, txtDiaChi.Text, txtDienThoai.Text, txtEmail.Text);
                    khachHang.MaKH = Int32.Parse(txtMaKH.Text);

                    if (kh.SuaKhachHang(khachHang))
                    {
                        MessageBox.Show("Sửa khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sửa khách hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


            Default();
            LoadListView();
        }

        private void PopulateListView(DataView dv)
        {
            lstDSKhachHang.Items.Clear();
            foreach (DataRow r in dv.ToTable().Rows)
            {
                string maKH = r.ItemArray[0].ToString();
                string tenKH = r.ItemArray[1].ToString();
                string diaChi = r.ItemArray[2].ToString();
                string dienThoai = r.ItemArray[3].ToString();
                string email = r.ItemArray[4].ToString();

                ListViewItem item = new ListViewItem(new[] { maKH, tenKH, diaChi, dienThoai, email });
                lstDSKhachHang.Items.Add(item);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dv.RowFilter = string.Format("TenKH Like '%{0}%' or DiaChi Like '%{0}%' or DienThoai Like '%{0}%' or Email Like '%{0}%'", txtTimKiem.Text);
            PopulateListView(dv);
        }

        private void lstDSKhachHang_SizeChanged(object sender, EventArgs e)
        {
            if (lstDSKhachHang.Width == 912)
            {
                lstDSKhachHang.Columns[4].Width = 220;
                lstDSKhachHang.Columns[1].Width = 200;
            }
            if (lstDSKhachHang.Width > 912)
            {
                lstDSKhachHang.Columns[4].Width = 300;
                lstDSKhachHang.Columns[1].Width = 300;

            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
