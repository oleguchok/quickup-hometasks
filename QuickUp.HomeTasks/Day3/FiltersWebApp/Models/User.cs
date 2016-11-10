using System.ComponentModel.DataAnnotations;
using FiltersWebApp.Core;

namespace FiltersWebApp.Models
{
    public class User
    {

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 6)]
        public string Password { get; set; }
        [AgeValidation(12)]
        public int Age { get; set; }
    }
}
