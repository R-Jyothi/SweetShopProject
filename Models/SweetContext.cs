using Microsoft.EntityFrameworkCore;
using OnlineSweetShop.Models;

namespace OnlineSweetShop.Models
{
    public class SweetContext :DbContext
    {
        public SweetContext(DbContextOptions<SweetContext> options) : base(options)
        {

        }
        public DbSet<SweetCategory> SweetCategories { get; set; }
        public DbSet<SweetProduct> SweetProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<AspNetUser> aspNetUsers { get; set; }
        public DbSet<EventBookingReq> EventBookingReqs { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Contact> Contacts { get; set; }


    }
}
 