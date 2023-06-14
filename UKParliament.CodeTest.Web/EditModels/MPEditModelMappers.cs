using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Services.Interfaces;

namespace UKParliament.CodeTest.Web.EditModels
{
    public static class MPEditModelMappers
    {
        /// <summary>
        /// Maps an MP domain model to an MPEditModel edit model to be used in updating or creating.
        /// </summary>
        /// <param name="mp"></param>
        /// <returns></returns>
        public static MPEditModel MapToEditModel(this MP mp)
        {
            return new MPEditModel
            {
                PersonId = mp.PersonId,
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


        /// <summary>
        /// Converts an MPEditModel edit model into an MP domain model to send to create a new MP.
        /// </summary>
        /// <param name="mp"></param>
        /// <param name="addressService"></param>
        /// <param name="affiliationService"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static MP MapToMP(this MPEditModel mp, IAddressService addressService, IAffiliationService affiliationService)
        {
            //in theory they should never be null as they come from the Create or Patch
            //and the ModelState.IsValid is checked before they even reach the code
            //in practice these should still be considered!
            if (mp.AffiliationId == null || mp.DOB == null) throw new Exception();

            //make the address + affi
            var address = new Address
            {
                Address1 = mp.Address1,
                Address2 = mp.Address2,
                Town = mp.Town,
                County = mp.County,
                Postcode = mp.Postcode
            };
            address = addressService.Create(address);
            var affi = affiliationService.Get((int)mp.AffiliationId);

            return new MP
            {
                Name = mp.Name,
                DOB = (DateTime)mp.DOB,
                Address = address,
                Affiliation = affi
            };
        }


        /// <summary>
        /// Modifies an MP using the data from the MPEditModel, readies it to be updated.
        /// </summary>
        /// <param name="mp"></param>
        /// <param name="patch"></param>
        /// <param name="affiliationService"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static MP PatchMP(this MP mp, MPEditModel patch, IAffiliationService affiliationService)
        {
            //Same here!
            if (patch.AffiliationId == null || patch.DOB == null) throw new Exception();

            if (mp.Affiliation.AffiliationId != patch.AffiliationId)
            {
                var affi = affiliationService.Get((int)patch.AffiliationId);
                mp.Affiliation = affi;
            }

            mp.Address.Address1 = patch.Address1;
            mp.Address.Address2 = patch.Address2;
            mp.Address.Town = patch.Town;
            mp.Address.County = patch.County;
            mp.Address.Postcode = patch.Postcode;
            mp.Name = patch.Name;
            mp.DOB = (DateTime)patch.DOB;

            return mp;
        }

    }
}
