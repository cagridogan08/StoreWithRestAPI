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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void rdbUser_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbUser.Checked)
            {
                grpData.Text = "User";
                GetUserDatas();
            }
            else if (rdbProduct.Checked)
            {
                grpData.Text = "Product";
                GetProductData();
            }
            else if (rdbOrder.Checked)
            {
                grpData.Text = "Order";
                GetOrderData();
            }
        }

        private void rdbProduct_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbUser.Checked)
            {
                grpData.Text = "User";
                GetUserDatas();
            }
            else if (rdbProduct.Checked)
            {
                grpData.Text = "Product";
                GetProductData();
            }
            else if (rdbOrder.Checked)
            {
                grpData.Text = "Order";
                GetOrderData();
            }
        }

        private void rdbOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbUser.Checked)
            {
                grpData.Text = "User";
                GetUserDatas();
            }
            else if (rdbProduct.Checked)
            {
                grpData.Text = "Product";
                GetProductData();
            }
            else if (rdbOrder.Checked)
            {                
                grpData.Text = "Order";
                GetOrderData();
            }

        }
        private void GetUserDatas()
        {
            RestClient client = new RestClient("http://cagridogan08-001-site1.btempurl.com/api/User");
            RestRequest request = new RestRequest(Method.GET);
            List<User> querryResult = client.Execute<List<User>>(request).Data;
            DataTable tmpData = UserDatatoDataTable(querryResult);
            dtgvData.DataSource = tmpData;
        }
        private void GetProductData()
        {
            RestClient client = new RestClient("http://cagridogan08-001-site1.btempurl.com/api/Product");
            RestRequest request = new RestRequest(Method.GET);
            List<Product> querryResult = client.Execute<List<Product>>(request).Data;
            DataTable tmpData = ProducttoDataTable(querryResult);
            dtgvData.DataSource = tmpData;
        }
        private void GetOrderData()
        {
            RestClient client = new RestClient("http://cagridogan08-001-site1.btempurl.com/api/Order");
            RestRequest request = new RestRequest(Method.GET);
            List<Order> querryResult = client.Execute<List<Order>>(request).Data;
            DataTable tmpData = OrdersToDataTable(querryResult);
            dtgvData.DataSource = tmpData;
        }
        private DataTable UserDatatoDataTable(IList<User> list)
        {
            var json = JsonConvert.SerializeObject(list);
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            return dt;
        }
        private DataTable ProducttoDataTable(IList<Product> list)
        {
            var json = JsonConvert.SerializeObject(list);
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            return dt;
        }
        private DataTable OrdersToDataTable(IList<Order> list)
        {
            var json = JsonConvert.SerializeObject(list);
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            return dt;
        }
        private Product getProductFromDataGridView()
        {
            Product product = new Product();
            if (rdbProduct.Checked&&dtgvData.Rows.Count>0)
            {
               
                product.product_id = Int32.Parse(dtgvData.SelectedRows[0].Cells[0].Value.ToString());
                product.product_name = dtgvData.SelectedRows[0].Cells[1].Value.ToString();
                product.category_name = dtgvData.SelectedRows[0].Cells[2].Value.ToString();
                product.list_price = Int32.Parse(dtgvData.SelectedRows[0].Cells[3].Value.ToString());
                
            }
            return product;
        }
        private User getUserFromDataGridView()
        {
            User user = new User();
            if (dtgvData.Rows.Count>0)
            {
                user.customer_id = Int32.Parse(dtgvData.SelectedRows[0].Cells[0].Value.ToString());
                user.first_name= dtgvData.SelectedRows[0].Cells[1].Value.ToString();
                user.last_name = dtgvData.SelectedRows[0].Cells[2].Value.ToString();
                user.e_mail = dtgvData.SelectedRows[0].Cells[3].Value.ToString();
                user.password = dtgvData.SelectedRows[0].Cells[4].Value.ToString();
                user.phone = dtgvData.SelectedRows[0].Cells[5].Value.ToString();
            }
            return user;
        }
        private Order getOrderFromDataGridView()
        {
            Order order = new Order();
            if (dtgvData.Rows.Count > 0)
            {
                order.order_id = Int32.Parse(dtgvData.SelectedRows[0].Cells[0].Value.ToString());
                order.customer_id = Int32.Parse(dtgvData.SelectedRows[0].Cells[1].Value.ToString());
                order.customer_name = dtgvData.SelectedRows[0].Cells[2].Value.ToString();
                order.order_address = dtgvData.SelectedRows[0].Cells[3].Value.ToString();
                order.order_date = dtgvData.SelectedRows[0].Cells[4].Value.ToString();
                order.bill = Int32.Parse(dtgvData.SelectedRows[0].Cells[5].Value.ToString());
                order.items = dtgvData.SelectedRows[0].Cells[6].Value.ToString();

            }
            return order;
        }

        private void dtgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (rdbOrder.Checked)
            {
                Order order = getOrderFromDataGridView();
                
                lblID.Text = "Order ID";
                lbl2.Text = "Customer ID";
                lbl3.Text = "Customer Name";
                lbl4.Text = "Order Address";
                lbl5.Text = "Order Date";
                lbl6.Text = "Bill";
                lbl7.Text = "Items";
                txtID.Text = order.order_id.ToString();
                txt2.Text = order.customer_id.ToString();txt2.Enabled = false;
                txt3.Text = order.customer_name;
                txt4.Text = order.order_address;
                txt5.Text = order.order_date;txt5.Enabled = false;txt5.Visible = true;
                txt6.Text = order.bill.ToString();txt6.Enabled = false;txt6.Visible = true;
                txt7.Text = order.items;txt7.Enabled = false;txt7.Visible = true;
                
            }
            else if (rdbProduct.Checked)
            {
                Product product = getProductFromDataGridView();
                lblID.Text = "Product ID";
                lbl2.Text = "Product Name";
                lbl3.Text = "Category Name";
                lbl4.Text = "List Price";
                txtID.Text = product.product_id.ToString();
                txt2.Text = product.product_name;txt2.Enabled = true;
                txt3.Text = product.category_name;
                txt4.Text = product.list_price.ToString();
                txt5.Visible = false;
                txt6.Visible = false;
                txt7.Visible = false;
            }
            else if (rdbUser.Checked)
            {
                User user = getUserFromDataGridView();
                lblID.Text = "Customer ID";
                lbl2.Text = "First Name";
                lbl3.Text = "Last Name";
                lbl4.Text = "Email";
                lbl5.Text = "Password";
                lbl6.Text = "Phone";
                txtID.Text = user.customer_id.ToString();
                txt2.Text = user.first_name;txt2.Enabled = true;
                txt3.Text = user.last_name;txt3.Enabled = true;
                txt4.Text = user.e_mail;txt4.Enabled = true;
                txt5.Text = user.password;txt5.Enabled = true;
                txt6.Text = user.phone;txt6.Enabled = true;
                txt7.Visible = false;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddProductForm form = new AddProductForm();
            this.Hide();
            form.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (rdbUser.Checked && dtgvData.SelectedCells.Count > 0)
            {
                User user = new User();
                user.customer_id = int.Parse(txtID.Text);
                user.first_name = txt2.Text;
                user.last_name = txt3.Text;
                user.e_mail = txt4.Text;
                user.password = txt5.Text;
                user.phone = txt6.Text;
                Update(user);
                GetUserDatas();

            }
            else if (rdbProduct.Checked && dtgvData.SelectedCells.Count > 0)
            {
                Product product = new Product();
                product.product_id = int.Parse(txtID.Text);
                product.product_name = txt2.Text;
                product.category_name = txt3.Text;
                product.list_price = int.Parse(txt4.Text);
                Update(product);
                GetProductData();
            }
            else if (rdbOrder.Checked && dtgvData.SelectedCells.Count > 0)
            {
                Order order = new Order();
                order.order_id = int.Parse(txtID.Text);
                order.customer_id = int.Parse(txt2.Text);
                order.customer_name = txt3.Text;
                order.order_address = txt4.Text;
                order.order_date = txt5.Text;
                order.bill = int.Parse(txt6.Text);
                order.items = txt7.Text;
                Update(order);
                GetOrderData();
            }
            else
            {
                MessageBox.Show("Nothing Selected");
            }
        }
        private void Update(Product product)
        {
            RestClient client = new RestClient("http://cagridogan08-001-site1.btempurl.com/api/product");
            RestRequest request = new RestRequest("", Method.PUT);
            String jsonToSend = System.Text.Json.JsonSerializer.Serialize(product);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            try
            {
                client.ExecuteAsync(request, response =>
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        MessageBox.Show("Product Updated");
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                });
            }
            catch (Exception)
            {

            }
        }
        private void Update(Order order)
        {
            RestClient client = new RestClient("http://cagridogan08-001-site1.btempurl.com/api/order");
            RestRequest request = new RestRequest("", Method.PUT);
            String jsonToSend = System.Text.Json.JsonSerializer.Serialize(order);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            try
            {
                client.ExecuteAsync(request, response =>
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        MessageBox.Show("Order Updated");
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                });
            }
            catch (Exception)
            {

            }
        }
        private void Update(User user)
        {
            RestClient client = new RestClient("http://cagridogan08-001-site1.btempurl.com/api/User");
            RestRequest request = new RestRequest("", Method.PUT);
            String jsonToSend = System.Text.Json.JsonSerializer.Serialize(user);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            try
            {
                client.ExecuteAsync(request, response =>
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        MessageBox.Show("User Updated");
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                });
            }
            catch (Exception)
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (rdbUser.Checked && dtgvData.SelectedCells.Count > 0)
            {
                RestClient client = new RestClient("http://cagridogan08-001-site1.btempurl.com/api/User");
                RestRequest request = new RestRequest("/" + txtID.Text, Method.DELETE);
                try
                {
                    client.ExecuteAsync(request, response =>
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            MessageBox.Show("User Deleted");
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    });
                }
                catch (Exception)
                {

                }
            }
            else if (rdbProduct.Checked && dtgvData.SelectedCells.Count > 0)
            {

                RestClient client = new RestClient("http://cagridogan08-001-site1.btempurl.com/api/Product");
                RestRequest request = new RestRequest("/" + txtID.Text, Method.DELETE);
                try
                {
                    client.ExecuteAsync(request, response =>
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            MessageBox.Show("Product Deleted");
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    });
                }
                catch (Exception)
                {

                }
            }
            else if (rdbOrder.Checked && dtgvData.SelectedCells.Count > 0)
            {

                RestClient client = new RestClient("http://cagridogan08-001-site1.btempurl.com/api/order");
                RestRequest request = new RestRequest("/" + txtID.Text, Method.DELETE);
                try
                {
                    client.ExecuteAsync(request, response =>
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            MessageBox.Show("Order Deleted");
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    });
                }
                catch (Exception)
                {

                }
            }
            else
            {
                MessageBox.Show("No Item Selected");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
    }
}
