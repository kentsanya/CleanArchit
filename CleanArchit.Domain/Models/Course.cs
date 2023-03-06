using CleanArchit.Domain.Models.AtributesValidation;
using System.ComponentModel.DataAnnotations;

namespace CleanArchit.Domain.Models
{
    public class Course
    {

        [Required]
        public int Id { get; set; }


        [Required(ErrorMessage ="Name must be ...")]
        public string Name { get; set; }


        [StringLength(100)]
        public string Description { get; set; }
        
        [Required]
        public string Author { get; set; }

        [Range(1,1000000)]
        public decimal Price { get; set; }
        

    }
}
