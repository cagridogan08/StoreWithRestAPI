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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtFirsName.Text != String.Empty || txtLastName.Text != String.Empty || txtEmail.Text != String.Empty || txtEmail2.Text != String.Empty || txtPassword.Text != String.Empty || txtPassword2.Text != String.Empty || txtPhone.Text != String.Empty)
            {
                if (txtEmail.Text == txtEmail2.Text)
                {
                    if (txtPassword.Text == txtPassword2.Text)
                    {
                        User user = new User();
                        user.customer_id = -1;
                        user.first_name = txtFirsName.Text;
                        user.last_name = txtLastName.Text;
                        user.e_mail = txtEmail.Text;
                        user.password = txtPassword.Text;
                        user.phone = txtPhone.Text;

                        RestClient client = new RestClient("http://cagridogan08-001-site1.btempurl.com/api/User");
                        RestRequest request = new RestRequest(Method.POST);

                        string json = System.Text.Json.JsonSerializer.Serialize(user);
                        request.AddParameter("application/json;charset=utf-8", json, ParameterType.RequestBody);
                        request.RequestFormat = DataFormat.Json;

                        try
                        {
                            client.ExecuteAsync(request, response =>
                            {
                                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                                {
                                    MessageBox.Show("Register Successful");
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
                        MessageBox.Show("Please Enter both Password Same", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter both Email Same", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login form = new Login();
            form.ShowDialog();
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Login form = new Login();
            form.ShowDialog();
        }
    }
}
