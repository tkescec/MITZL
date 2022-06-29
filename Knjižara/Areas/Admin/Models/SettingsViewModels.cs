using Knjižara.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Knjižara.Areas.Admin.Models
{
    public class SettingsViewModel
    {
        public int Idknjizara { get; set; }

        [Required]
        public string? Naziv { get; set; }

        [Required]
        public string? Adresa { get; set; }

        [Required]
        [Oib]
        public string? Oib { get; set; }

        [Required]
        public string? Iban { get; set; }

        [Required]
        public string? Logo { get; set; }

        public string? UvjetiKoristenja { get; set; }

        public bool Success { get; set; }
    }
}
