using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StoreApi.Model
{
    public class User
    {
        public int customer_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string e_mail { get; set; }

        public string password { get; set; }
        public string phone { get; set; }
    }
    public class Product
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string category_name { get; set; }
        public int list_price { get; set; }
    }
    public class Order
    {
        public int order_id { get; set; }
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public string order_address { get; set; }
        public string order_date { get; set; } 
        public int bill { get; set; }
        public string items { get; set; }

    }
   
}
