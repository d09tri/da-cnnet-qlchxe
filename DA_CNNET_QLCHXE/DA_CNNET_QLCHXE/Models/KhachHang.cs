using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_CNNET_QLCHXE.Models
{
    public class KhachHang
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }

        public KhachHang() {  }

        public KhachHang(string tenKH, string diaChi, string dienThoai, string email)
        {
            TenKH = tenKH;
            DiaChi = diaChi;
            DienThoai = dienThoai;
            Email = email;
        }
    }
}
