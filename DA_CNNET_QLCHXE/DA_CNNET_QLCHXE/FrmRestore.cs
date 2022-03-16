using DA_CNNET_QLCHXE.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_CNNET_QLCHXE
{
    public partial class FrmRestore : Form
    {
        DBConnection db = new DBConnection();
        public FrmRestore()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (prgBar.Value < 100)
            {
                prgBar.Value += 1;
                prgBar.Refresh();
                lblStatus.Text = "Status: " + prgBar.Value + "%";
            }
            else
            {
                timer.Enabled = false;
                lblStatus.Text = "Status: Restore thành công";
                MessageBox.Show("Hệ thống sẽ đóng sau 3s", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                Thread.Sleep(3000);

                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();

                Panel pnl = this.Parent as Panel;
                pnl.Controls.Clear();
                Form frm = pnl.Parent as Form;
                frm.Close();                
            }
        }

        public void AnimateProgressBar(int mil)
        {
            if (timer.Enabled) return;

            prgBar.Value = 0;
            timer.Interval = mil / 100;
            timer.Enabled = true;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Backup files(*.bak)|*.bak";
            dlg.Title = "Restore";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = dlg.FileName;
                btnRestore.Enabled = true;
            }
        }

        private async void btnRestore_Click(object sender, EventArgs e)
        {
            string database = db.conn.Database.ToString();
            db.conn.Open();

            try
            {
                string sql1 = "ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                SqlCommand cmd1 = new SqlCommand(sql1, db.conn);
                cmd1.ExecuteNonQuery();

                AnimateProgressBar(6500);

                string sql2 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK = '"+txtFilePath.Text+"' WITH REPLACE;";
                SqlCommand cmd2 = new SqlCommand(sql2, db.conn);
                await cmd2.ExecuteNonQueryAsync();

                string sql3 = "ALTER DATABASE [" + database + "] SET MULTI_USER;";
                SqlCommand cmd3 = new SqlCommand(sql3, db.conn);
                cmd3.ExecuteNonQuery();
                db.conn.Close();
            }
            catch { }
        }
    }
}
