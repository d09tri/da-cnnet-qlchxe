using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DA_CNNET_QLCHXE.Controllers;

namespace DA_CNNET_QLCHXE
{
    public partial class CarItem : UserControl
    {
        public CarItem()
        {
            InitializeComponent();
        }

        Services sv = new Services();
        
        public CarItem CarItemInit(string direct, string productName, string id)
        {
            CarItem item = new CarItem();

            this.Direct = direct;
            this.ProductName = productName;
            this.Id = id;

            picHinhAnhXe.Image = sv.GetImg(this.direct, 180, 180);
            lblChiTietXe.Text = this.productName;

            return item;
        }

        #region Properties
        private string direct;
        private string productName;
        private string id;

        [Category("Custom Props")]
        public string Direct
        {
            get { return direct; }
            set { direct = value; }
        }

        [Category("Custom Props")]
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        [Category("Custom Props")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        #endregion

        private void lblChiTietXe_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel flw = this.Parent as FlowLayoutPanel;
            Form mFrm = flw.Parent as Form;
            mFrm.Close();
        }
    }
}
