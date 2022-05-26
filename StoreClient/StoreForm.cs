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
    public partial class StoreForm : Form
    {
        User user = new User();
        List<Product> products = new List<Product>();
        List<ItemToPurchase> shoppinCart = new List<ItemToPurchase>();
        int itemcount = 0;
        public StoreForm(User u)
        {
            InitializeComponent();
            this.user = u;
        }

        private void StoreForm_Load(object sender, EventArgs e)
        {
            lblCustomerID.Text ="ID:"+ user.customer_id.ToString();
            lblFirstLastName.Text ="Name:" +user.first_name + " " + user.last_name;
            lblEmail.Text ="Email:" +user.e_mail;
            lblPassword.Text = "Password:"+user.password;
            lblPhone.Text = "Phone:"+user.phone;
            FillData();
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.AllowUserToAddRows = false;
        }

        private void FillData()
        {
            RestClient client = new RestClient("http://cagridogan08-001-site1.btempurl.com/api/Product");
            RestRequest request = new RestRequest(Method.GET);
            products = client.Execute<List<Product>>(request).Data;
            DataTable tmp = toDataTable(products);
            dgvProducts.DataSource = tmp;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dgvProducts.Columns.Add(btn);
            btn.HeaderText = "Add Cart";
            btn.Text = "Add Cart";
            btn.UseColumnTextForButtonValue = true;
            
        }
        private DataTable toDataTable(IList<Product> p)
        {
            var json = JsonConvert.SerializeObject(p);
            DataTable t = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            return t;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

       

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                Product product = new Product();
                product.product_id = Int32.Parse(dgvProducts.SelectedRows[0].Cells[0].Value.ToString());
                product.product_name = dgvProducts.SelectedRows[0].Cells[1].Value.ToString();
                product.category_name = dgvProducts.SelectedRows[0].Cells[2].Value.ToString();
                product.list_price= Int32.Parse(dgvProducts.SelectedRows[0].Cells[3].Value.ToString());
                ItemToPurchase to = new ItemToPurchase();
                to.p = product;
                to.quantity = 1;
                shoppinCart.Add(to);
                itemcount++;
                btnChart.Text = "My Cart(" + itemcount + ")";
            }
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            if (shoppinCart.Count == 0)
            {
                MessageBox.Show("Shopping Cart is Empty");
            }
            else
            {
                ShoppingCart shpCart = new ShoppingCart();
                shpCart.user = this.user;
                shpCart.po = this.shoppinCart;

                ShoppingCartForm form = new ShoppingCartForm(shpCart);
                this.Hide();
                form.ShowDialog();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserInfoUpdate form = new UserInfoUpdate(this.user);
            form.ShowDialog();
        }

        private void btnPreOrders_Click(object sender, EventArgs e)
        {
            this.Hide();
            PreviousOrdersForm form = new PreviousOrdersForm(this.user);
            form.ShowDialog();
        }

        private void StoreForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchID.Text != String.Empty)
            {
                RestClient client = new RestClient("http://cagridogan08-001-site1.btempurl.com/api/Product");
                RestRequest request = new RestRequest("/" + txtSearchID.Text, Method.GET);
                Product querryResult = client.Execute<Product>(request).Data;
                if (querryResult.product_id == 0)
                {
                    MessageBox.Show("No Match Found");
                }
                else
                {
                    this.Hide();
                    ProductDetailForm form = new ProductDetailForm(querryResult,this.user);
                    form.ShowDialog();
                }
            }
            else{
                MessageBox.Show("ID is Empty");
            }
        }
    }
}
