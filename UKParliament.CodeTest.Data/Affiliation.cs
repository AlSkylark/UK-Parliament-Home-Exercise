using System.ComponentModel.DataAnnotations;

namespace UKParliament.CodeTest.Data
{
    public class Affiliation
    {
        [Key]
        public int AffiliationId { get; set; }
        public string Name { get; set; }

    }
}
