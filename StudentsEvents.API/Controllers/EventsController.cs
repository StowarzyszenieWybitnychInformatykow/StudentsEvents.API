using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentsEvents.API.Models;
using StudentsEvents.API.Services;
using StudentsEvents.Library.Data;

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
        public async Task<IEnumerable<EventModel>> Get()
        {
            return await _eventData.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<EventModel> Get(Guid id)
        {
            return await _eventData.GetByIdAsync(id);
        }

        [HttpPost]
        public async void Create([FromBody] EventModel data)
        {
            await _eventData.CreateAsync(data);
        }

        [HttpPut("{id}")]
        public async void Put(Guid id, [FromBody] EventModel modified)
        {
            await _eventData.UpdateAsync(id, modified);
        }

        [HttpDelete("{id}")]
        public async void Delete(Guid id)
        {
            await _eventData.DeleteAsync(id);
        }
    }
}
