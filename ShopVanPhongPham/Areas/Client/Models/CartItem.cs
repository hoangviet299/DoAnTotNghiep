using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Model.EF;

namespace ShopVanPhongPham.Areas.Client.Models
{
    [Serializable]
    public class Cart
    {
        public product Product { set; get; }
        public int Quantity { set; get; }
    }
    public class CartItem
    {
        List<Cart> items = new List<Cart>();
        public IEnumerable<Cart> Items
        {
            get { return items; }
        }
        public void AddCart(product pro, int quantity =1)
        {
            var item = items.FirstOrDefault(s => s.Product.id_product == pro.id_product);
            if(item == null)
            {
                items.Add(new Cart
                {
                    Product = pro,
                    Quantity = quantity
                }) ;
            }
            else
            {
                item.Quantity += quantity;
            }

        }
        public void Update(int id,int quantity)
        {
            var item = items.Find(s => s.Product.id_product == id);
            if(item != null)
            {
                item.Quantity = quantity;
            }
        }
        public double Total_Money()
        {
            var total = items.Sum(s => s.Product.price * s.Quantity);
            return (double)total;
        }
        public void Remove(int id)
        {
            items.RemoveAll(s => s.Product.id_product == id);
        }
        public void ClearCart()
        {
            items.Clear();
        }
        public int Total_Quantity()
        {
            return items.Sum(s => s.Quantity);
        }
    }
    
}