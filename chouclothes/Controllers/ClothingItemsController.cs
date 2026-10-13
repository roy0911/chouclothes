
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using chouclothes.Models;
using chouclothes.Data;

public class ClothingItemsController : Controller
{
    private readonly AppDbContext _context;

    public ClothingItemsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: CLOTHINGITEMS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.ClothingItems.ToListAsync());
    }

    // GET: CLOTHINGITEMS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var clothingitem = await _context.ClothingItems
            .FirstOrDefaultAsync(m => m.Id == id);
        if (clothingitem == null)
        {
            return NotFound();
        }

        return View(clothingitem);
    }

    // GET: CLOTHINGITEMS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CLOTHINGITEMS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Category,Size,Price,StockQuantity")] ClothingItem clothingitem)
    {
        if (ModelState.IsValid)
        {
            _context.Add(clothingitem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(clothingitem);
    }

    // GET: CLOTHINGITEMS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var clothingitem = await _context.ClothingItems.FindAsync(id);
        if (clothingitem == null)
        {
            return NotFound();
        }
        return View(clothingitem);
    }

    // POST: CLOTHINGITEMS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Category,Size,Price,StockQuantity")] ClothingItem clothingitem)
    {
        if (id != clothingitem.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(clothingitem);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothingItemExists(clothingitem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(clothingitem);
    }

    // GET: CLOTHINGITEMS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var clothingitem = await _context.ClothingItems
            .FirstOrDefaultAsync(m => m.Id == id);
        if (clothingitem == null)
        {
            return NotFound();
        }

        return View(clothingitem);
    }

    // POST: CLOTHINGITEMS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var clothingitem = await _context.ClothingItems.FindAsync(id);
        if (clothingitem != null)
        {
            _context.ClothingItems.Remove(clothingitem);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ClothingItemExists(int? id)
    {
        return _context.ClothingItems.Any(e => e.Id == id);
    }
}
