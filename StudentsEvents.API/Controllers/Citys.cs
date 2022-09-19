using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsEvents.API.Services;

namespace StudentsEvents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Citys : ControllerBase
    {
        private readonly IEventDataManaging _eventData;

        public Citys(IEventDataManaging eventData)
        {
            _eventData = eventData;
        }
        [HttpGet]
        public async Task<IActionResult> GetdDistinct()
        {
            return Ok(await _eventData.GetDistinctCitys());
        }
    }
}
