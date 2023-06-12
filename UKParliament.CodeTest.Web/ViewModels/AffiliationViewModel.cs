using System.Drawing;
using UKParliament.CodeTest.Data.Models;

namespace UKParliament.CodeTest.Web.ViewModels
{
    public class AffiliationViewModel
    {
        public AffiliationViewModel(Affiliation affi)
        {
            AffiliationId = affi.AffiliationId;
            Name = affi.Name;
            Colour = ColorTranslator.ToHtml(affi.Color);
        }

        public int AffiliationId { get; private set; }
        public string Name { get; set; }
        public string Colour { get; set; }
    }
}
