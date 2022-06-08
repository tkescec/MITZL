using System.ComponentModel.DataAnnotations;

namespace Knjižara.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email adresa", Prompt = "Email adresa")]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka", Prompt = "Lozinka")]
        public string? Password { get; set; }

        [Display(Name = "Zapamti me?")]
        public bool RememberMe { get; set; }
    }
}
