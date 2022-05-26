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
    public class ProductController : ControllerBase
    {
        string connectionString = "Database Connection String";

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from dbo.products";
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                Product tmp = new Product();
                tmp.product_id = reader.GetInt32(0);
                tmp.product_name = reader.GetString(1);
                tmp.category_name = reader.GetString(2);
                tmp.list_price = reader.GetInt32(3);
                products.Add(tmp);
            }

            reader.Close();
            return products;
        }
        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from dbo.products where product_id=" + id;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Product product = new Product();
            while (reader.Read())
            {
                product.product_id = reader.GetInt32(0);
                product.product_name = reader.GetString(1);
                product.category_name = reader.GetString(2);
                product.list_price = reader.GetInt32(3);
            }
            reader.Close();
            return product;
        }
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert dbo.products (product_name,category_name,list_price) values(@Product_name,@Category_id,@List_Price)";


            cmd.Parameters.AddWithValue("@Product_name", product.product_name);
            cmd.Parameters.AddWithValue("@Category_id", product.category_name);
            cmd.Parameters.AddWithValue("@List_Price", product.list_price);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        [HttpPut]
        public void Put([FromBody] Product product)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update dbo.products set product_name=@Product_Name,category_name=@Category_ID,list_price=@List_Price where product_id=@Product_ID";

            cmd.Parameters.AddWithValue("@Product_Name", product.product_name);
            cmd.Parameters.AddWithValue("@Category_ID", product.category_name);
            cmd.Parameters.AddWithValue("@List_Price", product.list_price);
            cmd.Parameters.AddWithValue("@Product_ID", product.product_id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        [HttpDelete("{id}")]
        public void Delete([FromBody] int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "delete from dbo.products where product_id=" + id;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        [HttpGet("category")]

        public IEnumerable<Product> GetSameCategory(string categoryName)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from dbo.Products where category_name=@CategoryName";
            cmd.Parameters.AddWithValue("@CategoryName", categoryName);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product product = new Product();
                product.product_id = reader.GetInt32(0);
                product.product_name = reader.GetString(1);
                product.category_name = reader.GetString(2);
                product.list_price = reader.GetInt32(3);
                products.Add(product);
            }
            reader.Close();
            conn.Close();
            return products;

        }
    }
}
