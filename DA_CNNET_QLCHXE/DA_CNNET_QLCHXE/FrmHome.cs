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
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
            LoadTable();
        }

        MatHangController c = new MatHangController();
        Services sv = new Services();

        public Panel PanelProduct(string direct, string productName, string id)
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(210, 220);
            pnl.Margin = new Padding(5);

            PictureBox pic = new PictureBox();
            pic.Height = 180;
            pic.Width = 200;
            pic.Image = sv.GetImg(direct, 200, 180);
            pic.Location = new Point(0, 0);

            Label lblId = new Label();
            lblId.Size = new Size(100, 22);
            lblId.ForeColor = Color.FromArgb(255, 255, 255);
            lblId.Font = new Font("Microsoft Sans Serif", 12);
            lblId.Text = "ID: " + id;
            lblId.Location = new Point(0, 180);

            LinkLabel lblName = new LinkLabel();
            lblName.TextAlign = ContentAlignment.BottomCenter;
            lblName.Size = new Size(150, 40);
            lblName.Font = new Font("Microsoft Sans Serif", 12);
            lblName.LinkColor = Color.FromArgb(255, 255, 255);
            lblName.AutoSize = true;
            lblName.Text = productName;
            lblName.Location = new Point(0, 200);
            lblName.Click += new EventHandler((s, e) => Detail(s, e, id));

            pnl.Controls.Add(pic);
            pnl.Controls.Add(lblId);
            pnl.Controls.Add(lblName);

            return pnl;
        }

        public void Detail(object sender, EventArgs e, string id)
        {
            Panel pnl = this.Parent as Panel;
            pnl.Controls.Clear();

            sv.LoadChildForm(new FrmDetail(id), pnl);
        }

        public void LoadTable()
        {
            DataTable dt = c.TableXe();
            foreach (DataRow row in dt.Rows)
            {
                string id = row.ItemArray[0].ToString();
                string ten = row.ItemArray[1].ToString();
                string direct = sv.Directory() + row.ItemArray[5].ToString();
                Panel pnl = PanelProduct(direct, ten, id);
                flwDanhSachXe.Controls.Add(pnl);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tenXe = txtTimKiem.Text;
            if (tenXe.Length > 0)
            {
                List<MatHang> lst = c.TimKiemMatHang(tenXe);
                flwDanhSachXe.Controls.Clear();
                foreach (MatHang car in lst)
                {
                    string id = car.MaHang.ToString();
                    string ten = car.TenHang;
                    string direct = sv.Directory() + car.HinhAnh;

                    Panel pnl = PanelProduct(direct, ten, id);
                    flwDanhSachXe.Controls.Add(pnl);
                }
            }
            if (tenXe.Length == 0)
            {
                Panel pnl = this.Parent as Panel;
                pnl.Controls.Clear();

                sv.LoadChildForm(new FrmHome(), pnl);
            }
        }
    }
}
