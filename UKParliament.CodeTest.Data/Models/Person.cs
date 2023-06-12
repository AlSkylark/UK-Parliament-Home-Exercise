using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UKParliament.CodeTest.Data.Models
{
    public abstract class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateModified { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime DOB { get; set; }

    }
}