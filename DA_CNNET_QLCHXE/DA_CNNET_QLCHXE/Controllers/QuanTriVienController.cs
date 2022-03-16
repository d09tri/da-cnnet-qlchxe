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
    public class QuanTriVienController : DBConnection
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Services sv = new Services();

        public QuanTriVienController()
        {
            LoadQuanTriVien();
        }

        public void LoadQuanTriVien()
        {
            string sql = "select * from QuanTriVien where QuyenHan = 'NhanVien'";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "tbl_QuanTriVien");
            sv.SetPrimaryKey(ds, "tbl_QuanTriVien");
        }

        public DataTable TableQuanTriVien()
        {
            return ds.Tables["tbl_QuanTriVien"];
        }

        public string MatKhau(string tenDangNhap)
        {
            DataRow r = ds.Tables["tbl_QuanTriVien"].Rows.Find(tenDangNhap);
            return r["MatKhau"].ToString();
        }

        public bool ThemQuanTriVien(QuanTriVien qtv)
        {
            try
            {
                DataRow r = ds.Tables["tbl_QuanTriVien"].NewRow();
                r["TenDangNhap"] = qtv.TenDangNhap;
                r["MatKhau"] = qtv.MatKhau;
                r["MaNV"] = qtv.MaNV;
                r["QuyenHan"] = qtv.QuyenHan;

                ds.Tables["tbl_QuanTriVien"].Rows.Add(r);
                sv.UpdateTable(ds, da, "tbl_QuanTriVien");

                ds.Tables["tbl_QuanTriVien"].Rows.Clear();

                LoadQuanTriVien();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SuaQuanTriVien(QuanTriVien qtv)
        {
            try
            {
                DataRow r = ds.Tables["tbl_QuanTriVien"].Rows.Find(qtv.TenDangNhap);
                r["MatKhau"] = qtv.MatKhau;
                r["MaNV"] = qtv.MaNV;
                r["QuyenHan"] = qtv.QuyenHan;

                da = new SqlDataAdapter("select * from QuanTriVien", conn);

                sv.UpdateTable(ds, da, "tbl_QuanTriVien");

                LoadQuanTriVien();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaQuanTriVien(string tenDangNhap)
        {
            try
            {
                DataRow r = ds.Tables["tbl_QuanTriVien"].Rows.Find(tenDangNhap);
                r.Delete();

                da = new SqlDataAdapter("select * from QuanTriVien", conn);

                sv.UpdateTable(ds, da, "tbl_QuanTriVien");

                LoadQuanTriVien();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool KiemTraTenDangNhap(string tenDangNhap)
        {
            string cmd = "select * from QuanTriVien where TenDangNhap = '" + tenDangNhap + "'";
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
