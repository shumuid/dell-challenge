using System.ComponentModel.DataAnnotations;

namespace DellChallenge.D2.Web.Models
{
    public class NewProductModel
    {
        [Required(ErrorMessage = "The 'Name' field is required.")]
        [StringLength(64)]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The 'Category' field is required.")]
        [StringLength(32)]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid Category")]
        public string Category { get; set; }
    }
}
