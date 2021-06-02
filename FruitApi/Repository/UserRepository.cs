using FruitUserApi.Data;
using FruitUserApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitUserApi.Repository
{
    public class UserRepository
    {
        private readonly FruitVendorContext db = null;
        public UserRepository()
        {
            db = new FruitVendorContext();
        }

        /*public List<Author> GetAllData()
        {
            return db.Authers.ToList();
        }
        [HttpGet]*/
        public async Task<List<User>> GetAllDataAsync()
        {
            return await db.Users.ToListAsync();
        }
       /* internal bool CreateData(Author user)
        {
            if (user != null)
            {
                db.Authers.Add(user);
                return true;
            }
            else
            {
                return false;
            }
            
        }*/
        public async Task<bool> CreateDataAsync(User user)
        {
         
            if (user != null)
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                await CreatePersonAsync(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task CreatePersonAsync(User user)
        {
            Person person = new()
            {
                PersonName = user.UserName,
                PersonPasswd = user.UserPasswd,
                Role = "user",
                UserId = user.UserId
            };
            db.Persons.Add(person);
            await db.SaveChangesAsync();
        }
    }
}
