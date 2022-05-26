using StoreApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        string connectionString = "Database Connection String";
        [HttpGet("orders/{id}")]

        public IEnumerable<Order> GetOrders(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from dbo.orders where customer_id=@Customer_ID";
            cmd.Parameters.AddWithValue("@Customer_ID", id);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Order> orders = new List<Order>();
            while (reader.Read())
            {
                Order order = new Order();
                order.order_id = reader.GetInt32(0);
                order.customer_id = reader.GetInt32(1);
                order.customer_name = reader.GetString(2);
                order.order_address = reader.GetString(3);
                order.order_date = reader.GetString(4);
                order.bill = reader.GetInt32(5);
                order.items = reader.GetString(6);
                orders.Add(order);
            }
            reader.Close();
            conn.Close();
            return orders;
        }
        [HttpPost]
        public void PostOrder([FromBody] Order order)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.CommandText = "insert into orders (customer_id,customer_name,order_address,order_date,bill,items) values(@Customer_ID,@Customer_Name,@Order_Address,@Order_Date,@Bill,@Items)";

            cmd.Parameters.AddWithValue("@Customer_ID", order.customer_id);
            cmd.Parameters.AddWithValue("@Customer_Name", order.customer_name);
            cmd.Parameters.AddWithValue("@Order_Address", order.order_address);
            cmd.Parameters.AddWithValue("@Order_Date", order.order_date);
            cmd.Parameters.AddWithValue("@Bill", order.bill);
            cmd.Parameters.AddWithValue("@Items", order.items);
            

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        [HttpDelete("{id}")]//api/Order/id
        public void deleteOrder([FromBody] int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "delete from dbo.orders where order_id=@Order_ID";
            cmd.Parameters.AddWithValue("@Order_ID", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        [HttpGet]
        public IEnumerable<Order> GetAllOrders()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from dbo.orders ";
            List<Order> allOrders = new List<Order>();
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Order tmp = new Order();
                Order order = new Order();
                order.order_id = reader.GetInt32(0);
                order.customer_id = reader.GetInt32(1);
                order.customer_name = reader.GetString(2);
                order.order_address = reader.GetString(3);
                order.order_date = reader.GetString(4);
                order.bill = reader.GetInt32(5);
                order.items = reader.GetString(6);
                allOrders.Add(order);
            }
            reader.Close();
            conn.Close();
            return allOrders;
        }
        [HttpPut]
        public void PutOrder([FromBody] Order order)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update dbo.orders set customer_id=@Customer_ID,customer_name=@Customer_Name,order_address=@Order_Address,order_date=@Order_Date,bill=@Bill,items=@Items where order_id=@Order_ID";
            cmd.Parameters.AddWithValue("@Order_ID", order.order_id);
            cmd.Parameters.AddWithValue("@Customer_ID", order.customer_id);
            cmd.Parameters.AddWithValue("@Customer_Name", order.customer_name);
            cmd.Parameters.AddWithValue("@Order_Address", order.order_address);
            cmd.Parameters.AddWithValue("@Order_Date", order.order_date);
            cmd.Parameters.AddWithValue("@Bill", order.bill);
            cmd.Parameters.AddWithValue("@Items", order.items);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
