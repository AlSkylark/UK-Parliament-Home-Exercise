namespace UKParliament.CodeTest.Data
{
    public class MP : Person
    {
        //foreign
        public Affiliation Affiliation { get; set; }

        //foreign
        public Address Address { get; set; }
    }
}
