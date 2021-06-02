using FruitUserApi.Data;
using FruitUserApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitUserApi.Repository
{
    public class CartRepository
    {
        private readonly FruitVendorContext db = null;
        public CartRepository()
        {
            db = new FruitVendorContext();
        }

        public List<Cart> GetAllData()
        {
            return db.Carts.ToList();
        }

     
        public bool CreateData(Cart obj)
        {
            if (obj != null)
            {
                db.Carts.Add(obj);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        internal Cart GetDataById(int id)
        {
            Cart cart = db.Carts.Find(id);
            return cart;
        }

        internal bool DeleteData(int id)
        {
            Cart cart = db.Carts.Find(id);
            if (cart != null)
            {
                db.Carts.Remove(cart);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
           
        }
    }
}
