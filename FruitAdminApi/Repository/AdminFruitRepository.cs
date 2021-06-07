using FruitUserApi.Data;
using FruitUserApi.Models;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace FruitAdminApi.Repository
{
    public class AdminFruitRepository
    {
        private readonly FruitVendorContext db = null;
        public AdminFruitRepository()
        {
            db = new FruitVendorContext();
        }
       
        //Get All Fruits
        public List<Fruit> GetAllFruits()
        {
            return db.Fruits.ToList();
        }
        //Get Fruit Details By id
        public Fruit GetFruitById(int id)
        {
            Fruit fruit = db.Fruits.Find(id);
            return fruit;
        }
        //edit fruit by id
        public async Task<Fruit> EditFruitByIdAsync(int id,Fruit model)
        {
            Fruit fruit = db.Fruits.Find(id);
            fruit.FruitName = model.FruitName;
            fruit.FruitImg = model.FruitImg;
            fruit.FruitPrice = model.FruitPrice;
            fruit.FruitQty = model.FruitQty;
            await db.SaveChangesAsync();
            return fruit;
        }

        // delete Fruit By id
        public async Task<bool> DeleteFruitByIdAsync(int id)
        {
            Fruit fruit = db.Fruits.Find(id);
            db.Fruits.Remove(fruit);
            await db.SaveChangesAsync();
            return true;
        }
       

        //Add Fruit
        public async Task<Fruit> AddFruitAsync(Fruit model)
        {
            db.Fruits.Add(model);
            await db.SaveChangesAsync();
            return model;
        }
    }
}
