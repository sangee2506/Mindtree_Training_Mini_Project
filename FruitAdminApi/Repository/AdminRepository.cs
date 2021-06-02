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

        public List<Admin> GetAll()
        {
            return db.Admins.ToList();
        }

        public Admin CreateDataAsync(Admin admin)
        {
            
                db.Admins.Add(admin);
                 db.SaveChanges();
                 CreatePerson(admin);
            return admin;
             
        }

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

        

        internal Admin GetDataById(int id)
        {
            Admin admin = db.Admins.Find(id);
            return admin;
        }
    }
}
