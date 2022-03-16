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
    public partial class FrmBanHang : Form
    {
        int maNV = 0;
        int maHD = 0;
        int maxSL = 0; // Số lượng tồn kho của mặt hàng hiện tại
        string tenNV = "";

        DataView dv;
        DataTable dt = new DataTable();

        Services sv = new Services();
        MatHangController mhCtrl = new MatHangController();
        KhachHangController khCtrl = new KhachHangController();
        HoaDonBanController hdCtrl = new HoaDonBanController();
        ChiTietHoaDonBanController cthdCtrl = new ChiTietHoaDonBanController();

        List<MatHang> lstMH = new List<MatHang>();
        List<ChiTietHoaDonBan> lstCTHD = new List<ChiTietHoaDonBan>();

        public FrmBanHang(int maNV, string tenNV)
        {
            InitializeComponent();
            this.maNV = maNV;
            this.tenNV = tenNV;
            txtNhanVien.Text = tenNV + " (" + maNV + ") ";
            dtpNgayBan.Text = DateTime.Now.ToString();
        }

        private void FrmBanHang_Load(object sender, EventArgs e)
        {
            DataRow r = hdCtrl.LayHoaDonBanCC();
            int maHDKT = Int32.Parse(r["MaHD"].ToString());
            if (!cthdCtrl.KiemTraTonTai(maHDKT))
            {
                DialogResult dialogResult = MessageBox.Show("Hệ thống phát hiện thao tác thoát/chuyển form khi đang thanh toán hoá đơn mã hoá đơn (" + maHDKT + ").\n\nBạn có muốn tiếp tục thanh toán hoá đơn mã hoá đơn (" + maHDKT + ")?\n - Yes: Tiếp tục thanh toán hoá đơn\n - No: Xoá hoá đơn khỏi hệ thống", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    LoadDuLieu();
                    grbTaoHD.Enabled = grbTaoHD.Visible = false;
                    grbThongTin.Location = new Point(11, 11);
                    grbDSMatHang.Enabled = grbThongTin.Enabled = grbChiTietHoaDon.Enabled = grbThongTin.Visible = true;

                    grbThongTin.Controls.OfType<Label>().ToList().ForEach(t => t.Text = "");

                    maHD = maHDKT;
                    lblMaHD.Text = string.Format("Mã HD: {0}", maHD);
                    lblMaNV.Text = string.Format("Mã NV: {0}", r["MaNV"].ToString());
                    lblMaKH.Text = string.Format("Mã KH: {0}", r["MaKH"].ToString());
                    lblNgayBan.Text = string.Format("Ngày bán: {0}", r["NgayBan"].ToString());
                    lblTriGia.Text = string.Format("Trị giá: {0}", r["TriGia"].ToString());
                    lblTinhTrang.Text = string.Format("Tình trạng: {0}", r["TinhTrang"].ToString());
                }
                else if (dialogResult == DialogResult.No)
                {
                    try
                    {
                        hdCtrl.XoaHoaDonBan(maHDKT);
                        Default();
                        LoadDuLieu();
                        MessageBox.Show("Xoá hoá đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Xoá hoá đơn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                Default();
                LoadDuLieu();
            }
        }

        private void Default()
        {
            lstDSXe.Items.Clear();
            lstDSCTHD.Items.Clear();
            lstCTHD.Clear();
            lstMH.Clear();
            grbThongTin.Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
            grbTaoHD.Visible = grbTaoHD.Enabled = true;
            grbDSMatHang.Enabled = grbThongTin.Enabled = grbChiTietHoaDon.Enabled = grbThongTin.Visible = false;
            btnChonMatHang.Enabled = btnCapNhat.Enabled = btnXoaMatHang.Enabled = btnThanhToan.Enabled = false;
        }

        private void LoadDuLieu()
        {
            cboKhachHang.DataSource = khCtrl.TableKhachHang();
            cboKhachHang.DisplayMember = "TenKH";
            cboKhachHang.ValueMember = "MaKH";
            cboKhachHang.SelectedIndex = 0;

            if (dt.Rows.Count > 0)
            {
                dt.Clear();
                mhCtrl.LoadBanHang();
            }

            dt = mhCtrl.TableXeBH();
            dv = new DataView(dt);

            foreach (DataRow r in dt.Rows)
            {
                string maHang = r.ItemArray[0].ToString();
                string tenHang = r.ItemArray[1].ToString();
                string maNSX = r.ItemArray[2].ToString();
                string giaBan = r.ItemArray[3].ToString();
                string tonKho = r.ItemArray[4].ToString();
                string hinhAnh = r.ItemArray[5].ToString();
                string nhaSanXuat = r.ItemArray[7].ToString();

                ListViewItem item = new ListViewItem(new[] { maHang, tenHang, nhaSanXuat, giaBan, tonKho });
                MatHang xe = new MatHang(tenHang, Int32.Parse(maNSX), Int32.Parse(giaBan), Int32.Parse(tonKho), hinhAnh);
                xe.MaHang = Int32.Parse(maHang);

                lstDSXe.Items.Add(item);
                lstMH.Add(xe);
            }
        }

        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            grbTaoHD.Enabled = grbTaoHD.Visible = false;
            grbThongTin.Location = new Point(11, 11);
            grbDSMatHang.Enabled = grbThongTin.Enabled = grbChiTietHoaDon.Enabled = grbThongTin.Visible = true;

            HoaDonBan hdb = new HoaDonBan(maNV, Int32.Parse(cboKhachHang.SelectedValue.ToString()), DateTime.Now, 0, "Chưa thanh toán");
            if (hdCtrl.ThemHoaDonBan(hdb))
            {
                MessageBox.Show("Tạo hoá đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataRow r = hdCtrl.LayHoaDonBanCC();
                grbThongTin.Controls.OfType<Label>().ToList().ForEach(t => t.Text = "");

                maHD = Int32.Parse(r["MaHD"].ToString());
                lblMaHD.Text = string.Format("Mã HD: {0}", maHD);
                lblMaNV.Text = string.Format("Mã NV: {0}", r["MaNV"].ToString());
                lblMaKH.Text = string.Format("Mã KH: {0}", r["MaKH"].ToString());
                lblNgayBan.Text = string.Format("Ngày bán: {0}", r["NgayBan"].ToString());
                lblTriGia.Text = string.Format("Trị giá: {0}", r["TriGia"].ToString());
                lblTinhTrang.Text = string.Format("Tình trạng: {0}", r["TinhTrang"].ToString());
            }
            else
            {
                MessageBox.Show("Tạo hoá đơn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChonMatHang_Click(object sender, EventArgs e)
        {
            if (lstDSXe.SelectedItems.Count > 0)
            {
                int id = Int32.Parse(lstDSXe.SelectedItems[0].SubItems[0].Text);
                MatHang xe = lstMH.Where(t => t.MaHang == id).FirstOrDefault();

                ChiTietHoaDonBan cthd = new ChiTietHoaDonBan(maHD, xe.MaHang, 1, xe.GiaBan);

                if (lstCTHD.Any(t => t.MaHang == cthd.MaHang))
                {
                    ChiTietHoaDonBan f = lstCTHD.Where(t => t.MaHang == cthd.MaHang).FirstOrDefault();
                    f.SoLuong++;

                    lstDSCTHD.Items.Clear();
                    foreach (ChiTietHoaDonBan ct in lstCTHD)
                    {
                        MatHang mh = lstMH.Where(t => t.MaHang == ct.MaHang).FirstOrDefault();
                        int thanhTien = ct.SoLuong * mh.GiaBan;
                        ListViewItem item = new ListViewItem(new[] { ct.MaHD.ToString(), ct.MaHang.ToString(), ct.SoLuong.ToString(), thanhTien.ToString() });
                        lstDSCTHD.Items.Add(item);
                    }
                }
                else
                {
                    lstCTHD.Add(cthd);
                    ListViewItem item = new ListViewItem(new[] { maHD.ToString(), xe.MaHang.ToString(), "1", xe.GiaBan.ToString() });
                    lstDSCTHD.Items.Add(item);
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (lstDSCTHD.SelectedItems.Count > 0)
            {
                if (Int32.Parse(txtSoLuong.Text) > maxSL)
                {
                    MessageBox.Show("Số lượng không được phép lớn hơn tồn kho mặt hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int thanhTien = 0;
                ChiTietHoaDonBan cthd = lstCTHD.ElementAt(lstDSCTHD.Items.IndexOf(lstDSCTHD.SelectedItems[0]));
                cthd.SoLuong = Int32.Parse(txtSoLuong.Text);

                lstDSCTHD.Items.Clear();
                foreach (ChiTietHoaDonBan ct in lstCTHD)
                {
                    MatHang mh = lstMH.Where(t => t.MaHang == ct.MaHang).FirstOrDefault();
                    thanhTien = ct.SoLuong * mh.GiaBan;

                    ListViewItem item = new ListViewItem(new[] { ct.MaHD.ToString(), ct.MaHang.ToString(), ct.SoLuong.ToString(), thanhTien.ToString() });
                    lstDSCTHD.Items.Add(item);
                }
                cthd.ThanhTien = thanhTien;

                grbChiTietHoaDon.Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
            }
        }

        private void btnXoaMatHang_Click(object sender, EventArgs e)
        {
            if (lstDSCTHD.SelectedItems.Count > 0)
            {
                lstCTHD.RemoveAt(lstDSCTHD.Items.IndexOf(lstDSCTHD.SelectedItems[0]));

                lstDSCTHD.Items.Clear();
                foreach (ChiTietHoaDonBan ct in lstCTHD)
                {
                    MatHang mh = lstMH.Where(t => t.MaHang == ct.MaHang).FirstOrDefault();
                    int thanhTien = ct.SoLuong * mh.GiaBan;
                    ListViewItem item = new ListViewItem(new[] { ct.MaHD.ToString(), ct.MaHang.ToString(), ct.SoLuong.ToString(), thanhTien.ToString() });
                    lstDSCTHD.Items.Add(item);
                }

                grbChiTietHoaDon.Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (lstCTHD.Count <= 0)
            {
                MessageBox.Show("Không có mặt hàng nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ThemChiTietHoaDonBan())
            {
                MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Default();
                LoadDuLieu();
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Default();
                LoadDuLieu();
            }
        }

        private void PopulateListView(DataView dv)
        {
            lstDSXe.Items.Clear();
            foreach (DataRow r in dv.ToTable().Rows)
            {
                string maHang = r.ItemArray[0].ToString();
                string tenHang = r.ItemArray[1].ToString();
                string maNSX = r.ItemArray[2].ToString();
                string giaBan = r.ItemArray[3].ToString();
                string tonKho = r.ItemArray[4].ToString();
                string hinhAnh = r.ItemArray[5].ToString();
                string nhaSanXuat = r.ItemArray[7].ToString();

                ListViewItem item = new ListViewItem(new[] { maHang, tenHang, nhaSanXuat, giaBan, tonKho });
                lstDSXe.Items.Add(item);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dv.RowFilter = string.Format("TenHang Like '%{0}%' or TenNSX Like '%{1}%'", txtTimKiem.Text, txtTimKiem.Text);
            PopulateListView(dv);
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSoLuong.Text.Length == 0 && e.KeyChar == '0')
                e.Handled = true;
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)8))
                e.Handled = true;
        }

        private bool ThemChiTietHoaDonBan()
        {
            if (!hdCtrl.SuaTinhTrangHoaDon(maHD, "Đã thanh toán"))
                return false;
            foreach (ChiTietHoaDonBan ct in lstCTHD)
            {
                if (cthdCtrl.ThemCTHD(ct))
                    continue;
                else
                    return false;
            }
            return true;
        }

        private void lstDSXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDSXe.SelectedItems.Count > 0)
            {
                int id = Int32.Parse(lstDSXe.SelectedItems[0].SubItems[0].Text);
                MatHang mh = lstMH.Where(t => t.MaHang == id).FirstOrDefault();

                string direct = sv.Directory() + mh.HinhAnh;
                picHinhAnh.Image = sv.GetImg(direct, picHinhAnh.Width, picHinhAnh.Height);
                btnChonMatHang.Enabled = true;
            }
        }

        private void lstDSCTHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDSCTHD.SelectedItems.Count > 0)
            {
                ListViewItem item = lstDSCTHD.SelectedItems[0];

                txtMaHD.Text = item.SubItems[0].Text;
                txtMaHang.Text = item.SubItems[1].Text;
                MatHang mh = lstMH.Where(t => t.MaHang == Int32.Parse(txtMaHang.Text)).FirstOrDefault();
                maxSL = mh.TonKho;
                txtDonGia.Text = mh.GiaBan.ToString();
                txtSoLuong.Text = item.SubItems[2].Text;
                txtThanhTien.Text = item.SubItems[3].Text;

                btnXoaMatHang.Enabled = btnCapNhat.Enabled = btnThanhToan.Enabled = true;
            }
        }

        #region
        private void btnTaoHD_MouseEnter(object sender, EventArgs e)
        {
            sv.MouseEnter(btnTaoHD);
        }

        private void btnTaoHD_MouseLeave(object sender, EventArgs e)
        {
            sv.MouseLeave(btnTaoHD);
        }

        private void btnChonMatHang_MouseEnter(object sender, EventArgs e)
        {
            sv.MouseEnter(btnChonMatHang);
        }

        private void btnChonMatHang_MouseLeave(object sender, EventArgs e)
        {
            sv.MouseLeave(btnChonMatHang);
        }

        private void btnCapNhat_MouseEnter(object sender, EventArgs e)
        {
            sv.MouseEnter(btnCapNhat);
        }

        private void btnCapNhat_MouseLeave(object sender, EventArgs e)
        {
            sv.MouseLeave(btnCapNhat);
        }

        private void btnXoaMatHang_MouseEnter(object sender, EventArgs e)
        {
            sv.MouseEnter(btnXoaMatHang);
        }

        private void btnXoaMatHang_MouseLeave(object sender, EventArgs e)
        {
            sv.MouseLeave(btnXoaMatHang);
        }

        private void btnThanhToan_MouseEnter(object sender, EventArgs e)
        {
            sv.MouseEnter(btnThanhToan);
        }

        private void btnThanhToan_MouseLeave(object sender, EventArgs e)
        {
            sv.MouseLeave(btnThanhToan);
        }
        #endregion
    }
}
