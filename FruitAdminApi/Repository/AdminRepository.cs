  using FruitUserApi.Data;
using FruitUserApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitAdminApi.Repository
{
    public class AdminRepository
    {
        private readonly FruitVendorContext db = null;
        public AdminRepository()
        {
            db = new FruitVendorContext();
        }
        //get All Admins
        public List<Admin> GetAll()
        {
           return db.Admins.ToList();
        }
        //Create Admin
        public async Task<Admin> CreateAdmin(Admin admin)
        {
            
            db.Admins.Add(admin);
            await db.SaveChangesAsync();
            CreatePerson(admin);
            return admin;
             
        }
        //Create Person as Admin
        private void CreatePerson(Admin admin)
        {
            Person person = new()
            {
                PersonName = admin.AdminName,
                PersonPasswd = admin.AdminPasswd,
                Role = "admin",
                AdminId = admin.AdminId
            };
            db.Persons.Add(person);
            db.SaveChanges();
        }

        
        //Get Admin By Id
        public Admin GetAdminById(int id)
        {
            Admin admin = db.Admins.Find(id);
            return admin;
        }
    }
}
