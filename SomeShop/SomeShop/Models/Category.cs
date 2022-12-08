using System.ComponentModel.DataAnnotations;

namespace SomeShop.Models
{
    public class Category
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Please enter a Category Name")]
        public string Name { get; set; }
        
        public string Slug { get; set; }
    }
}
