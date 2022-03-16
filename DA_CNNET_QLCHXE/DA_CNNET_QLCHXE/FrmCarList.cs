using DA_CNNET_QLCHXE.Controllers;
using DA_CNNET_QLCHXE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_CNNET_QLCHXE
{
    public partial class FrmCarList : Form
    {
        // Chuyển sang giao diện Quản trị viên //
        public FrmCarList()
        {
            InitializeComponent();
        }

        Services sv = new Services();
        MatHangController c = new MatHangController();
        NSXController nsx = new NSXController();
        string tt = "Mac dinh";
        string ha = "Mac dinh";

        private void FrmCarList_Load(object sender, EventArgs e)
        {
            LoadListView();
            pnlMain.Controls.OfType<TextBox>().ToList().ForEach(t => t.Enabled = false);
            cboNSX.Enabled = false;

            btnSua.Enabled = btnXoa.Enabled = btnLuu.Enabled = false;
        }

        public void LoadListView()
        {
            lstDSXe.Items.Clear();
            DataTable dtc = c.TableXe();
            foreach (DataRow row in dtc.Rows)
            {
                string maHang = row.ItemArray[0].ToString();
                string tenHang = row.ItemArray[1].ToString();
                string maNSX = row.ItemArray[2].ToString();
                string giaBan = row.ItemArray[3].ToString();
                string tonKho = row.ItemArray[4].ToString();
                string hinhAnh = row.ItemArray[5].ToString();

                ListViewItem item = new ListViewItem(new[] { maHang, tenHang, maNSX, giaBan, tonKho, hinhAnh });
                lstDSXe.Items.Add(item);
            }

            cboNSX.DataSource = nsx.TableNSX();
            cboNSX.DisplayMember = "TenNSX";
            cboNSX.ValueMember = "MaNSX";
        }

        private void lstDSXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDSXe.SelectedItems.Count > 0)
            {
                ListViewItem item = lstDSXe.SelectedItems[0];
                txtMaHang.Text = item.SubItems[0].Text;
                txtTenHang.Text = item.SubItems[1].Text;
                cboNSX.SelectedValue = item.SubItems[2].Text;
                txtGiaBan.Text = item.SubItems[3].Text;
                txtTonKho.Text = item.SubItems[4].Text;
                txtHinhAnh.Text = item.SubItems[5].Text;

                string direct = sv.Directory() + item.SubItems[5].Text;
                picHinhAnh.Image = sv.GetImg(direct, picHinhAnh.Width, picHinhAnh.Height);

                btnSua.Enabled = btnXoa.Enabled = true;
            }
        }

        private void btnHinhAnh_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp, *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png ";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picHinhAnh.Image = new Bitmap(openFileDialog.FileName);
                txtHinhAnh.Text = openFileDialog.SafeFileName;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = cboNSX.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            cboNSX.SelectedIndex = 0;
            picHinhAnh.Image = null;

            lstDSXe.SelectedIndices.Clear();
            pnlMain.Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
            pnlMain.Controls.OfType<TextBox>().Where(t => t != txtMaHang && t != txtHinhAnh).ToList().ForEach(t => t.Enabled = true);
            lstDSXe.Enabled = false;
            tt = "Them";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lstDSXe.SelectedItems.Count > 0)
            {
                DialogResult r = MessageBox.Show("Xác nhận xoá", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    if (c.KiemTraKhoaNgoai(Int32.Parse(txtMaHang.Text)))
                    {
                        MessageBox.Show("Không thể xoá xe này", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        try
                        {
                            c.XoaMatHang(Int32.Parse(txtMaHang.Text));
                            MessageBox.Show("Xoá xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            cboNSX.Enabled = btnXoa.Enabled = false;

                            lstDSXe.SelectedIndices.Clear();
                            pnlMain.Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
                            pnlMain.Controls.OfType<TextBox>().Where(t => t != txtMaHang).ToList().ForEach(t => t.Enabled = false);
                            picHinhAnh.Image = null;
                            cboNSX.SelectedIndex = 0;

                            LoadListView();
                        }
                        catch
                        {
                            MessageBox.Show("Xoá xe thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = cboNSX.Enabled = true;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = false;

            lstDSXe.SelectedIndices.Clear();
            pnlMain.Controls.OfType<TextBox>().Where(t => t != txtMaHang && t != txtHinhAnh).ToList().ForEach(t => t.Enabled = true);
            lstDSXe.Enabled = false;

            tt = "Sua";
            ha = txtHinhAnh.Text;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (pnlMain.Controls.OfType<TextBox>().Where(t => t != txtMaHang).Any(t => t.Text.Length == 0))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (tt == "Them")
                {
                    string fileName = openFileDialog.FileName;
                    if (fileName == "")
                    {
                        MessageBox.Show("Vui lòng chọn hình ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MatHang car = new MatHang(txtTenHang.Text, Int32.Parse(cboNSX.SelectedValue.ToString()),
                            Int32.Parse(txtGiaBan.Text), Int32.Parse(txtTonKho.Text),
                            openFileDialog.SafeFileName.ToString());
                        if (c.ThemMatHang(car))
                        {
                            /* Lỗi IO:
                             * - Khi thêm hình ảnh lấy từ folder Images của thư mục của DA_CNNET_QLCHXE phát sinh lỗi do thằng
                             *   function Directory trong class Services đang được sử dụng để làm đường dẫn lưu file hình ảnh.
                             *   
                             * Khắc phục:
                             * - Kiểm tra nếu hình ảnh chuẩn bị lưu, nếu được lấy trong folder Images của thư mục DA_CNNET_QLCHXE 
                             *   thì không cần thiết phải lưu lại làm gì, trường hợp ngược lại cứ tiến hành các bước như mọi khi.
                             * 
                             * Link:
                             * - https://stackoverflow.com/questions/26741191/ioexception-the-process-cannot-access-the-file-file-path-because-it-is-being 
                             */
                            string str = sv.Directory().Substring(0, sv.Directory().Length - 1) + "\\" + openFileDialog.SafeFileName.ToString();
                            if (str != fileName)
                            {
                                File.Copy(fileName, Path.Combine(sv.Directory(), Path.GetFileName(fileName)), true);
                            }

                            MessageBox.Show("Thêm xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadListView();
                        }
                        else
                        {
                            MessageBox.Show("Thêm xe thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                if (tt == "Sua")
                {
                    MatHang car = new MatHang(txtTenHang.Text, Int32.Parse(cboNSX.SelectedValue.ToString()),
                        Int32.Parse(txtGiaBan.Text), Int32.Parse(txtTonKho.Text),
                        "Mac dinh");
                    car.MaHang = Int32.Parse(txtMaHang.Text);

                    if (ha.Equals(txtHinhAnh.Text))
                    {
                        car.HinhAnh = ha;
                    }
                    else
                    {
                        string fileName = openFileDialog.FileName;
                        if (fileName == "")
                        {
                            MessageBox.Show("Vui lòng chọn hình ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            car.HinhAnh = openFileDialog.SafeFileName.ToString();
                            string str = sv.Directory().Substring(0, sv.Directory().Length - 1) + "\\" + openFileDialog.SafeFileName.ToString();
                            if (str != fileName)
                            {
                                File.Copy(fileName, Path.Combine(sv.Directory(), Path.GetFileName(fileName)), true);
                            }
                        }
                    }

                    if (c.SuaMatHang(car))
                    {

                        MessageBox.Show("Sửa xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadListView();
                    }
                    else
                    {
                        MessageBox.Show("Sửa xe thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            lstDSXe.SelectedIndices.Clear();
            lstDSXe.Enabled = true;
            pnlMain.Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
            pnlMain.Controls.OfType<TextBox>().Where(t => t != txtMaHang && t != txtHinhAnh).ToList().ForEach(t => t.Enabled = false);
            picHinhAnh.Image = null;
            cboNSX.SelectedIndex = 0;

            btnThem.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = btnLuu.Enabled = cboNSX.Enabled = false;
            tt = "Mac dinh";
        }

        FormWindowState LastWindowState = FormWindowState.Minimized;
        private void FrmCarList_Resize(object sender, EventArgs e)
        {
            if (WindowState != LastWindowState)
            {
                LastWindowState = WindowState;

                if (WindowState == FormWindowState.Maximized)
                {
                    lstDSXe.Columns[5].Width = 230;
                }
                if (WindowState == FormWindowState.Normal)
                {
                    lstDSXe.Columns[5].Width = 180;
                }
            }
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtTonKho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
