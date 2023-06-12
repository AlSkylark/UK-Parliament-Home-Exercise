using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UKParliament.CodeTest.Data.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }

        [Required]
        public string Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? Town { get; set; }

        [Required]
        public string County { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Required]
        public string Country { get; set; } = "United Kingdom";
    }
}
