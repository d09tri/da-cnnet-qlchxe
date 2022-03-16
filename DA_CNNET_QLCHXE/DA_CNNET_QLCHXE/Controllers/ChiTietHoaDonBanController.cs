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
    public class ChiTietHoaDonBanController : DBConnection
    {
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataAdapter daTK = new SqlDataAdapter();
        SqlDataAdapter daKT = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Services sv = new Services();

        public ChiTietHoaDonBanController()
        {
            LoadCTHD();
        }

        public void LoadCTHD()
        {
            string sql = "select * from ChiTietHoaDonBan";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "tbl_ChiTietHoaDonBan");

            DataColumn[] key = new DataColumn[2];
            key[0] = ds.Tables["tbl_ChiTietHoaDonBan"].Columns[0];
            key[1] = ds.Tables["tbl_ChiTietHoaDonBan"].Columns[1];
            ds.Tables["tbl_ChiTietHoaDonBan"].PrimaryKey = key;
        }

        public void LoadCTHDTimKiem(int maHD)
        {
            string sql = "select cthd.*, mh.TenHang from ChiTietHoaDonBan cthd, MatHang mh where mh.MaHang = cthd.MaHang and MaHD = " + maHD + "";
            daTK = new SqlDataAdapter(sql, conn);
            daTK.Fill(ds, "tbl_TimKiem");

            DataColumn[] key = new DataColumn[2];
            key[0] = ds.Tables["tbl_TimKiem"].Columns[0];
            key[1] = ds.Tables["tbl_TimKiem"].Columns[1];
            ds.Tables["tbl_TimKiem"].PrimaryKey = key;
        }

        public DataTable TableTimKiem()
        {
            return ds.Tables["tbl_TimKiem"];
        }

        public bool ThemCTHD(ChiTietHoaDonBan cthd)
        {
            try
            {
                DataRow r = ds.Tables["tbl_ChiTietHoaDonBan"].NewRow();
                r["MaHD"] = cthd.MaHD;
                r["MaHang"] = cthd.MaHang;
                r["SoLuong"] = cthd.SoLuong;
                r["ThanhTien"] = cthd.ThanhTien;

                ds.Tables["tbl_ChiTietHoaDonBan"].Rows.Add(r);
                sv.UpdateTable(ds, da, "tbl_ChiTietHoaDonBan");

                ds.Tables["tbl_ChiTietHoaDonBan"].Rows.Clear();

                LoadCTHD();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SuaCTHD(ChiTietHoaDonBan cthd)
        {
            try
            {
                object[] key = new object[2];
                key[0] = cthd.MaHD;
                key[1] = cthd.MaHang;

                DataRow r = ds.Tables["tbl_ChiTietHoaDonBan"].Rows.Find(key);
                r["SoLuong"] = cthd.SoLuong;
                r["ThanhTien"] = cthd.ThanhTien;

                da = new SqlDataAdapter("select * from ChiTietHoaDonBan", conn);
                sv.UpdateTable(ds, da, "tbl_ChiTietHoaDonBan");

                LoadCTHD();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaCTHD(int maHD, int maHang)
        {
            try
            {
                object[] key = new object[2];
                key[0] = maHD;
                key[1] = maHang;
                DataRow r = ds.Tables["tbl_ChiTietHoaDonBan"].Rows.Find(maHD);
                r.Delete();

                da = new SqlDataAdapter("select * from ChiTietHoaDonBan", conn);
                sv.UpdateTable(ds, da, "tbl_ChiTietHoaDonBan");

                LoadCTHD();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool KiemTraTonTai(int maHDKT)
        {
            string cmd = "select * from ChiTietHoaDonBan where MaHD = '" + maHDKT + "'";
            daKT = new SqlDataAdapter(cmd, conn);
            DataTable dt = new DataTable();
            daKT.Fill(dt);

            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}
