using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Gym_Management.Models.Management;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Gym_Management.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutType> WorkoutTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Gear> Gear { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Customer_Workout> CustomersOnWorkouts { get; set; }

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
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}