using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineSweetShop.Models;

namespace OnlineSweetShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<OnlineSweetShop.Models.SweetCategory>? SweetCategory { get; set; }
        public DbSet<OnlineSweetShop.Models.SweetProduct>? SweetProduct { get; set; }
        public DbSet<OnlineSweetShop.Models.Order>? Order { get; set; }
        public DbSet<OnlineSweetShop.Models.Offer>? Offer { get; set; }
        public DbSet<OnlineSweetShop.Models.EventBookingReq>? EventBookingReq { get; set; }
        
    }
}