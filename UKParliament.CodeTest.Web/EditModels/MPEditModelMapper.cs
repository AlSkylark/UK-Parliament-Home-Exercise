using UKParliament.CodeTest.Data.Models;

namespace UKParliament.CodeTest.Web.EditModels
{
    public static class MPEditModelMapper
    {
        public static MPEditModel MapToEditModel(this MP mp)
        {
            return new MPEditModel
            {
                Name = mp.Name,
                DOB = mp.DOB,
                AffiliationId = mp.Affiliation.AffiliationId,
                AddressId = mp.Address.AddressId,
                Address1 = mp.Address.Address1,
                Address2 = mp.Address.Address2,
                Town = mp.Address.Town,
                County = mp.Address.County,
                Postcode = mp.Address.Postcode,
            };
        }
    }
}
