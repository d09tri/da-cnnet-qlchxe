
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_CNNET_QLCHXE.Controllers
{
    public class DBConnection
    {
        public SqlConnection conn = new SqlConnection("Data Source=LAPTOP-0TF3JF7G\\DANGTRI;Initial Catalog=DB_CNNET_QLCHXE;User ID=sa;Password=123");
        // public SqlConnection conn = new SqlConnection("Data Source = ADMIN; Initial Catalog = DB_CNNET_QLCHXE; Integrated Security = True");
    }
}
