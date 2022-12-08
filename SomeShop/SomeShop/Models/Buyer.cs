using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace SomeShop.Models
{
    public class Buyer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter a Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter a Adress")]
        public string Adress { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}
