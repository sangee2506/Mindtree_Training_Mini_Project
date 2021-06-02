using FruitUserApi.Data;
using FruitUserApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitUserApi.Repository
{
    public class FruitRepository
    {
        FruitVendorContext db = null;
        public FruitRepository()
        {
            db = new FruitVendorContext();
        }

        public List<Fruit> GetAllData()
        {
            return db.Fruits.ToList();
        }

        internal Fruit GetDataById(int id)
        {
            Fruit fruit = db.Fruits.Find(id);
            return fruit;
        }

        public bool UpdateQtyOfFruit(Fruit fruit)
        {
            if (fruit != null)
            {
                db.Fruits.Update(fruit);
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
//	1)will able to perform Read,ReadById and Update(fQty) on Fruits table