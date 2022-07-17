using PRAPristupBazi.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Knjižara.Models
{
    public class KorisnikViewModel
    {
        public Korisnik korisnik = new Korisnik();
        public IList<Racun> posljednjeKupnje = new List<Racun>();
    }

    public class EditKorisnikViewModel
    {
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka", Prompt = "Lozinka")]
        public string? Password { get; set; }  
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka", Prompt = "Lozinka")]
        public string? PasswordSecond { get; set; }
        [Required]
        [Display(Name = "Ime", Prompt = "Ime")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Prezime", Prompt = "Prezime")]
        public string? LastName { get; set; }
        [Required]
        [Display(Name = "Adresa", Prompt = "Adresa")]
        public string? Address { get; set; }
        [Required]
        [Display(Name = "Poštanski broj", Prompt = "Poštanski broj")]
        public string? PostalCode { get; set; }
         [Required]
        [Display(Name = "Grad", Prompt = "Grad")]
        public string? City { get; set; } 
        [Required]
        [Display(Name = "Država", Prompt = "Država")]
        public string? Country { get; set; }




    }
}
