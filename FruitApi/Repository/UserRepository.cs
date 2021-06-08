﻿using FruitUserApi.Data;
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

        public async Task<List<User>> GetAllDataAsync()
        {
            return await db.Users.ToListAsync();
        }
       
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

        public async Task<User> GetDataByUserId(int userId)
        {
            return await db.Users.FindAsync(userId);
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

        public async Task<bool> UpdateData(User user)
        {
            if (user != null)
            {
                db.Users.Update(user);
                await db.SaveChangesAsync();
                return  true;
            }
            else
            {
                return false;
            }
        }
    }
}
