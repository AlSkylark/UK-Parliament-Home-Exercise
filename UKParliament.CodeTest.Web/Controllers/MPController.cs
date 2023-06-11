using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Services.Interfaces;
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

            var list = rawData.Select(mp => new MPViewModel(mp)).ToList();

            return new MPPaginator(list)
            {
                CurrentPage = page,
                PageCount = count
            };
        }

        //[HttpPost]
        //public ActionResult<MP> Post(MP mp)
        //{

        //}
    }
}
