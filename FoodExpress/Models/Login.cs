using System.ComponentModel.DataAnnotations;

namespace FoodExpress.Models
{
    public class Login
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string password { get; set; }
        public bool RememberMe { get; set; }

    }
}