using System.ComponentModel.DataAnnotations;

namespace FoodExpress.Models
{
    public class FoodItem
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
