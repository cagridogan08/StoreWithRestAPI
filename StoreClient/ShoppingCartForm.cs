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
    public partial class ShoppingCartForm : Form
    {
        ShoppingCart s = new ShoppingCart();
        int totalPrice = 0;
        public ShoppingCartForm(ShoppingCart sp)
        {
            InitializeComponent();
            this.s = sp;
        }

        private void ShoppingCartForm_Load(object sender, EventArgs e)
        {
            lblCustomerID.Text = "ID:" +s. user.customer_id.ToString();
            lblFirstLastName.Text = "Name:" +s. user.first_name + " " +s. user.last_name;
            lblEmail.Text = "Email:" + s.user.e_mail;
            lblPassword.Text = "Password:" +s. user.password;
            lblPhone.Text = "Phone:" +s. user.phone;
            lstOrder.View = View.Details;
            lstOrder.GridLines = true;
            lstOrder.FullRowSelect = true;
            AddColumns();
            ListToListView(s.po);
            lstOrder.MultiSelect = false;
            lblPrice.Text = s.TotalPrice().ToString();
        }

        private void ListToListView(List<ItemToPurchase> ıtm)
        {

            lstOrder.Items.Clear();
            for (int i = 0; i < ıtm.Count; i++)
            {
                ListViewItem lstıtem = new ListViewItem(ıtm[i].p.product_name);
                lstıtem.SubItems.Add(new ListViewItem.ListViewSubItem(lstıtem, ıtm[i].p.list_price.ToString()));
                lstıtem.SubItems.Add(new ListViewItem.ListViewSubItem(lstıtem, ıtm[i].quantity.ToString()));
                lstOrder.Items.Add(lstıtem);
                totalPrice += ıtm[i].p.list_price * ıtm[i].quantity;
                lblPrice.Text = totalPrice.ToString();
            }
            totalPrice = 0;
        }

        private void ShoppingCartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            StoreForm form = new StoreForm(s.user);
            form.ShowDialog();
        }
        private void AddColumns()
        {
            lstOrder.Columns.Add("Product Name");
            lstOrder.Columns.Add("Price");
            lstOrder.Columns.Add("Quantity");
        }
        

        private void btnOrder_Click(object sender, EventArgs e)
        {
            RestClient client = new RestClient("http://cagridogan08-001-site1.btempurl.com/api/Order");
            RestRequest request = new RestRequest(Method.POST);
            if (txtAddress.Text == String.Empty)
            {
                MessageBox.Show("Address is Empty");
            }
            else
            {
                Order order = new Order();
                order.order_id = -1;
                order.customer_id = s.user.customer_id;
                order.customer_name = s.user.first_name + " " + s.user.last_name;
                order.order_address = txtAddress.Text;
                order.order_date = DateTime.Now.ToLongDateString();
                order.bill = s.TotalPrice();
                order.items = s.Items();

                string json = System.Text.Json.JsonSerializer.Serialize(order);
                request.AddParameter("application/json;charset=utf-8", json, ParameterType.RequestBody);
                try
                {
                    client.ExecuteAsync(request, response =>
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            MessageBox.Show("Order Saved");
                            
     
                        }
                        //this.Hide();
                        else
                        {
                            MessageBox.Show("Error", "Error", MessageBoxButtons.OK);
                        }
                    });
                }
                catch
                {

                    throw ;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            StoreForm form = new StoreForm(s.user);
            form.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lstOrder.SelectedItems.Count == 0)
            {
                MessageBox.Show("No Item Selected");
            }
            else
            {
                int n = lstOrder.SelectedIndices[0];
                lstOrder.Items.RemoveAt(n);
                s.po.RemoveAt(n);
                ListToListView(s.po);
            }
        }

       
    }
}
