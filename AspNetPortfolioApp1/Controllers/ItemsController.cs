using AspNetPortfolioApp1.Data;
using AspNetPortfolioApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AspNetPortfolioApp1.Controllers;

public class ItemsController : Controller
{
    private readonly PortfolioApp1Context _context;
    public ItemsController(PortfolioApp1Context context)
    {
        _context = context;
    }

    /// <summary>
    /// Dummy endpoint to demonstrate passing a model to a view.
    /// </summary>
    public IActionResult Overview()
    {
        var item = new Item() { Name = "Keyboard" };
        return View(item);
    }

    public async Task<IActionResult> Index()
    {
        var items = await _context.Items
            .Include(s => s.SerialNumber)
            .Include(c => c.Category)
            .ToListAsync();

        return View(items);
    }

    public IActionResult Create()
    {
        ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("Id, Name, Price, CategoryId")] Item item)
    {
        if (ModelState.IsValid)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(item);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
        if (item == null)
        {
            return NotFound();
        }

        ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");

        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Price, CategoryId")] Item item)
    {
        if (id != item.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(item);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }

    [HttpPost, ActionName(nameof(Delete))]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
        if (item == null)
        {
            return NotFound();
        }

        _context.Items.Remove(item);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}