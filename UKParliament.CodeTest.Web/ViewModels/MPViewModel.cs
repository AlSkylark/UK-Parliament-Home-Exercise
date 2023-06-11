using System.Drawing;
using UKParliament.CodeTest.Data.Models;

namespace UKParliament.CodeTest.Web.ViewModels
{
    public class MPViewModel
    {
        public MPViewModel(MP mp)
        {
            PersonId = mp.PersonId;
            Name = mp.Name;
            AffiliationName = mp.Affiliation.Name;
            AffiliationColour = ColorTranslator.ToHtml(mp.Affiliation.Color);
            AddressCounty = mp.Address.County;
        }

        public int PersonId { get; private set; }
        public string Name { get; set; }
        public string AffiliationName { get; set; }
        public string AffiliationColour { get; set; }
        public string AddressCounty { get; set; }

    }
}
