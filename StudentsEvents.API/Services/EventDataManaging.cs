using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using StudentsEvents.API.Controllers;
using StudentsEvents.API.Models;
using StudentsEvents.Library.Data;
using StudentsEvents.Library.DBEntityModels;
using StudentsEvents.Library.Models;
using System.Xml.Linq;

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

            return PagedList<EventModel>.ToPagedList(_mapper, _filter.GetSpecificData(await _eventData.GetEventsAsync(), filter)
                .OrderBy(x => x.StartDate),
                        paging.PageNumber,
                        paging.PageSize);
        }
        public async Task<PagedList<EventModel>> GetPublishedAsync(PagingModel paging, FilterModel filter)
        {
            return PagedList<EventModel>.ToPagedList(_mapper, _filter.GetSpecificData(await _eventData.GetPublishedEventsAsync(), filter)
                .OrderBy(x => x.StartDate),
                        paging.PageNumber,
                        paging.PageSize);
        }
        public async Task<PagedList<EventModel>> GetUnfinishedAsync(PagingModel paging, FilterModel filter)
        {
            return PagedList<EventModel>.ToPagedList(_mapper, _filter.GetSpecificData(await _eventData.GetUnfinishedEventsAsync(), filter)
                .OrderBy(x => x.StartDate),
                        paging.PageNumber,
                        paging.PageSize);
        }
        public async Task<PagedList<EventModel>> GetUnpublishedAsync(PagingModel paging, FilterModel filter)
        {
            return PagedList<EventModel>.ToPagedList(_mapper, _filter.GetSpecificData(await _eventData.GetUnpublishedEventsAsync(), filter)
                .OrderByDescending(x => x.LastModified),
                        paging.PageNumber,
                        paging.PageSize);
        }
        public async Task<PagedList<EventModel>> GetUpdatedAsync(PagingModel paging, FilterModel filter)
        {
            return PagedList<EventModel>.ToPagedList(_mapper, _filter.GetSpecificData(_mapper.Map<IEnumerable<Event>>((await _eventData.GetUpdateEventsAsync()).AsEnumerable()), filter)
                .OrderByDescending(x => x.LastModified),
                        paging.PageNumber,
                        paging.PageSize);
        }
        public async Task<PagedList<EventModel>> GetMyAsync(PagingModel paging, FilterModel filter, string Id)
        {
            return PagedList<EventModel>.ToPagedList(_mapper, _filter.GetSpecificData(await _eventData.GetMyEventsAsync(Id), filter)
                .OrderBy(x => x.StartDate),
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
        public async Task<Guid> UndeleteAsync(EventAddModel data)
        {
            var IsDeleted = (await _eventData.GetDeletedAsync()).Single(x => x.Id == data.Id);

            await _eventData.UndeleteAndUnpublishEventAsync(IsDeleted.Id);

            return IsDeleted.Id;
        }
        public async Task<Guid> CreateAsync(EventAddModel data, string userId)
        {
            var model = new EventModel
            {
                Id = data.Id != Guid.Empty ? data.Id : Guid.NewGuid(),
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
                Organization = data.Organization,
                LastModified = DateTimeOffset.UtcNow
            };
            var eventToAdd = _mapper.Map<EventDatabaseModel>(model);
            await _eventData.CreateEventAsync(eventToAdd);
            return eventToAdd.Id;
        }
        public async Task UpdateAsync(EventUpdateModel modified, string id)
        {
            var eventToModify = _mapper.Map<EventDatabaseModel>(modified);
            eventToModify.OwnerID = id;
            await _eventData.UpdateEventAsync(eventToModify);
        }
        public async Task DeleteAsync(Guid id)
        {
            await _eventData.DeleteEventAsync(id);
        }
        public async Task<IEnumerable<string>> GetDistinctCitys()
        {
            return await _eventData.GetAllDistinctCitysAsync();
        }
        public async Task<PagedList<EventPreviewModel>> GetPublishedPreviewAsync(PagingModel paging, FilterModel filter)
        {
            return PagedList<EventPreviewModel>.ToPagedList(_mapper, _filter.GetSpecificData(await _eventData.GetPublishedEventsAsync(), filter).OrderBy(x => x.StartDate),
            paging.PageNumber,
            paging.PageSize);
        }
        public async Task ApproveUpdateEventAsync(Guid guid, DateTimeOffset date)
        {
            var data = (await _eventData.GetUpdateEventsAsync()).Where(x => x.EventId == guid && x.LastModified == date).Single();
            await _eventData.ApprovedUpdateEventAsync(_mapper.Map<EventDatabaseModel>(data));
        }
        public async Task DeleteUpdateEventAsync(Guid guid, DateTimeOffset date)
        {
            await _eventData.DeleteUpdateEventAsync(guid, date);
        }
        public async Task<EventModel?> IsDeletedAsync(Guid id)
        {
            var del = await _eventData.GetDeletedAsync();
            return _mapper.Map<EventModel?>((del)
                .FirstOrDefault(x => x.Id == id));
        }
        public async Task UpdateDeletedEventAsync(EventUpdateModel modified, string id)
        {
            var eventToModify = _mapper.Map<EventDatabaseModel>(modified);
            eventToModify.OwnerID = id;
            eventToModify.Published = false;
            await _eventData.UpdateDeletedEventAsync(eventToModify);
        }
    }
}
