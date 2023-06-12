using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Services.Interfaces;
using UKParliament.CodeTest.Web.EditModels;
using UKParliament.CodeTest.Web.ViewModels;

namespace UKParliament.CodeTest.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MPController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IPersonService<MP> _service;

        public MPController(ILogger<MPController> logger, IPersonService<MP> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public ActionResult<MPPaginator> GetAll(int page)
        {
            var rawData = _service.GetAll(page);
            var count = _service.GetCount();
            //hardcoded limit
            decimal round = Math.Ceiling(count / 10.0M);
            count = (int)round;

            var list = rawData.Select(mp => mp.MapToViewModel()).ToList();

            return Ok(new MPPaginator(list)
            {
                CurrentPage = page,
                PageCount = count
            });
        }

        [HttpPost]
        public ActionResult<MPViewModel> Post([FromBody] MPEditModel mp,
            [FromServices] IAddressService addressService, [FromServices] IAffiliationService affiliationService)
        {

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
            var affi = affiliationService.Get(mp.AffiliationId);

            var toSend = new MP
            {
                Name = mp.Name,
                DOB = mp.DOB,
                Address = address,
                Affiliation = affi
            };

            if (!ModelState.IsValid)
            {
                //something
                return Problem();
            }

            var created = _service.Create(toSend);
            return Ok(created.MapToViewModel());
        }

        [Route("{id:int}")]
        [HttpGet]
        public ActionResult<MPEditModel> Get(int id)
        {
            var mp = _service.Get(id);
            return Ok(mp.MapToEditModel());
        }

        [Route("{id:int}")]
        [HttpPatch]
        public ActionResult<MPEditModel> Patch(int id, [FromBody] MPEditModel mp,
            [FromServices] IAffiliationService affiliationService)
        {
            //If you're wondering why PATCH instead of PUT, well
            //the idea behind PATCH is that you ONLY update what was 
            //changed, rather than the entire record!
            //For the sake of simplicity this acts more like a PUT request
            //but ideally I'd prefer to pass in only the necessary data

            if (!ModelState.IsValid)
            {
                //something
                return Problem();
            }

            var mpToPatch = _service.Get(id);
            var affi = affiliationService.Get(mp.AffiliationId);

            mpToPatch.Affiliation = affi;
            mpToPatch.Address.Address1 = mp.Address1;
            mpToPatch.Address.Address2 = mp.Address2;
            mpToPatch.Address.Town = mp.Town;
            mpToPatch.Address.County = mp.County;
            mpToPatch.Address.Postcode = mp.Postcode;
            mpToPatch.Name = mp.Name;
            mpToPatch.DOB = mp.DOB;

            var patched = _service.Update(mpToPatch);

            return Ok(patched.MapToEditModel());
        }

        [Route("{id:int}")]
        [HttpDelete]
        public ActionResult<MPEditModel> Delete(int id)
        {
            if (_service.Delete(id)) return NoContent();
            return Problem();
        }

    }
}
