using Microsoft.AspNetCore.Identity;

namespace A24_420CW6_TP3_6280636.Models
{
    public class User : IdentityUser
    {
        public virtual List<Score> Scores { get; set; } = null!;
    }
}
