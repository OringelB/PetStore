using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStore.Models
{
    public class Comment 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }

        [Display(Name = "Type your comment:")]
        [Required(ErrorMessage = "Please enter your comment")]
        [MaxLength(50)]
        public string? CommentData { get; set; }

        //Realtionships
        public int AnimalId { get; set; }
        public virtual Animal? Animal { get; set; }
    }
}
