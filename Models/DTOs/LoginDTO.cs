using System.ComponentModel.DataAnnotations;

namespace A24_420CW6_TP3_6280636.Models.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
