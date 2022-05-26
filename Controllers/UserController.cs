using StoreApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    { //
        string connectionString = "Database Connection String";


        [HttpGet("login")]
        public User GetUser(string email, string password)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from customers where email=@Email and pass=@Password";
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            User claims = new User();
            while (reader.Read())
            {
                claims.customer_id = reader.GetInt32(0);
                claims.first_name = reader.GetString(1);
                claims.last_name = reader.GetString(2);
                claims.e_mail = reader.GetString(3);
                claims.password = reader.GetString(4);
                if (!reader.IsDBNull(5))
                {
                    claims.phone = reader.GetString(5);
                }
            }
            reader.Close();
            conn.Close();
            return claims;
        }


        [HttpGet] //Get All Users
        public IEnumerable<User> GetUsers()
        {
            SqlConnection conn = new SqlConnection(connectionString);  
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from dbo.customers";
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<User> users = new List<User>();
            while (reader.Read())
            {
                User claims = new User();
                claims.customer_id = reader.GetInt32(0);
                claims.first_name = reader.GetString(1);
                claims.last_name = reader.GetString(2);
                claims.e_mail = reader.GetString(3);
                claims.password = reader.GetString(4);
                if (!reader.IsDBNull(5))
                {
                    claims.phone = reader.GetString(5);
                }
                users.Add(claims);
            }
            reader.Close();
            conn.Close();
            return users;
        }
        [HttpPost]
        public void PostUser([FromBody] User user)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert customers (first_name,last_name,email,pass,phone) values(@First_Name,@Last_Name,@Email,@Password,@Phone)";

            cmd.Parameters.AddWithValue("@First_Name", user.first_name);
            cmd.Parameters.AddWithValue("@Last_Name", user.last_name);
            cmd.Parameters.AddWithValue("@Email", user.e_mail);
            cmd.Parameters.AddWithValue("@Password", user.password);
            cmd.Parameters.AddWithValue("@Phone", user.phone);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        [HttpPut]

        public void PutUser([FromBody] User user)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update customers set first_name=@First_Name,last_name=@Last_Name,email=@Email,pass=@Password,phone=@Phone where customer_id=@Customer_ID";

            cmd.Parameters.AddWithValue("@First_Name", user.first_name);
            cmd.Parameters.AddWithValue("@Last_Name", user.last_name);
            cmd.Parameters.AddWithValue("@Email", user.e_mail);
            cmd.Parameters.AddWithValue("@Password", user.password);
            cmd.Parameters.AddWithValue("@Phone", user.phone);
            cmd.Parameters.AddWithValue("@Customer_ID", user.customer_id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        [HttpDelete("{id}")]

        public void DeleteUser(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "delete from customers where customer_id=@Customer_ID";
            cmd.Parameters.AddWithValue("@Customer_ID", id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        
        
    }
}
