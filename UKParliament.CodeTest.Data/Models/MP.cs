namespace UKParliament.CodeTest.Data.Models
{
    public class MP : Person
    {
        public virtual Affiliation Affiliation { get; set; }

        public virtual Address Address { get; set; }
    }
}
