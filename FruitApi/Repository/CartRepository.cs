using FruitUserApi.Data;
using FruitUserApi.Models;
using FruitUserApi.Models.VM;
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

        /* public List<Cart> GetAllData()
         {
             return db.Carts.ToList();
         }*/

        public List<CartViewModel> GetAllData()
        {
            List<Cart> cartList= db.Carts.ToList();
            List<Fruit> fruitList = db.Fruits.ToList();

            Fruit fruitItem = null;
            CartViewModel cartViewModelItem = null;
            List<CartViewModel> cartViewModelList = new List<CartViewModel>();
            foreach (Cart cart in cartList)
            {
                fruitItem = db.Fruits.Find(cart.FruitId);
                cartViewModelItem = new CartViewModel()
                {
                    CartId = cart.CartId,
                    CartQty = cart.CartQty,
                    CartAmount = cart.CartAmount,
                    FruitId = cart.FruitId,
                    FruitImg = fruitItem.FruitImg,
                    FruitName = fruitItem.FruitName,
                    UserId = cart.UserId
                };

                cartViewModelList.Add(cartViewModelItem);
            }//foreach
            return cartViewModelList;
        }

        public List<CartViewModel> GetAllDataByUserId(int userId)
        {
            List<Cart> cartList = db.Carts.ToList();
            List<Fruit> fruitList = db.Fruits.ToList();

            Fruit fruitItem = null;
            CartViewModel cartViewModelItem = null;
            List<CartViewModel> cartViewModelList = new List<CartViewModel>();
            foreach (Cart cart in cartList)
            {
                if (cart.UserId == userId)//filter by userId
                {
                    fruitItem = db.Fruits.Find(cart.FruitId);
                    cartViewModelItem = new CartViewModel()
                    {
                        CartId = cart.CartId,
                        CartQty = cart.CartQty,
                        CartAmount = cart.CartAmount,
                        FruitId = cart.FruitId,
                        FruitImg = fruitItem.FruitImg,
                        FruitName= fruitItem.FruitName,
                        UserId = cart.UserId

                    };
                    cartViewModelList.Add(cartViewModelItem);
                }               
            }//foreach
            return cartViewModelList;
        }

        public bool UpdateQtyOfCart(Cart cart)
        {
            if (cart != null)
            {
                db.Carts.Update(cart);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
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

        

        public bool DeleteData(int id)
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
