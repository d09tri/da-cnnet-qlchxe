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
    public class MatHangController : DBConnection
    {
        SqlDataAdapter daXe = new SqlDataAdapter();
        SqlDataAdapter daBH = new SqlDataAdapter();
        SqlDataAdapter daDetail = new SqlDataAdapter();
        SqlDataAdapter daKN = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Services sv = new Services();

        public MatHangController()
        {
            LoadMatHang();
            LoadDetail();
            LoadBanHang();
        }

        public void LoadMatHang()
        {
            string sql = "select * from MatHang";
            daXe = new SqlDataAdapter(sql, conn);
            daXe.Fill(ds, "tbl_MatHang");
            sv.SetPrimaryKey(ds, "tbl_MatHang");
            sv.SetIdentity(ds, "tbl_MatHang", "MaHang");
        }

        public void LoadBanHang()
        {
            string sql = "select * from MatHang mh, NhaSanXuat nsx where mh.MaNSX = nsx.MaNSX and mh.TonKho > 10";
            daBH = new SqlDataAdapter(sql, conn);
            daBH.Fill(ds, "tbl_BanHang");
            sv.SetPrimaryKey(ds, "tbl_BanHang");
            sv.SetIdentity(ds, "tbl_BanHang", "MaHang");
        }

        public void LoadDetail()
        {
            string sql = "select * from MatHang, NhaSanXuat where MatHang.MaNSX = NhaSanXuat.MaNSX";
            daDetail = new SqlDataAdapter(sql, conn);
            daDetail.Fill(ds, "tbl_Detail");
            sv.SetPrimaryKey(ds, "tbl_Detail");
        }

        public DataTable TableXe()
        {
            return ds.Tables["tbl_MatHang"];
        }

        public DataTable TableXeBH()
        {
            return ds.Tables["tbl_BanHang"];
        }

        public DataRow FindRow(string id)
        {
            DataRow row = ds.Tables["tbl_Detail"].Rows.Find(id);
            return row;
        }

        public List<MatHang> TimKiemMatHang(string ten)
        {
            List<MatHang> l = new List<MatHang>();
            foreach (DataRow row in ds.Tables["tbl_MatHang"].Rows)
            {
                string tenXe = row.ItemArray[1].ToString().Trim();
                if (tenXe.ToLower().Contains(ten.ToLower()))
                {
                    int id = int.Parse(row.ItemArray[0].ToString());
                    string img = row.ItemArray[5].ToString();
                    MatHang c = new MatHang(id, tenXe, img);
                    l.Add(c);
                }
            }
            return l;
        }

        public bool ThemMatHang(MatHang c)
        {
            try
            {
                /*
                string sql = "insert into MatHang values (@TenHang, @MaNSX, @GiaBan, @TonKho, @HinhAnh)";
                da.InsertCommand = new SqlCommand(sql, conn);
                da.InsertCommand.Parameters.Add("@TenHang", SqlDbType.NVarChar).Value = c.TenHang;
                da.InsertCommand.Parameters.Add("@MaNSX", SqlDbType.Int).Value = c.MaNSX;
                da.InsertCommand.Parameters.Add("@GiaBan", SqlDbType.Int).Value = c.GiaBan;
                da.InsertCommand.Parameters.Add("@TonKho", SqlDbType.Int).Value = c.TonKho;
                da.InsertCommand.Parameters.Add("@HinhAnh", SqlDbType.VarChar).Value = c.HinhAnh;
                 
                conn.Open();
                da.InsertCommand.ExecuteNonQuery();
                conn.Close();
                */

                DataRow r = ds.Tables["tbl_MatHang"].NewRow();
                r["TenHang"] = c.TenHang;
                r["MaNSX"] = c.MaNSX;
                r["GiaBan"] = c.GiaBan;
                r["TonKho"] = c.TonKho;
                r["HinhAnh"] = c.HinhAnh;

                ds.Tables["tbl_MatHang"].Rows.Add(r);
                sv.UpdateTable(ds, daXe, "tbl_MatHang");

                ds.Tables["tbl_MatHang"].Rows.Clear();
                ds.Tables["tbl_Detail"].Rows.Clear();
                ds.Tables["tbl_BanHang"].Rows.Clear();

                LoadMatHang();
                LoadDetail();
                LoadBanHang();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SuaMatHang(MatHang c)
        {
            try
            {
                /*
                string sql = "update MatHang set TenHang = @TenHang, MaNSX = @MaNSX, GiaBan = @GiaBan, TonKho = @TonKho, HinhAnh = @HinhAnh where MaHang = @MaHang ";
                da1.UpdateCommand = new SqlCommand(sql, conn);
                da1.UpdateCommand.Parameters.Add("@TenHang", SqlDbType.NVarChar).Value = c.TenHang;
                da1.UpdateCommand.Parameters.Add("@MaNSX", SqlDbType.Int).Value = c.MaNSX;
                da1.UpdateCommand.Parameters.Add("@GiaBan", SqlDbType.Int).Value = c.GiaBan;
                da1.UpdateCommand.Parameters.Add("@TonKho", SqlDbType.Int).Value = c.TonKho;
                da1.UpdateCommand.Parameters.Add("@HinhAnh", SqlDbType.VarChar).Value = c.HinhAnh;
                da1.UpdateCommand.Parameters.Add("@MaHang", SqlDbType.Int).Value = c.MaHang;
                
                conn.Open();
                da1.UpdateCommand.ExecuteNonQuery();
                conn.Close();
                */

                DataRow r = ds.Tables["tbl_MatHang"].Rows.Find(c.MaHang);
                r["TenHang"] = c.TenHang;
                r["MaNSX"] = c.MaNSX;
                r["GiaBan"] = c.GiaBan;
                r["TonKho"] = c.TonKho;
                r["HinhAnh"] = c.HinhAnh;

                daXe = new SqlDataAdapter("select * from MatHang", conn);
                daDetail = new SqlDataAdapter("select * from MatHang, NhaSanXuat where MatHang.MaNSX = NhaSanXuat.MaNSX", conn);
                daBH = new SqlDataAdapter("select * from MatHang mh, NhaSanXuat nsx where mh.MaNSX = nsx.MaNSX and mh.TonKho > 10", conn);
                
                sv.UpdateTable(ds, daXe, "tbl_MatHang");
                sv.UpdateTable(ds, daDetail, "tbl_Detail");
                sv.UpdateTable(ds, daBH, "tbl_BanHang");

                LoadMatHang();
                LoadDetail();
                LoadBanHang();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaMatHang(int maHang)
        {
            try
            {
                /*
                string sql = "delete from MatHang where MaHang = @MaHang";
                da1.DeleteCommand = new SqlCommand(sql, conn);
                da1.DeleteCommand.Parameters.Add("@MaHang", SqlDbType.Int).Value = maHang;

                conn.Open();
                da1.DeleteCommand.ExecuteNonQuery();
                conn.Close();
                */

                DataRow r = ds.Tables["tbl_MatHang"].Rows.Find(maHang);
                r.Delete();

                daXe = new SqlDataAdapter("select * from MatHang", conn);
                daDetail = new SqlDataAdapter("select * from MatHang, NhaSanXuat where MatHang.MaNSX = NhaSanXuat.MaNSX", conn);
                daBH = new SqlDataAdapter("select * from MatHang mh, NhaSanXuat nsx where mh.MaNSX = nsx.MaNSX and mh.TonKho > 10", conn);

                sv.UpdateTable(ds, daXe, "tbl_MatHang");
                sv.UpdateTable(ds, daDetail, "tbl_Detail");
                sv.UpdateTable(ds, daBH, "tbl_BanHang");

                LoadMatHang();
                LoadDetail();
                LoadBanHang();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool KiemTraKhoaNgoai(int maHang)
        {
            string cmd = "select * from ChiTietHoaDonBan where MaHang = '" + maHang + "'";
            daKN = new SqlDataAdapter(cmd, conn);
            DataTable dt = new DataTable();
            daKN.Fill(dt);

            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}
