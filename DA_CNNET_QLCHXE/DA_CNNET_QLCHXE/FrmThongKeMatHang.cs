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
    public partial class FrmThongKeMatHang : Form
    {
        public FrmThongKeMatHang()
        {
            InitializeComponent();
        }

        Services sv = new Services();
        MatHangController mh = new MatHangController();

        private void FrmThongKeMatHang_Load(object sender, EventArgs e)
        {
            DataTable dt = mh.TableXe();
            chartThongKeTonKho.ChartAreas["areaThongKe"].AxisX.Interval = 1;
            chartThongKeTonKho.Series["ThongKeTonKho"].XValueMember = "TenHang";
            chartThongKeTonKho.Series["ThongKeTonKho"].YValueMembers = "TonKho";

            foreach (DataRow r in dt.Rows)
            {
                chartThongKeTonKho.Series["ThongKeTonKho"].Points.AddXY(r["TenHang"], r["TonKho"]);
            }
        }


    }
}
