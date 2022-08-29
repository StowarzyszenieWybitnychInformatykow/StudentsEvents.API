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
        public async Task<PagedList<EventModel>> GetAllAsync(PagingModel paging)
        {
            var data = _mapper.Map<IEnumerable<EventModel>>(await _eventData.GetEventsAsync());

            return PagedList<EventModel>.ToPagedList(data.OrderBy(x => x.StartDate),
                        paging.PageNumber,
                        paging.PageSize);
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

        public async Task UpdateAsync(EventModel modified)
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
