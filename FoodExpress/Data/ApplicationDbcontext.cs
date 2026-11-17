using FoodExpress.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FoodExpress.Data
{
    public class ApplicationDbcontext :IdentityDbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext>options):base(options)
        {

        }
       public DbSet<Category> categories { get; set; }
        public DbSet<FoodItem> foodItems { get; set; }
    }
}
