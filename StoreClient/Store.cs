using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreClient
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

        public List<string> getList(string a)
        {
            List<string> Items = new List<string>();
            string[] token = a.Split('+');
            foreach (string item in token)
            {
                Items.Add(item);
            }
            return Items;
        }

    }
    public class ItemToPurchase
    {
        public Product p { get; set; }
        public int quantity { get; set; }
    }
    public class ShoppingCart
    {
        public User user { get; set; }

        public List<ItemToPurchase> po { get; set; }
        public int TotalPrice()
        {
            int tp = 0;
            for (int i = 0; i < po.Count; i++)
            {
                tp += po[i].quantity * po[i].p.list_price;
            }
            return tp;
        }
        public string Items()
        {
            string a = "";
            for (int i = 0; i < po.Count; i++)
            {
                a += "" + po[i].quantity + "*" + po[i].p.product_name + "+";
            }
            return a;
        }
       

    }
}
