using DA_CNNET_QLCHXE.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_CNNET_QLCHXE
{
    public partial class FrmBackup : Form
    {
        DBConnection db = new DBConnection();
        public FrmBackup()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = dlg.SelectedPath;
                btnBackup.Enabled = true;
            }
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
                lblStatus.Text = "Status: Backup thành công";
            }
        }

        public void AnimateProgressBar(int mil)
        {
            if (timer.Enabled) return;

            prgBar.Value = 0;
            timer.Interval = mil / 100;
            timer.Enabled = true;
        }

        private async void btnBackup_Click(object sender, EventArgs e)
        {
            string database = db.conn.Database.ToString();
            if (txtFilePath.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn nơi lưu file backup", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                AnimateProgressBar(6500);

                string sql = "BACKUP DATABASE [" + database + "] TO DISK = '" + txtFilePath.Text + "\\" + database + ".bak'";
                db.conn.Open();
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                await cmd.ExecuteNonQueryAsync();
                db.conn.Close();
            }
        }
    }
}
