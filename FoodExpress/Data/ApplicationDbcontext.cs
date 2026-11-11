using FoodExpress.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodExpress.Data
{
    public class ApplicationDbcontext :DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext>options):base(options)
        {

        }
       public DbSet<Category> categories { get; set; }
        public DbSet<FoodItem> foodItems { get; set; }
    }
}
