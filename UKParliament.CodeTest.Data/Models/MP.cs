namespace UKParliament.CodeTest.Data.Models
{
    public class MP : Person
    {

        //foreign
        public virtual Affiliation Affiliation { get; set; }

        //foreign
        public virtual Address Address { get; set; }
    }
}
