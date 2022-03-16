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
    public class NhanVienController : DBConnection
    {
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataAdapter daQTV = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Services sv = new Services();

        public NhanVienController()
        {
            LoadNhanVien();
        }

        public void LoadNhanVien()
        {
            string sql = "select * from NhanVien";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "tbl_NhanVien");
            sv.SetPrimaryKey(ds, "tbl_NhanVien");
            sv.SetIdentity(ds, "tbl_NhanVien", "MaNV");
        }

        // Thêm mới tài khoản
        public void LoadNhanVienKoLaQTV()
        {
            string sql = "select * from NhanVien where MaNV not in (select MaNV from QuanTriVien)";
            daQTV = new SqlDataAdapter(sql, conn);
            daQTV.Fill(ds, "tbl_NhanVienKoQTV");
            sv.SetPrimaryKey(ds, "tbl_NhanVienKoQTV");
        }

        public void LoadNhanVienCoTaiKhoan()
        {
            string sql = "select * from NhanVien nv, QuanTriVien qtv where nv.MaNV = qtv.MaNV and qtv.QuyenHan = 'NhanVien'";
            daQTV = new SqlDataAdapter(sql, conn);
            daQTV.Fill(ds, "tbl_NhanVienQTV");
            sv.SetPrimaryKey(ds, "tbl_NhanVienQTV");
        }

        public DataTable TableNhanVien()
        {
            return ds.Tables["tbl_NhanVien"];
        }

        public DataTable TableNhanVienKoLaQTV()
        {
            return ds.Tables["tbl_NhanVienKoQTV"];
        }

        public DataTable TableNhanVienCoTaiKhoan()
        {
            return ds.Tables["tbl_NhanVienQTV"];
        }

        public bool ThemNhanVien(NhanVien nv)
        {
            try
            {
                DataRow r = ds.Tables["tbl_NhanVien"].NewRow();
                r["TenNV"] = nv.TenNV;
                r["NgaySinh"] = nv.NgaySinh;
                r["GioiTinh"] = nv.GioiTinh;
                r["DiaChi"] = nv.DiaChi;
                r["DienThoai"] = nv.DienThoai;
                r["Email"] = nv.Email;

                ds.Tables["tbl_NhanVien"].Rows.Add(r);
                sv.UpdateTable(ds, da, "tbl_NhanVien");

                ds.Tables["tbl_NhanVien"].Rows.Clear();

                LoadNhanVien();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SuaNhanVien(NhanVien nv)
        {
            try
            {
                DataRow r = ds.Tables["tbl_NhanVien"].Rows.Find(nv.MaNV);
                r["TenNV"] = nv.TenNV;
                r["NgaySinh"] = nv.NgaySinh;
                r["GioiTinh"] = nv.GioiTinh;
                r["DiaChi"] = nv.DiaChi;
                r["DienThoai"] = nv.DienThoai;
                r["Email"] = nv.Email;

                da = new SqlDataAdapter("select * from NhanVien", conn);
                sv.UpdateTable(ds, da, "tbl_NhanVien");

                LoadNhanVien();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaNhanVien(int maNV)
        {
            try
            {
                DataRow r = ds.Tables["tbl_NhanVien"].Rows.Find(maNV);
                r.Delete();

                da = new SqlDataAdapter("select * from NhanVien", conn);
                sv.UpdateTable(ds, da, "tbl_NhanVien");

                LoadNhanVien();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string LayTenNhanVien(int maNV)
        {
            try
            {
                DataRow r = ds.Tables["tbl_NhanVien"].Rows.Find(maNV);
                return r["TenNV"].ToString();
            }
            catch
            {
                return "null";
            }
        }

        public bool KiemTraKhoaNgoai(int maNV)
        {
            string cmd = "select * from HoaDonBan where MaNV = '" + maNV + "'";
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
