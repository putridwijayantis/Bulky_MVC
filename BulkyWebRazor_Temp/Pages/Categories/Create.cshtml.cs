using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories;

[BindProperties]
public class Create(ApplicationDbContext db) : PageModel
{
    public Category Category { get; set; }
    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        db.Categories.Add(Category);
        db.SaveChanges();
        TempData["success"] = "Category created successfully";
        return RedirectToPage("Index");
    }
}