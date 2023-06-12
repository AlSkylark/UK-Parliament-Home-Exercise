using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Services.Interfaces;
using UKParliament.CodeTest.Web.ViewModels;

namespace UKParliament.CodeTest.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AffiliationController : ControllerBase
    {
        private readonly IAffiliationService _service;

        public AffiliationController(IAffiliationService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AffiliationViewModel>> GetAll()
        {
            var affis = _service.GetAll();
            return affis.Select(affi => new AffiliationViewModel(affi)).ToList();
        }
    }
}
