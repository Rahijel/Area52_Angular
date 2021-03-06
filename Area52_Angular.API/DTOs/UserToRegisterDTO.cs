using System.ComponentModel.DataAnnotations;

namespace Area52_Angular.API.DTOs
{
    public class UserToRegisterDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8 charackters")]
        public string Password { get; set; }
    }
}