using System.ComponentModel.DataAnnotations;

namespace DellChallenge.D1.Api.Dto
{
    public class NewProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
