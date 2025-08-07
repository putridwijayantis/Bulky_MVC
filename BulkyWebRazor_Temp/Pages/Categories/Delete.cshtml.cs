using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories;

[BindProperties]
public class Delete(ApplicationDbContext db) : PageModel
{
    public Category Category { get; set; }

    public void OnGet(int? id)
    {
        if (id != null && id != 0)
        {
            Category = db.Categories.Find(id);
        }
    }

    public IActionResult OnPost()
    {
        var data = db.Categories.Find(Category.Id);

        if (data == null)
        {
            return NotFound();
        }
        
        db.Categories.Remove(data);
        db.SaveChanges();
        TempData["success"] = "Category deleted successfully";
        return RedirectToPage("Index");
    }
}