using Microsoft.AspNetCore.Mvc;
using FoodExpress.Data;
using FoodExpress.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodExpress.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemsApiController : ControllerBase
    {
        private readonly ApplicationDbcontext _context;

        public FoodItemsApiController(ApplicationDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItem>>> GetFoodItems()
        {
            return await _context.foodItems
                .Include(f => f.Category)
                .ToListAsync();
        }
    }
}