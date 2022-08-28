using AutoMapper;
using StudentsEvents.API.Models;
using StudentsEvents.Library.Data;

namespace StudentsEvents.API.Services
{
    public class EventDataManaging : IEventDataManaging
    {
        private readonly IMapper _mapper; 
        private readonly IEventData _eventData;

        public EventDataManaging(IMapper mapper, IEventData eventData)
        {
            _mapper = mapper;
            _eventData = eventData;
        }
        public async Task<IEnumerable<EventModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<EventModel>>(await _eventData.GetEventsAsync());
        }

        public async Task<EventModel> GetByIdAsync(Guid id)
        {
            return _mapper.Map<EventModel>(await _eventData.GetEventByIdAsync(id));
        }

        public async Task CreateAsync(EventModel data)
        {
            var eventToAdd = _mapper.Map<EventDatabaseModel>(data);
            await _eventData.CreateEventAsync(eventToAdd);
        }

        public async Task UpdateAsync(Guid id, EventModel modified)
        {
            var eventToModify = _mapper.Map<EventDatabaseModel>(modified);
            await _eventData.UpdateEventAsync(eventToModify);
        }
        public async Task DeleteAsync(Guid id)
        {
            var model = GetByIdAsync(id);
            await _eventData.DeleteEventAsync(_mapper.Map<EventDatabaseModel>(model));
        }
    }
}
