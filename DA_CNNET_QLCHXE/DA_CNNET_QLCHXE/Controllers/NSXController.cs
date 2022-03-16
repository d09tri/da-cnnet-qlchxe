using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_CNNET_QLCHXE.Controllers
{
    public class NSXController : DBConnection
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Services sv = new Services();

        public NSXController()
        {
            LoadNSX();
        }

        public void LoadNSX()
        {
            string sql = "select * from NhaSanXuat";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "tbl_NhaSanXuat");
            sv.SetPrimaryKey(ds, "tbl_NhaSanXuat");
        }

        public DataTable TableNSX()
        {
            return ds.Tables["tbl_NhaSanXuat"];
        }


    }
}
