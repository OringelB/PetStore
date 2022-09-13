using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStore.Models
{
    public class Animal 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalId { get; set; }

        [MaxLength(25)]
        [Required(ErrorMessage = "Name is Requirde")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is Requirde")]
        public int Age { get; set; }

        public string? Picture { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Description is Requirde")]
        public string? Description { get; set; }

        [Display(Name = "Choose the picture of your animal")]
        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }


        //Realtionships
        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }


 

    }
}
