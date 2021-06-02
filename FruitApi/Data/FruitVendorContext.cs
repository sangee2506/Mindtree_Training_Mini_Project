using FruitUserApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitUserApi.Data
{
    public class FruitVendorContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=FruitBasketDbms;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one to many relationship of user-cart ,user-order
            modelBuilder.Entity<Cart>()
           .HasOne<User>(sc => sc.User)
           .WithMany(s => s.Carts)
           .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<Order>()
           .HasOne<User>(sc => sc.User)
           .WithMany(s => s.Orders)
           .HasForeignKey(sc => sc.UserId);

            //one to many relationship of Fruit-cart ,Fruit-order
            modelBuilder.Entity<Cart>()
           .HasOne<Fruit>(sc => sc.Fruit)
           .WithMany(s => s.Carts)
           .HasForeignKey(sc => sc.FruitId)
           .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Order>()
           .HasOne<Fruit>(sc => sc.Fruit)
           .WithMany(s => s.Orders)
           .HasForeignKey(sc => sc.FruitId)
           .OnDelete(DeleteBehavior.SetNull);





            //one to one relationship of user-person ,admin-person
            modelBuilder.Entity<User>()
           .HasOne<Person>(s => s.Person)
           .WithOne(ad => ad.User)
           .HasForeignKey<Person>(ad => ad.UserId)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Admin>()
           .HasOne<Person>(s => s.Person)
           .WithOne(ad => ad.Admin)
           .HasForeignKey<Person>(ad => ad.AdminId)
           .OnDelete(DeleteBehavior.Cascade);

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Fruit> Fruits { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Order> Orders { get; set; }

        





    }
}
