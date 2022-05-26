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
    public partial class UserInfoUpdate : Form
    {
        User user1 = new User();
        public UserInfoUpdate(User user)
        {
            InitializeComponent();
            this.user1 = user;
        }

        private void UserInfoUpdate_Load(object sender, EventArgs e)
        {
            txtFirstName.Text = user1.first_name;
            txtLastName.Text = user1.last_name;
            txtEmail.Text = user1.e_mail;
            txtPassword.Text = user1.password;
            txtPhone.Text = user1.phone;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtFirstName.Text!=String.Empty|| txtLastName.Text != String.Empty || txtEmail.Text != String.Empty || txtPassword.Text != String.Empty || txtPhone.Text != String.Empty)
            {
                user1.first_name = txtFirstName.Text;
                user1.last_name = txtLastName.Text;
                user1.e_mail = txtEmail.Text;
                user1.password = txtPassword.Text;
                user1.phone = txtPhone.Text;
                Update(user1);
            }
            else
            {
                MessageBox.Show("All Fields Must be Filled");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            StoreForm form = new StoreForm(user1);
            form.ShowDialog();
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

        private void UserInfoUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            StoreForm form = new StoreForm(user1);
            form.ShowDialog();
        }
    }
}
