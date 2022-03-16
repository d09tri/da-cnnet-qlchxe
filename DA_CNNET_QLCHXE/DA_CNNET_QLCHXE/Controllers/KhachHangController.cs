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
    public class KhachHangController : DBConnection
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Services sv = new Services();

        public KhachHangController()
        {
            LoadKhachHang();
        }

        public void LoadKhachHang()
        {
            string sql = "select * from KhachHang";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "tbl_KhachHang");
            sv.SetPrimaryKey(ds, "tbl_KhachHang");
            sv.SetIdentity(ds, "tbl_KhachHang", "MaKH");
        }

        public DataTable TableKhachHang()
        {
            return ds.Tables["tbl_KhachHang"];
        }

        public bool ThemKhachHang(KhachHang kh)
        {
            try
            {
                DataRow r = ds.Tables["tbl_KhachHang"].NewRow();
                r["TenKH"] = kh.TenKH;
                r["DiaChi"] = kh.DiaChi;
                r["DienThoai"] = kh.DienThoai;
                r["Email"] = kh.Email;

                ds.Tables["tbl_KhachHang"].Rows.Add(r);
                sv.UpdateTable(ds, da, "tbl_KhachHang");

                ds.Tables["tbl_KhachHang"].Rows.Clear();

                LoadKhachHang();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SuaKhachHang(KhachHang kh)
        {
            try
            {
                DataRow r = ds.Tables["tbl_KhachHang"].Rows.Find(kh.MaKH);
                r["TenKH"] = kh.TenKH;
                r["DiaChi"] = kh.DiaChi;
                r["DienThoai"] = kh.DienThoai;
                r["Email"] = kh.Email;

                da = new SqlDataAdapter("select * from KhachHang", conn);
                sv.UpdateTable(ds, da, "tbl_KhachHang");

                LoadKhachHang();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaKhachHang(int maKH)
        {
            try
            {
                DataRow r = ds.Tables["tbl_KhachHang"].Rows.Find(maKH);
                r.Delete();

                da = new SqlDataAdapter("select * from KhachHang", conn);
                sv.UpdateTable(ds, da, "tbl_KhachHang");

                LoadKhachHang();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string LayTenKhachHang(int maKH)
        {
            try
            {
                DataRow r = ds.Tables["tbl_KhachHang"].Rows.Find(maKH);
                return r["TenKH"].ToString();
            }
            catch
            {
                return "null";
            }
        }

        public bool KiemTraKhoaNgoai(int maKH)
        {
            string cmd = "select * from HoaDonBan where MaKh = '" + maKH + "'";
            da = new SqlDataAdapter(cmd, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}
