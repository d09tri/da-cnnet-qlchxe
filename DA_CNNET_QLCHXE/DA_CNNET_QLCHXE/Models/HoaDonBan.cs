using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_CNNET_QLCHXE.Models
{
    public class HoaDonBan
    {
        public int MaHD { get; set; }
        public int MaNV { get; set; }
        public int MaKH { get; set; }
        public DateTime NgayBan { get; set; }
        public int TriGia { get; set; }
        public string TinhTrang { get; set; }

        public HoaDonBan() { }

        public HoaDonBan(int maNV, int maKH, DateTime ngayBan, int triGia, string tinhTrang)
        {
            MaNV = maNV;
            MaKH = maKH;
            NgayBan = ngayBan;
            TriGia = triGia;
            TinhTrang = tinhTrang;
        }


    }
}
