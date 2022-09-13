using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class User 
    {
        [Key]
        public int UserId { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Please enter a username")]
        public string UserName { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Please enter a password")]
        public string Password { get; set; }
        [Required]
        public int UserRank { get; set; }
    }
}
