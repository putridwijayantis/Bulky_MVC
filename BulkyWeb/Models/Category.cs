using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    [DisplayName("Category Name")] 
    public string Name { get; set; }

    [Required]
    [Range(1,1000, ErrorMessage = "Display Order must be between 1 and 1000")]
    [DisplayName("Display Order")] public int DisplayOrder { get; set; }
}