using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StoreClient
{
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text != String.Empty || txtCategory.Text != String.Empty || txtPrice.Text != String.Empty)
            {
                Product product = new Product();
                product.product_id = -1;
                product.product_name = txtName.Text;
                product.category_name = txtCategory.Text;
                product.list_price = int.Parse(txtPrice.Text);
                RestClient client = new RestClient("http://cagridogan08-001-site1.btempurl.com/api/Product");
                RestRequest request = new RestRequest(Method.POST);
                string json = System.Text.Json.JsonSerializer.Serialize(product);
                request.AddParameter("application/json;charset=utf-8", json, ParameterType.RequestBody);
                request.RequestFormat = DataFormat.Json;
                try
                {
                    client.ExecuteAsync(request, response =>
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            MessageBox.Show("Add Successful");
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    });
                }
                catch(Exception)
                {
                    
                }

            }
            else
            {
                MessageBox.Show("Enter Value all fields");
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = String.Empty;
            txtCategory.Text = String.Empty;
            txtPrice.Text = String.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm form = new AdminForm();
            form.ShowDialog();
        }

        private void AddProductForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            AdminForm form = new AdminForm();
            form.ShowDialog();
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
    }
}
