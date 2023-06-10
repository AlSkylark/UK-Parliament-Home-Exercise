using System.ComponentModel.DataAnnotations;

namespace UKParliament.CodeTest.Data
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; } = "United Kingdom";
    }
}
