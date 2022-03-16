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
    public partial class FrmDetail : Form
    {
        public FrmDetail(string id)
        {
            InitializeComponent();
            LoadData(id);
        }

        MatHangController c = new MatHangController();
        Services sv = new Services();

        public void LoadData(string id)
        {
            DataRow row = c.FindRow(id);
            string direct = sv.Directory() + row.ItemArray[5].ToString();
            picHinhAnh.Image = sv.GetImg(direct, picHinhAnh.Width, picHinhAnh.Height);
            picHinhAnh.SizeMode = PictureBoxSizeMode.CenterImage;
            lblId.Text = row.ItemArray[0].ToString();
            lblTenXe.Text = row.ItemArray[1].ToString();
            lblHang.Text = row.ItemArray[7].ToString();
            lblXuatXu.Text = row.ItemArray[8].ToString();
            lblSoLuong.Text = row.ItemArray[4].ToString();
            lblGia.Text = row.ItemArray[3].ToString() + "$";
        }

        private void btnVeHome_Click(object sender, EventArgs e)
        {
            Panel pnl = this.Parent as Panel;
            pnl.Controls.Clear();

            sv.LoadChildForm(new FrmHome(), pnl);
        }
    }
}
