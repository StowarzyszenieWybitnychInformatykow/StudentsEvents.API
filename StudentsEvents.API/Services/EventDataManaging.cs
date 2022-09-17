﻿using AutoMapper;
using StudentsEvents.Library.Models;
using StudentsEvents.Library.Data;
using StudentsEvents.Library.DBEntityModels;
using StudentsEvents.Library.Models;
using System.Collections.Generic;

namespace StudentsEvents.Library.Services
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

            return PagedList<EventModel>.ToPagedList(_mapper ,await _eventData.GetEventsAsync(),
                        paging.PageNumber,
                        paging.PageSize);
        }
        public async Task<PagedList<EventModel>> GetPublishedAsync(PagingModel paging)
        {
            return PagedList<EventModel>.ToPagedList(_mapper, await _eventData.GetPublishedEventsAsync(),
                        paging.PageNumber,
                        paging.PageSize);
        }
        public async Task<PagedList<EventModel>> GetUnfinishedAsync(PagingModel paging)
        {
            return PagedList<EventModel>.ToPagedList(_mapper, await _eventData.GetUnfinishedEventsAsync(),
                        paging.PageNumber,
                        paging.PageSize);
        }
        public async Task<PagedList<EventModel>> GetUnpublishedAsync(PagingModel paging)
        {
            return PagedList<EventModel>.ToPagedList(_mapper, await _eventData.GetUnpublishedEventsAsync(),
                        paging.PageNumber,
                        paging.PageSize);
        }
        public async Task<PagedList<EventModel>> GetMyAsync(PagingModel paging, string Id)
        {
            return PagedList<EventModel>.ToPagedList(_mapper, await _eventData.GetMyEventsAsync(Id),
                        paging.PageNumber,
                        paging.PageSize);
        }

        public async Task<EventModel> GetByIdAsync(Guid id)
        {
            return _mapper.Map<EventModel>(await _eventData.GetEventByIdAsync(id));
        }
        public async Task PublishEventAsync(EventModel data)
        {
            var model = _mapper.Map<EventDatabaseModel>(data);
            await _eventData.PublishEventAsync(model);
        }
        public async Task UnpublishEventAsync(EventModel data)
        {
            var model = _mapper.Map<EventDatabaseModel>(data);
            await _eventData.UnpublishEventAsync(model);
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
    }
}
