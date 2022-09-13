using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStore.Models
{
    public class Category 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Category name is Requirde")]
        [Display(Name = "Category name:")]
        public int CategoryId { get; set; }

        [Display(Name = "Category name:")]
        [Required(ErrorMessage = "Category name is Requirde")]
        public string? CategoryName { get; set; }

        //Realtionships
        public virtual ICollection<Animal>? Animals { get; set; }
    }
}
