using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Services;

namespace UKParliament.CodeTest.Web.Controllers
{
    public class MPController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IPersonService<MP> _service;

        public MPController(ILogger<MPController> logger, MPService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<MP>> GetAll(bool expanded)
        {
            var list = _service.GetAll(expanded);
            return (List<MP>)list;
        }
    }
}
