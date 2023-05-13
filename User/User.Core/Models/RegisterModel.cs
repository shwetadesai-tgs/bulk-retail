using System.ComponentModel.DataAnnotations;

namespace User.Core.Models
{
    public class RegisterModel
    {
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
