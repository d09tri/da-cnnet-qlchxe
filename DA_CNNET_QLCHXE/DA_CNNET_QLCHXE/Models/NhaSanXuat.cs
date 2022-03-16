using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_CNNET_QLCHXE.Models
{
    public class NhaSanXuat
    {
        public int MaNSX { get; set; }
        public string TenNSX { get; set; }
        public string XuatXu { get; set; }

        public NhaSanXuat() { }

        public NhaSanXuat(string tenNSX, string xuatXu)
        {
            this.TenNSX = tenNSX;
            this.XuatXu = xuatXu;
        }
    }
}
