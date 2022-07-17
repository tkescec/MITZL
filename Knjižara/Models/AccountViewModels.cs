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

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Ime", Prompt = "Ime")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Prezime", Prompt = "Prezime")]
        public string? LastName { get; set; }
        
        [DataType(DataType.PostalCode)]
        [Display(Name = "Poštanski broj", Prompt = "Poštanski broj")]
        public string? PostalCode { get; set; }
        
        [Display(Name = "Address", Prompt = "Address")]
        public string? Address { get; set; }
        
        [Display(Name = "Grad", Prompt = "Grad")]
        public string? City { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Email adresa", Prompt = "Email adresa")]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka", Prompt = "Lozinka")]
        public string? Password { get; set; }

    }
}
