using DA_CNNET_QLCHXE.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_CNNET_QLCHXE.Controllers
{
    public class HoaDonBanController : DBConnection
    {
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataAdapter daHD = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Services sv = new Services();

        public HoaDonBanController()
        {
            LoadHoaDonBan();
            LoadHoaDonBanCC();
        }

        public void LoadHoaDonBan()
        {
            string sql = "select * from HoaDonBan";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "tbl_HoaDonBan");
            sv.SetPrimaryKey(ds, "tbl_HoaDonBan");
            sv.SetIdentity(ds, "tbl_HoaDonBan", "MaHD");
        }

        public void LoadHoaDonBanCC()
        {
            string sql = "select top 1 * from HoaDonBan order by MaHD desc";
            daHD = new SqlDataAdapter(sql, conn);
            daHD.Fill(ds, "tbl_HoaDonBanCC");
            sv.SetPrimaryKey(ds, "tbl_HoaDonBanCC");
        }

        public DataRow LayHoaDonBanCC()
        {
            DataRow r;
            DataTable dt = ds.Tables["tbl_HoaDonBanCC"];
            if (dt.Rows.Count > 0)
            {
                return r = dt.Rows[0];
            }
            return null;
        }

        public HoaDonBan LayThongTinHoaDon(int maHD)
        {
            try
            {
                DataRow r = ds.Tables["tbl_HoaDonBan"].Rows.Find(maHD);
                HoaDonBan hd = new HoaDonBan(Int32.Parse(r["MaNV"].ToString()), Int32.Parse(r["MaKH"].ToString()), DateTime.Parse(r["NgayBan"].ToString()), Int32.Parse(r["TriGia"].ToString()), r["TinhTrang"].ToString());
                hd.MaHD = maHD;
                return hd;
            }
            catch
            {
                return null;
            }
        }

        public DataTable TableHoaDonBan()
        {
            return ds.Tables["tbl_HoaDonBan"];
        }
        
        public bool ThemHoaDonBan(HoaDonBan hd)
        {
            try
            {
                DataRow r = ds.Tables["tbl_HoaDonBan"].NewRow();
                r["MaNV"] = hd.MaNV;
                r["MaKH"] = hd.MaKH;
                r["NgayBan"] = hd.NgayBan;
                r["TriGia"] = hd.TriGia;
                r["TinhTrang"] = hd.TinhTrang;

                ds.Tables["tbl_HoaDonBan"].Rows.Add(r);
                sv.UpdateTable(ds, da, "tbl_HoaDonBan");
                sv.UpdateTable(ds, daHD, "tbl_HoaDonBanCC");

                ds.Tables["tbl_HoaDonBan"].Rows.Clear();
                ds.Tables["tbl_HoaDonBanCC"].Rows.Clear();

                LoadHoaDonBan();
                LoadHoaDonBanCC();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SuaHoaDonBan(HoaDonBan hd)
        {
            try
            {
                DataRow r = ds.Tables["tbl_HoaDonBan"].Rows.Find(hd.MaHD);
                r["MaNV"] = hd.MaNV;
                r["MaKH"] = hd.MaKH;
                r["NgayBan"] = hd.NgayBan;
                r["TriGia"] = hd.TriGia;
                r["TinhTrang"] = hd.TinhTrang;

                da = new SqlDataAdapter("select * from HoaDonBan", conn);
                sv.UpdateTable(ds, da, "tbl_HoaDonBan");

                LoadHoaDonBan();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SuaTinhTrangHoaDon(int maHD, string tinhTrang)
        {
            try
            {
                DataRow r = ds.Tables["tbl_HoaDonBan"].Rows.Find(maHD);
                r["TinhTrang"] = tinhTrang;

                da = new SqlDataAdapter("select * from HoaDonBan", conn);
                sv.UpdateTable(ds, da, "tbl_HoaDonBan");

                LoadHoaDonBan();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaHoaDonBan(int maHD)
        {
            try
            {
                DataRow r = ds.Tables["tbl_HoaDonBan"].Rows.Find(maHD);
                r.Delete();

                da = new SqlDataAdapter("select * from HoaDonBan", conn);
                sv.UpdateTable(ds, da, "tbl_HoaDonBan");

                LoadHoaDonBan();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
