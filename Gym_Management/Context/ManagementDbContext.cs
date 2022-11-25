using Gym_Management.Models.Management;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Gym_Management.Context
{
    public class ManagementDbContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutType> WorkoutTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Gear> Gear { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer_Workout>().HasKey(cw => new
            {
                cw.CustomerId,
                cw.WorkoutId
            });
            modelBuilder.Entity<Customer_Workout>().HasRequired(cw => cw.Customer).WithMany(cw => cw.Customer_Workouts);
            modelBuilder.Entity<Customer_Workout>().HasRequired(cw => cw.Workout).WithMany(cw => cw.Customer_Workouts);
            base.OnModelCreating(modelBuilder);
        }
    }
    
}