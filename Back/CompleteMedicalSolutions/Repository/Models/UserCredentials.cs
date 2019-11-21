using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class UserCredentials
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}