using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_CNNET_QLCHXE.Models
{
    public class ChiTietHoaDonBan
    {
        public int MaHD { get; set; }
        public int MaHang { get; set; }
        public int SoLuong { get; set; }
        public int ThanhTien { get; set; }

        public ChiTietHoaDonBan() { }

        public ChiTietHoaDonBan(int maHD, int maHang, int soLuong, int thanhTien)
        {
            MaHD = maHD;
            MaHang = maHang;
            SoLuong = soLuong;
            ThanhTien = thanhTien;
        }
    }
}
