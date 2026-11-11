
using FoodExpress.Data;
using FoodExpress.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class FoodItemsController : Controller
{
    private readonly ApplicationDbcontext _context;

    public FoodItemsController(ApplicationDbcontext context)
    {
        _context = context;
    }

    // GET: FOODITEMS
    public async Task<IActionResult> Index()
    {
        var foodItems = _context.foodItems
            .Include(f => f.Category);

        return View(await foodItems.ToListAsync());
    }


    // GET: FOODITEMS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var fooditem = await _context.foodItems
            .FirstOrDefaultAsync(m => m.Id == id);
        if (fooditem == null)
        {
            return NotFound();
        }

        return View(fooditem);
    }

    // GET: FOODITEMS/Create
    public IActionResult Create()
    {
        ViewBag.CategoryId = new SelectList(
            _context.foodItems,
            "Id",
            "Name");

        return View();
    }

    // POST: FOODITEMS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Create(FoodItem foodItem)
    {
        if (ModelState.IsValid)
        {
            _context.Add(foodItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewBag.CategoryId = new SelectList(
            _context.foodItems,
            "Id",
            "Name",
            foodItem.CategoryId);

        return View(foodItem);
    }

    // GET: FOODITEMS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var foodItem = await _context.foodItems.FindAsync(id);

        if (foodItem == null)
        {
            return NotFound();
        }

        ViewBag.CategoryId = new SelectList(
            _context.foodItems,
            "Id",
            "Name",
            foodItem.CategoryId);

        return View(foodItem);
    }

    // POST: FOODITEMS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Edit(int id, FoodItem foodItem)
    {
        if (id != foodItem.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(foodItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewBag.CategoryId = new SelectList(
            _context.foodItems,
            "Id",
            "Name",
            foodItem.CategoryId);

        return View(foodItem);
    }

    // GET: FOODITEMS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var fooditem = await _context.foodItems
            .FirstOrDefaultAsync(m => m.Id == id);
        if (fooditem == null)
        {
            return NotFound();
        }

        return View(fooditem);
    }

    // POST: FOODITEMS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var fooditem = await _context.foodItems.FindAsync(id);
        if (fooditem != null)
        {
            _context.foodItems.Remove(fooditem);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool FoodItemExists(int? id)
    {
        return _context.foodItems.Any(e => e.Id == id);
    }
}
