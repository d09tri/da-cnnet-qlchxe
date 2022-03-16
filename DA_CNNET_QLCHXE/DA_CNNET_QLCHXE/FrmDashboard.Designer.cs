namespace DA_CNNET_QLCHXE
{
    partial class FrmDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlSideMenu = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlThongTin = new System.Windows.Forms.Panel();
            this.btnReceipt = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnThongTin = new System.Windows.Forms.Button();
            this.btnBanHang = new System.Windows.Forms.Button();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlLoadForm = new System.Windows.Forms.Panel();
            this.pnlSideMenu.SuspendLayout();
            this.pnlThongTin.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSideMenu
            // 
            this.pnlSideMenu.AutoScroll = true;
            this.pnlSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(65)))), ((int)(((byte)(115)))));
            this.pnlSideMenu.Controls.Add(this.btnLogout);
            this.pnlSideMenu.Controls.Add(this.pnlThongTin);
            this.pnlSideMenu.Controls.Add(this.btnThongTin);
            this.pnlSideMenu.Controls.Add(this.btnBanHang);
            this.pnlSideMenu.Controls.Add(this.btnKhachHang);
            this.pnlSideMenu.Controls.Add(this.btnHome);
            this.pnlSideMenu.Controls.Add(this.pnlLogo);
            this.pnlSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlSideMenu.Name = "pnlSideMenu";
            this.pnlSideMenu.Size = new System.Drawing.Size(250, 766);
            this.pnlSideMenu.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLogout.Image = global::DA_CNNET_QLCHXE.Properties.Resources.sign_out_alt_solid;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogout.Location = new System.Drawing.Point(0, 721);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(10, 0, 25, 0);
            this.btnLogout.Size = new System.Drawing.Size(250, 45);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Log out";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlThongTin
            // 
            this.pnlThongTin.Controls.Add(this.btnReceipt);
            this.pnlThongTin.Controls.Add(this.btnHoaDon);
            this.pnlThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThongTin.Location = new System.Drawing.Point(0, 280);
            this.pnlThongTin.Name = "pnlThongTin";
            this.pnlThongTin.Size = new System.Drawing.Size(250, 90);
            this.pnlThongTin.TabIndex = 5;
            // 
            // btnReceipt
            // 
            this.btnReceipt.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReceipt.FlatAppearance.BorderSize = 0;
            this.btnReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceipt.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnReceipt.Image = global::DA_CNNET_QLCHXE.Properties.Resources.file_invoice_solid;
            this.btnReceipt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReceipt.Location = new System.Drawing.Point(0, 40);
            this.btnReceipt.Name = "btnReceipt";
            this.btnReceipt.Padding = new System.Windows.Forms.Padding(35, 0, 27, 0);
            this.btnReceipt.Size = new System.Drawing.Size(250, 40);
            this.btnReceipt.TabIndex = 1;
            this.btnReceipt.Text = "Receipt";
            this.btnReceipt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReceipt.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnReceipt.UseVisualStyleBackColor = true;
            this.btnReceipt.Click += new System.EventHandler(this.btnReceipt_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHoaDon.FlatAppearance.BorderSize = 0;
            this.btnHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoaDon.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnHoaDon.Image = global::DA_CNNET_QLCHXE.Properties.Resources.file_invoice_dollar_solid;
            this.btnHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHoaDon.Location = new System.Drawing.Point(0, 0);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Padding = new System.Windows.Forms.Padding(35, 0, 27, 0);
            this.btnHoaDon.Size = new System.Drawing.Size(250, 40);
            this.btnHoaDon.TabIndex = 0;
            this.btnHoaDon.Text = "Hoá đơn";
            this.btnHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHoaDon.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnHoaDon.UseVisualStyleBackColor = true;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // btnThongTin
            // 
            this.btnThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongTin.FlatAppearance.BorderSize = 0;
            this.btnThongTin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongTin.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnThongTin.Image = global::DA_CNNET_QLCHXE.Properties.Resources.chart_bar_regular;
            this.btnThongTin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThongTin.Location = new System.Drawing.Point(0, 235);
            this.btnThongTin.Name = "btnThongTin";
            this.btnThongTin.Padding = new System.Windows.Forms.Padding(10, 0, 25, 0);
            this.btnThongTin.Size = new System.Drawing.Size(250, 45);
            this.btnThongTin.TabIndex = 4;
            this.btnThongTin.Text = "Thông tin";
            this.btnThongTin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongTin.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnThongTin.UseVisualStyleBackColor = true;
            this.btnThongTin.Click += new System.EventHandler(this.btnThongTin_Click);
            // 
            // btnBanHang
            // 
            this.btnBanHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBanHang.FlatAppearance.BorderSize = 0;
            this.btnBanHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanHang.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBanHang.Image = global::DA_CNNET_QLCHXE.Properties.Resources.receipt_solid;
            this.btnBanHang.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBanHang.Location = new System.Drawing.Point(0, 190);
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Padding = new System.Windows.Forms.Padding(10, 0, 27, 0);
            this.btnBanHang.Size = new System.Drawing.Size(250, 45);
            this.btnBanHang.TabIndex = 3;
            this.btnBanHang.Text = "Bán hàng";
            this.btnBanHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBanHang.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBanHang.UseVisualStyleBackColor = true;
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhachHang.FlatAppearance.BorderSize = 0;
            this.btnKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhachHang.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnKhachHang.Image = global::DA_CNNET_QLCHXE.Properties.Resources.users_solid;
            this.btnKhachHang.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKhachHang.Location = new System.Drawing.Point(0, 145);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Padding = new System.Windows.Forms.Padding(10, 0, 22, 0);
            this.btnKhachHang.Size = new System.Drawing.Size(250, 45);
            this.btnKhachHang.TabIndex = 2;
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhachHang.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnKhachHang.UseVisualStyleBackColor = true;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnHome.Image = global::DA_CNNET_QLCHXE.Properties.Resources.home_solid1;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHome.Location = new System.Drawing.Point(0, 100);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(10, 0, 25, 0);
            this.btnHome.Size = new System.Drawing.Size(250, 45);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.Controls.Add(this.lblUser);
            this.pnlLogo.Controls.Add(this.picLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(250, 100);
            this.pnlLogo.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblUser.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblUser.Location = new System.Drawing.Point(0, 68);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(250, 32);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "label1";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            this.picLogo.Image = global::DA_CNNET_QLCHXE.Properties.Resources.store_logo;
            this.picLogo.Location = new System.Drawing.Point(0, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(250, 53);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // pnlLoadForm
            // 
            this.pnlLoadForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(101)))), ((int)(((byte)(179)))));
            this.pnlLoadForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLoadForm.Location = new System.Drawing.Point(250, 0);
            this.pnlLoadForm.Name = "pnlLoadForm";
            this.pnlLoadForm.Size = new System.Drawing.Size(1138, 766);
            this.pnlLoadForm.TabIndex = 1;
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1388, 766);
            this.Controls.Add(this.pnlLoadForm);
            this.Controls.Add(this.pnlSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1406, 813);
            this.Name = "FrmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.pnlSideMenu.ResumeLayout(false);
            this.pnlThongTin.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSideMenu;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Button btnThongTin;
        private System.Windows.Forms.Button btnBanHang;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Panel pnlThongTin;
        private System.Windows.Forms.Button btnReceipt;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlLoadForm;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblUser;
    }
}