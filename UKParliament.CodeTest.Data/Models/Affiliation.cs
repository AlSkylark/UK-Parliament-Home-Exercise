using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace UKParliament.CodeTest.Data.Models
{
    public class Affiliation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AffiliationId { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }

    }
}
