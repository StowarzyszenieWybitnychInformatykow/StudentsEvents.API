using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentsEvents.API.Models;
using StudentsEvents.API.Services;

namespace StudentsEvents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventDataManaging _eventData;

        public EventsController(IEventDataManaging eventData)
        {
            _eventData = eventData;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PagingModel paging)
        {
            var owners = await _eventData.GetAllAsync(paging);
            var metadata = new
            {
                owners.TotalCount,
                owners.PageSize,
                owners.CurrentPage,
                owners.TotalPages,
                owners.HasNext,
                owners.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(owners);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _eventData.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EventModel data)
        {
            await _eventData.CreateAsync(data);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EventModel modified)
        {
            await _eventData.UpdateAsync(modified);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _eventData.DeleteAsync(id);
            return Ok();
        }
    }
}
