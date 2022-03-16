using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_CNNET_QLCHXE.Models
{
    public class MatHang
    {
        public int MaHang { get; set; }
        public string TenHang { get; set; }
        public int MaNSX { get; set; }
        public int GiaBan { get; set; }
        public int TonKho { get; set; }
        public string HinhAnh { get; set; }

        public MatHang() { }

        public MatHang(int maHang, string tenHang, string hinhAnh)
        {
            this.MaHang = maHang;
            this.TenHang = tenHang;
            this.HinhAnh = hinhAnh;
        }

        public MatHang(string tenHang, int maNSX, int giaBan, int tonKho, string hinhAnh)
        {
            this.TenHang = tenHang;
            this.MaNSX = maNSX;
            this.GiaBan = giaBan;
            this.TonKho = tonKho;
            this.HinhAnh = hinhAnh;
        }
    }
}
