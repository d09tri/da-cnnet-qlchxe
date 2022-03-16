using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace DA_CNNET_QLCHXE.Controllers
{
    public class Services
    {
        public Image GetImg(string direct, int w, int h)
        {
            Image i = Image.FromFile(direct);
            return (Image)(new Bitmap(i, new Size(w, h)));
        }

        public string Directory()
        {
            string curdirect = Environment.CurrentDirectory;
            string direct = curdirect.Substring(0, curdirect.Length - 9) + "Images/";
            return direct;
        }

        public void MouseEnter(Button btn)
        {
            btn.BackColor = Color.FromArgb(40, 65, 115);
        }

        public void MouseLeave(Button btn)
        {
            btn.BackColor = Color.FromArgb(62, 101, 179);
        }

        public bool CheckPhoneNumber(string phn)
        {
            if (phn.Length == 10 && phn.All(char.IsNumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckEmail(string email)
        {
            if (email.Trim().EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        
        public bool CheckTextInput(Panel pnl, TextBox identity)
        {
            return pnl.Controls.OfType<TextBox>().Where(t => t != identity).Any(t => t.Text.Length == 0);
        }

        public void SetPrimaryKey(DataSet ds, string tableName)
        {
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables[tableName].Columns[0];
            ds.Tables[tableName].PrimaryKey = key;
        }

        public void SetIdentity(DataSet ds, string tableName, string colName)
        {
            ds.Tables[tableName].Columns[colName].AutoIncrement = true;
        }

        public void UpdateTable(DataSet ds, SqlDataAdapter da, string tableName)
        {
            SqlCommandBuilder b = new SqlCommandBuilder(da);
            da.Update(ds, tableName);
            ds.Tables[tableName].Rows.Clear();
        }

        public void LoadChildForm(Form frm, Panel pnl)
        {
            pnl.Controls.Clear();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnl.Controls.Add(frm);
            pnl.Tag = frm;
            frm.Show();
        }

        public string Hash(string pass)
        {
            string hash = "";
            byte[] arr = Encoding.UTF8.GetBytes(pass);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            arr = md5.ComputeHash(arr);
            foreach(byte b in arr)
            {
                hash += b.ToString("X2");
            }
            return hash;
        }
    }
}
