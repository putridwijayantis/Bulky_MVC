using Bulky.DataAccess.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers;

public class CategoryController(ApplicationDbContext db) : Controller
{
    // GET
    public IActionResult Index()
    {
        List<Category> data = db.Categories.ToList();
        return View(data);
    }

    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (category.Name == category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The display order cannot exactly match the name of the category.");
        }

        if (!ModelState.IsValid) return View();
        db.Categories.Add(category);
        db.SaveChanges();
        TempData["success"] = "Category created";
        return RedirectToAction("Index");
    }
    
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        
        var category = db.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }
    
    [HttpPost]
    public IActionResult Edit(Category category)
    {
        if (!ModelState.IsValid) return View();
        db.Categories.Update(category);
        db.SaveChanges();
        TempData["success"] = "Category updated";
        return RedirectToAction("Index");
    }
    
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        
        var category = db.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }
    
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int? id)
    {
        var data = db.Categories.Find(id);

        if (data == null)
        {
            return NotFound();
        }
        
        db.Categories.Remove(data);
        db.SaveChanges();
        TempData["success"] = "Category deleted";
        return RedirectToAction("Index");
    }
}