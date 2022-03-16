using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_CNNET_QLCHXE.Controllers
{
    public class ThongKe : DBConnection
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        public void LoadThongKeDoanhThuTheoNgay(string ngayBan)
        {
            try
            {
                ds.Clear();
                cmd = new SqlCommand("SP_DoanhThuTrongNgay", conn);
                cmd.Parameters.Add(new SqlParameter("@NgayBan", ngayBan));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds, "tbl_ThongKeDoanhThuTheoNgay");
            }
            catch { }
        }

        public void LoadHoaDonTheoNgay(string ngayLap)
        {
            try
            {
                string date = ngayLap.Replace("12:00:00 AM", "").Trim();
                ds.Clear();
                cmd = new SqlCommand("SP_HoaDonTrongNgay", conn);
                cmd.Parameters.Add(new SqlParameter("@NgayLap", date));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds, "tbl_HoaDonTheoNgay");
            }
            catch {
                throw;
            }
        }

        public void LoadHoaDonTheoThang(string thang)
        {
            try
            {
                ds.Clear();
                cmd = new SqlCommand("SP_HoaDonTrongThang", conn);
                cmd.Parameters.Add(new SqlParameter("@Thang", thang));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds, "tbl_HoaDonTheoThang");
            }
            catch { }
        }

        public DataTable GetTable(string tblName)
        {
            return ds.Tables[tblName];
        }
    }
}
