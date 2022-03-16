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
    public partial class FrmHoaDon : Form
    {
        public FrmHoaDon()
        {
            InitializeComponent();
        }

        Services sv = new Services();
        HoaDonBanController hd = new HoaDonBanController();

        public void SetColor(int r, int g, int b)
        {
            this.BackColor = this.pnlMain.BackColor = Color.FromArgb(r, g, b);
            this.BackColor = this.pnlHeader.BackColor = Color.FromArgb(r, g, b);
        }

        private void FrmHoaDon_Load(object sender, EventArgs e)
        {
            LoadListView();
        }

        private void LoadListView()
        {
            lstDSHoaDon.Items.Clear();
            DataTable dtc = hd.TableHoaDonBan();
            foreach (DataRow row in dtc.Rows)
            {
                string maHD = row.ItemArray[0].ToString();
                string maNV = row.ItemArray[1].ToString();
                string maKH = row.ItemArray[2].ToString();
                string ngayBan = row.ItemArray[3].ToString();
                string triGia = row.ItemArray[4].ToString();
                string tinhTrang = row.ItemArray[5].ToString();

                ListViewItem item = new ListViewItem(new[] { maHD, maNV, maKH, ngayBan, triGia, tinhTrang });
                lstDSHoaDon.Items.Add(item);
            }
        }

        private void lstDSHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnChiTietHD.Enabled = true;
        }

        private void btnChiTietHD_Click(object sender, EventArgs e)
        {
            if (lstDSHoaDon.SelectedItems.Count > 0)
            {
                int maHD = Int32.Parse(lstDSHoaDon.SelectedItems[0].SubItems[0].Text);
                Panel pnl = this.Parent as Panel;
                pnl.Controls.Clear();

                sv.LoadChildForm(new FrmChiTietHoaDon(maHD), pnl);
            }
        }

        private void lstDSHoaDon_SizeChanged(object sender, EventArgs e)
        {
            if (lstDSHoaDon.Width == 675)
            {
                lstDSHoaDon.Columns[3].Width = 180;
                lstDSHoaDon.Columns[5].Width = 180;
            }
            if (lstDSHoaDon.Width > 675)
            {
                lstDSHoaDon.Columns[3].Width = 300;
                lstDSHoaDon.Columns[5].Width = 300;

            }
        }
    }
}
