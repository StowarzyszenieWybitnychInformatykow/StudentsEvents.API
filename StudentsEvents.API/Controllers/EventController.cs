using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentsEvents.API.Models;
using StudentsEvents.Library.Data;

namespace StudentsEvents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEventData _eventData;

        public EventController(IMapper mapper, IEventData eventData)
        {
            _mapper = mapper;
            _eventData = eventData;
        }

        [HttpGet]
        public async Task<IEnumerable<EventData>> Get()
        {
            return _mapper.Map<IEnumerable<EventData>>(await _eventData.GetEventsAsync());
        }

        [HttpGet("{id}")]
        public async Task<EventData> Get(Guid id)
        {
            return _mapper.Map<EventData>(await _eventData.GetEventByIdAsync(id));
        }

        [HttpPost]
        public async void Post([FromBody] EventData data)
        {
            var eventToAdd = _mapper.Map<EventDatabaseModel>(data);
            await _eventData.CreateEventAsync(eventToAdd);
        }

        [HttpPut("{id}")]
        public async void Put(Guid id, [FromBody] EventData modified)
        {
            var eventToModify = _mapper.Map<EventDatabaseModel>(modified);
            await _eventData.UpdateEventAsync(eventToModify);
        }

        [HttpDelete("{id}")]
        public async void Delete(Guid id)
        {
            var model = Get(id);
            await _eventData.DeleteEventAsync(_mapper.Map<EventDatabaseModel>(model));
        }
    }
}
