using AspNetPortfolioApp1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetPortfolioApp1.Controllers;

public class ItemsController : Controller
{
    // GET
    public IActionResult Overview()
    {
        var item = new Item() { Name = "Keyboard" };
        return View(item);
    }

    public IActionResult Edit(int id)
    {
        return Content($"id = {id}");
    }
}