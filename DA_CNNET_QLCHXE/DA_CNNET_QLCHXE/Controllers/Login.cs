using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_CNNET_QLCHXE.Controllers
{
    public class Login : DBConnection
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Services sv = new Services();
        public Login()
        {
            LoadAcc();
        }

        public void LoadAcc()
        {
            string sql = "select * from QuanTriVien";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "tbl_QuanTriVien");
            sv.SetPrimaryKey(ds, "tbl_QuanTriVien");
        }
        public void LoginAccount(string username, string password, Form f)
        {
            DataRow row = ds.Tables["tbl_QuanTriVien"].Rows.Find(username);
            if (row == null)
            {
                MessageBox.Show("Không tồn tại tài khoản này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string pass = row.ItemArray[1].ToString();
                int id = Int32.Parse(row.ItemArray[2].ToString());
                string hash = sv.Hash(password);

                if (hash.Trim().Equals(pass.Trim()))
                {
                    f.Visible = false;
                    string role = row.ItemArray[3].ToString();
                    if (role.Trim().Equals("Admin"))
                    {
                        FrmAdmin frmAdm = new FrmAdmin(id, username);
                        frmAdm.Show();
                    }
                    else
                    {
                        FrmDashboard frmDb = new FrmDashboard(id, username);
                        frmDb.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
