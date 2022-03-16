
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_CNNET_QLCHXE.Models
{
    public class QuanTriVien
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int MaNV { get; set; }
        public string QuyenHan { get; set; }

        public QuanTriVien(string tenDangNhap, string matKhau, int maNV, string quyenHan)
        {
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            MaNV = maNV;
            QuyenHan = quyenHan;
        }
    }
}
