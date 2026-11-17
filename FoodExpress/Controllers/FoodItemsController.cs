using FoodExpress.Data;
using FoodExpress.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

public class FoodItemsController : Controller
{
    private readonly ApplicationDbcontext _context;

    public FoodItemsController(ApplicationDbcontext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var foodItems = _context.foodItems
            .Include(f => f.Category);

        return View(await foodItems.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var fooditem = await _context.foodItems
            .Include(f => f.Category)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (fooditem == null)
            return NotFound();

        return View(fooditem);
    }

    // CREATE GET
    [Authorize]
    public IActionResult Create()
    {
        ViewBag.CategoryId = new SelectList(
            _context.categories,
            "Id",
            "Name");

        return View();
    }

    // CREATE POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(FoodItem foodItem)
    {
        if (ModelState.IsValid)
        {
            _context.Add(foodItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewBag.CategoryId = new SelectList(
            _context.categories,
            "Id",
            "Name",
            foodItem.CategoryId);

        return View(foodItem);
    }

    // EDIT GET
    
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var foodItem = await _context.foodItems.FindAsync(id);

        if (foodItem == null)
            return NotFound();

        ViewBag.CategoryId = new SelectList(
            _context.categories,
            "Id",
            "Name",
            foodItem.CategoryId);

        return View(foodItem);
    }

    // EDIT POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, FoodItem foodItem)
    {
        if (id != foodItem.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(foodItem);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        ViewBag.CategoryId = new SelectList(
            _context.categories,
            "Id",
            "Name",
            foodItem.CategoryId);

        return View(foodItem);
    }

    // DELETE GET
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var fooditem = await _context.foodItems
            .FirstOrDefaultAsync(m => m.Id == id);

        if (fooditem == null)
            return NotFound();

        return View(fooditem);
    }

    // DELETE POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var fooditem = await _context.foodItems.FindAsync(id);

        if (fooditem != null)
        {
            _context.foodItems.Remove(fooditem);
        }

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    private bool FoodItemExists(int id)
    {
        return _context.foodItems.Any(e => e.Id == id);
    }
}