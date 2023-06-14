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
        public ActionResult<MPPaginator> GetAll(int page, int id)
        {
            //we fetch either a specific page where the ID is or 
            //the specific page requested
            IEnumerable<MP> rawData;
            if (id > 0)
            {
                var data = _service.GetSpecificPage(id);
                rawData = data.Item1;
                page = data.Item2;
            }
            else
            {
                rawData = _service.GetAll(page);
            }
            if (rawData == null) return NotFound();

            var count = _service.GetCount();
            //hardcoded limit
            int round = (int)Math.Ceiling(count / 10.0M);

            var list = rawData.Select(mp => mp.MapToViewModel()).ToList();

            return Ok(new MPPaginator(list)
            {
                TotalItems = count,
                CurrentPage = page,
                PageCount = round
            });
        }

        [HttpPost]
        public ActionResult<MPViewModel> Post([FromBody] MPEditModel mp,
            [FromServices] IAddressService addressService, [FromServices] IAffiliationService affiliationService)
        {
            var toSend = mp.MapToMP(addressService, affiliationService);
            var created = _service.Create(toSend);

            if (created == null) return Problem();
            _logger.Log(LogLevel.Information, "MP Created", created);
            return Ok(created.MapToViewModel());
        }

        [Route("{id:int}")]
        [HttpGet]
        public ActionResult<MPEditModel> Get(int id)
        {
            var mp = _service.Get(id);
            if (mp == null) return NotFound();
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
            var mpToPatch = _service.Get(id);
            var toSend = mpToPatch.PatchMP(mp, affiliationService);

            var patched = _service.Update(toSend);
            if (patched == null) return Problem();
            _logger.Log(LogLevel.Information, "MP Updated", patched);
            return Ok(patched.MapToEditModel());
        }

        [Route("{id:int}")]
        [HttpDelete]
        public ActionResult<MPEditModel> Delete(int id)
        {
            if (_service.Delete(id))
            {
                _logger.Log(LogLevel.Information, "MP Deleted", id);
                return NoContent();
            }
            return Problem();
        }

    }
}
