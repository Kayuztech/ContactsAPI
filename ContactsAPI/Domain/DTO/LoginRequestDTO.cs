using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Domain.DTO
{
    public class LoginRequestDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
