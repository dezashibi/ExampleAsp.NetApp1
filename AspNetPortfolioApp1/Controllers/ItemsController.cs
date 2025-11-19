using AspNetPortfolioApp1.Data;
using AspNetPortfolioApp1.Models;
using Microsoft.AspNetCore.Mvc;
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
        var items = await _context.Items.ToListAsync();
        return View(items);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("Id, Name, Price")] Item item)
    {
        if (ModelState.IsValid)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(item);
    }

    public IActionResult Edit(int id)
    {
        return Content($"id = {id}");
    }
}