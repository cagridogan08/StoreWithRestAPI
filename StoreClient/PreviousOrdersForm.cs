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
    public partial class PreviousOrdersForm : Form
    {
        User user1 = new User();
        List<Order> orders = new List<Order>();
        public PreviousOrdersForm(User user)
        {
            InitializeComponent();
            this.user1 = user;
        }

        private void PreviousOrdersForm_Load(object sender, EventArgs e)
        {
            lblCustomerID.Text = "ID:" + user1.customer_id.ToString();
            lblFirstLastName.Text = "Name:" + user1.first_name + " " + user1.last_name;
            lblEmail.Text = "Email:" + user1.e_mail;
            lblPassword.Text = "Password:" + user1.password;
            lblPhone.Text = "Phone:" + user1.phone;
            getData();
            lstOrderDetail.Columns.Add("Order ID");
            lstOrderDetail.Columns.Add("Items");
            dgvPreOrders.AutoSize = true;


            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
        public void getData()
        {
            RestClient client = new RestClient("http://cagridogan08-001-site1.btempurl.com/api/Order/orders");
            RestRequest request = new RestRequest("/" + user1.customer_id, Method.GET);
            orders = client.Execute<List<Order>>(request).Data;
            DataTable tmpData = toDataTable(orders);
            dgvPreOrders.DataSource = tmpData;
        }
        public DataTable toDataTable(IList<Order> list)
        {
            var json = JsonConvert.SerializeObject(list);
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            return dt;
        }

        private void PreviousOrdersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            StoreForm form = new StoreForm(user1);
            form.ShowDialog();
        }

        private void dgvPreOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            lstOrderDetail.Visible = true;
            lstOrderDetail.GridLines = true;
            lstOrderDetail.View = View.Details;
            if (dgvPreOrders.Rows.Count==0)
            {
                MessageBox.Show("There is no previous order");
            }
            else
            {
                toListView(lstOrderDetail);
            }
        }
        private void toListView(ListView a)
        {
            Order order = new Order();
            order.order_id = Int32.Parse(dgvPreOrders.SelectedRows[0].Cells[0].Value.ToString());
            order.customer_id =Int32.Parse(dgvPreOrders.SelectedRows[0].Cells[1].Value.ToString());
            order.customer_name = dgvPreOrders.SelectedRows[0].Cells[2].Value.ToString();
            order.order_address = dgvPreOrders.SelectedRows[0].Cells[3].Value.ToString();
            order.order_date = dgvPreOrders.SelectedRows[0].Cells[4].Value.ToString();
            order.bill = Int32.Parse(dgvPreOrders.SelectedRows[0].Cells[5].Value.ToString());
            order.items = dgvPreOrders.SelectedRows[0].Cells[6].Value.ToString();
            
            List<string> items = order.getList(order.items);
            a.Items.Clear();
            for(int i = 0; i < items.Count; i++)
            {
                ListViewItem lstıtem = new ListViewItem(order.order_id.ToString());
                lstıtem.SubItems.Add(new ListViewItem.ListViewSubItem(lstıtem, items[i]));
                a.Items.Add(lstıtem);
            }
            lblPrice.Text ="Total Price:"+ order.bill.ToString();
        }
    }
}
