using AutoMapper;
using StudentsEvents.API.Filtering;
using StudentsEvents.API.Models;
using StudentsEvents.Library.Data;
using StudentsEvents.Library.Models;

namespace StudentsEvents.API.Services
{
    public class EventDataManaging : IEventDataManaging
    {
        private readonly IMapper _mapper;
        private readonly IEventData _eventData;
        private readonly IFilterService _filter;

        public EventDataManaging(IMapper mapper, IEventData eventData, IFilterService filter)
        {
            _mapper = mapper;
            _eventData = eventData;
            _filter = filter;
        }
        public async Task<PagedList<EventModel>> GetAllAsync(PagingModel paging, FilterModel filter)
        {

            return PagedList<EventModel>.ToPagedList(_mapper, _filter.GetSpecificData(await _eventData.GetEventsAsync(), filter).OrderBy(x => x.StartDate),
                        paging.PageNumber,
                        paging.PageSize);
        }
        public async Task<PagedList<EventModel>> GetPublishedAsync(PagingModel paging, FilterModel filter)
        {
            return PagedList<EventModel>.ToPagedList(_mapper, _filter.GetSpecificData(await _eventData.GetPublishedEventsAsync(), filter).OrderBy(x => x.StartDate),
                        paging.PageNumber,
                        paging.PageSize);
        }
        public async Task<PagedList<EventModel>> GetUnfinishedAsync(PagingModel paging, FilterModel filter)
        {
            return PagedList<EventModel>.ToPagedList(_mapper, _filter.GetSpecificData(await _eventData.GetUnfinishedEventsAsync(),filter).OrderBy(x => x.StartDate),
                        paging.PageNumber,
                        paging.PageSize);
        }
        public async Task<PagedList<EventModel>> GetUnpublishedAsync(PagingModel paging, FilterModel filter)
        {
            return PagedList<EventModel>.ToPagedList(_mapper, _filter.GetSpecificData(await _eventData.GetUnpublishedEventsAsync(), filter).OrderBy(x => x.StartDate),
                        paging.PageNumber,
                        paging.PageSize);
        }
        public async Task<PagedList<EventModel>> GetMyAsync(PagingModel paging, FilterModel filter, string Id)
        {
            return PagedList<EventModel>.ToPagedList(_mapper, _filter.GetSpecificData(await _eventData.GetMyEventsAsync(Id), filter).OrderBy(x => x.StartDate),
                        paging.PageNumber,
                        paging.PageSize);
        }

        public async Task<EventModel> GetByIdAsync(Guid id)
        {
            return _mapper.Map<EventModel>(await _eventData.GetEventByIdAsync(id));
        }
        public async Task PublishEventAsync(Guid id)
        {
            await _eventData.PublishEventAsync(id);
        }
        public async Task UnpublishEventAsync(Guid id)
        {
            await _eventData.UnpublishEventAsync(id);
        }
        public async Task CreateAsync(EventAddModel data, string userId)
        {
            var model = new EventModel
            {
                Id = Guid.NewGuid(),
                Name = data.Name,
                ShortDescription = data.ShortDescription,
                Thumbnail = data.Thumbnail,
                Background = data.Background,
                Facebook = data.Facebook,
                Website = data.Website,
                Language = data.Language,
                Upvotes = 0,
                Registration = data.Registration,
                Tickets = data.Tickets,
                Online = data.Online,
                Location = data.Location,
                Latitude = data.Latitude,
                Longitude = data.Longitude,
                City = data.City,
                Tags = data.Tags,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                StudentGovernmentId = 0,
                Published = false,
                OwnerID = userId,
                Organization = "",
                LastModified = DateTimeOffset.UtcNow
            };
            var eventToAdd = _mapper.Map<EventDatabaseModel>(model);
            await _eventData.CreateEventAsync(eventToAdd);
        }

        public async Task UpdateAsync(EventModel modified)
        {
            var eventToModify = _mapper.Map<EventDatabaseModel>(modified);
            await _eventData.UpdateEventAsync(eventToModify);
        }
        public async Task DeleteAsync(Guid id)
        {
            //var model = GetByIdAsync(id);
            await _eventData.DeleteEventAsync(id);
        }

        public async Task<IEnumerable<string>> GetDistinctCitys()
        {
            return await _eventData.GetAllDistinctCitysAsync();
        }
    }
}
