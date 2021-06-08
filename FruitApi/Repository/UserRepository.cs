using FruitUserApi.CustomException;
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

        public async Task<List<User>> GetAllDataAsync()
        {
            return await db.Users.ToListAsync();
        }
       
        public async Task<bool> CreateDataAsync(User user)
        {
            var phoneNumberExist = db.Users.Where(n => n.MobNum == user.MobNum).FirstOrDefault();// checks Phone is pesent or not
            var emailExist = db.Users.Where(n => n.Email == user.Email).FirstOrDefault();// checks email is pesent or not
                if (phoneNumberExist == null)
                {
                    if(emailExist == null)
                    {
                        db.Users.Add(user);
                        await db.SaveChangesAsync();
                        await CreatePersonAsync(user);
                        return true;
                    }
                    else
                    {
                        throw new EmailExistException("Dear User this Email Id:\t" + user.Email + "\tis already present in our records  :(");
                    }  
                }
                else
                {
                    throw new PhoneNumberExistsException("Dear User this Phone No.:\t"+user.MobNum+"\tis already present in our records  :(");
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
            var phoneNumberExist = db.Users.Where(n => n.MobNum == user.MobNum).FirstOrDefault();// checks Phone is pesent or not
            var emailExist = db.Users.Where(n => n.Email == user.Email).FirstOrDefault();// checks email is pesent or not
            if (phoneNumberExist == null)
            {
                if (emailExist == null)
                {
                    db.Users.Update(user);
                    await db.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new EmailExistException("Dear User this Email Id:\t" + user.Email + "\tis already present in our records  :(");
                }
            }
            else
            {
                throw new PhoneNumberExistsException("Dear User this Phone No.:\t" + user.MobNum + "\tis already present in our records  :(");
            }
        }
    }
}
