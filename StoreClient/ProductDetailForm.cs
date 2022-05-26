using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreClient
{
    public partial class ProductDetailForm : Form
    {
        Product product1 = new Product();
        User user1 = new User();
        public ProductDetailForm(Product product,User user)
        {
            InitializeComponent();
            this.product1 = product;
            this.user1 = user;
        }

        private void ProductDetailForm_Load(object sender, EventArgs e)
        {
            txtCategory.Enabled = false;
            txtPrice.Enabled = false;
            txtProductID.Enabled = false;
            txtProductName.Enabled = false;
            txtProductID.Text = product1.product_id.ToString();
            txtProductName.Text = product1.product_name;
            txtCategory.Text = product1.category_name;
            txtPrice.Text = product1.list_price.ToString();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void ProductDetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            StoreForm form = new StoreForm(user1);
            form.ShowDialog();
        }
    }
}
