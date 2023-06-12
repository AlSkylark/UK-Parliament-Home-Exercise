using System.ComponentModel.DataAnnotations;

namespace UKParliament.CodeTest.Web.EditModels
{
    public class MPEditModel
    {

        [Required(ErrorMessage = "Name is Required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date of Birth is Required!")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Affiliation is Required!")]
        public int AffiliationId { get; set; }

        public int AddressId { get; set; }

        [Required(ErrorMessage = "Address is Required!")]
        public string Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? Town { get; set; }

        [Required(ErrorMessage = "County is Required!")]
        public string County { get; set; }

        [Required(ErrorMessage = "Postcode is Required!")]
        public string Postcode { get; set; }

    }
}
