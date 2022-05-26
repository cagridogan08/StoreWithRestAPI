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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            RestClient client = new RestClient("http://cagridogan08-001-site1.btempurl.com/api/User/login");
            RestRequest request = new RestRequest("?email="+txtEmail.Text+"&password="+txtPassword.Text,Method.GET);
            User user = client.Execute<User>(request).Data;
            if (user.customer_id != 0)
            {
                MessageBox.Show("Login Successful");
                this.Hide();
                StoreForm store = new StoreForm(user);
                store.ShowDialog();
            }
            else
            {
                MessageBox.Show("No match for email and password");
            }

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm register = new RegisterForm();
            register.ShowDialog();
        }

        private void chcPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chcPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }


        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminForm form = new AdminForm();
            this.Hide();
            form.ShowDialog();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
