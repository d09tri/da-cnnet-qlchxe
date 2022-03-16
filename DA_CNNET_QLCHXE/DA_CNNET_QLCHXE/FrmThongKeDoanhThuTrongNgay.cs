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
    public partial class FrmThongKeDoanhThuTrongNgay : Form
    {
        ThongKe tk = new ThongKe();
        public FrmThongKeDoanhThuTrongNgay()
        {
            InitializeComponent();
            chartThongKe.ChartAreas["AreaDoanhThu"].AxisX.Title = "Tên hàng";
            chartThongKe.ChartAreas["AreaDoanhThu"].AxisY.Title = "Thành tiền";

            chartThongKe.ChartAreas["AreaSoLuong"].AxisX.Title = "Tên hàng";
            chartThongKe.ChartAreas["AreaSoLuong"].AxisY.Title = "Số lượng";

            chartThongKe.Series["ThongKeDoanhThu"].XValueMember = "TenHang";
            chartThongKe.Series["ThongKeDoanhThu"].YValueMembers = "ThanhTien";

            chartThongKe.Series["ThongKeSoLuong"].XValueMember = "TenHang";
            chartThongKe.Series["ThongKeSoLuong"].YValueMembers = "SoLuong";

            dtpNgayBan.MaxDate = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var series in chartThongKe.Series)
            {
                series.Points.Clear();
            }

            tk.LoadThongKeDoanhThuTheoNgay(dtpNgayBan.Text);
            DataTable dt = tk.GetTable("tbl_ThongKeDoanhThuTheoNgay");
            
            foreach (DataRow r in dt.Rows)
            {
                chartThongKe.Series["ThongKeDoanhThu"].Points.AddXY(r["TenHang"], r["ThanhTien"]);
                chartThongKe.Series["ThongKeSoLuong"].Points.AddXY(r["TenHang"], r["SoLuong"]);
            }
        }
    }
}
