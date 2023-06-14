using System.Drawing;
using UKParliament.CodeTest.Data.Models;

namespace UKParliament.CodeTest.Web.ViewModels
{
    public static class MPViewModelMappers
    {
        public static MPViewModel MapToViewModel(this MP mp)
        {
            return new MPViewModel
            {
                PersonId = mp.PersonId,
                Name = mp.Name,
                AffiliationName = mp.Affiliation.Name,
                AffiliationColour = ColorTranslator.ToHtml(mp.Affiliation.Color),
                AddressCounty = mp.Address.County
            };
        }
    }
}
