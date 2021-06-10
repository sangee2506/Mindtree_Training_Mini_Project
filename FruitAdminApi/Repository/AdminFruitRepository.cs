using FruitUserApi.Data;
using FruitUserApi.Models;
using System.Web;
using FruitAdminApi.Custom_Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;

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
        public async Task<Fruit> GetFruitById(int? id)
        {
            if(id==null)
            {
                throw new NullValueException("FruitId cant be empty");
            }
            Fruit fruit = await db.Fruits.FindAsync(id);
            if(fruit==null)
            {
                throw new NotFoundException("Fruit not found");
            }
            return fruit;
        }
        //edit fruit by id
        public async Task<Fruit> EditFruitByIdAsync(int? id,Fruit model)
        {
            if (id == null)
            {
                throw new NullValueException("FruitId cant be empty");
            }
            
            Fruit fruit = await db.Fruits.FindAsync(id);
            if (fruit == null)
            {
                throw new NotFoundException("Fruit not found");
            }
            fruit.FruitName = model.FruitName;
            fruit.FruitImg = model.FruitImg;
            fruit.FruitPrice = model.FruitPrice;
            fruit.FruitQty = model.FruitQty;
            await db.SaveChangesAsync();
            return fruit;
        }

        // delete Fruit By id
        public async Task<bool> DeleteFruitByIdAsync(int? id)
        {
            if (id == null)
            {
                throw new NullValueException("FruitId cant be empty");
            }
            Fruit fruit = db.Fruits.Find(id);
            db.Fruits.Remove(fruit);
            await db.SaveChangesAsync();
            return true;
        }
       

        //Add Fruit
        public async Task<Fruit> AddFruitAsync(Fruit model)
        {
            List<Fruit> FruitList = GetAllFruits();
            foreach (var fruit in FruitList)
            {
                if ((model.FruitName).Equals((fruit.FruitName),StringComparison.OrdinalIgnoreCase)) 
                {
                    throw new AlreadyExistsException(" This Fruit name already Exists!");
                }
            }
            db.Fruits.Add(model);
            await db.SaveChangesAsync();
            return model;
        }
    }
}
