using System.ComponentModel.DataAnnotations;

namespace BandRegister.Models
{
    public class Band
    {
        // • id – technology-dependent identifier (ObjectID for JavaScript, int for all other technologies)
        public int Id { get; set; }

        // • name – non-empty text//
        [Required]
        public string Name { get; set; }

        // • members – non-empty text
        [Required]
        public string Members { get; set; }

        // • honorarium – non-null floating-point number
        [Required]
        public float Honorarium { get; set; }

        // • genre – non empty text
        [Required]
        public string Genre { get; set; }

    }
}
