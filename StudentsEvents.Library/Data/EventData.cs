using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentsEvents.API.Models;
using StudentsEvents.Library.DbAccess;
using StudentsEvents.Library.DBEntityModels;

namespace StudentsEvents.Library.Data
{
    public class EventData : IEventData
    {
        private readonly ISqlDataAccess _data;
        private readonly ITagEventData _tagEventData;
        private readonly StudentsEventsDataDbContext _context;

        public EventData(ISqlDataAccess data, ITagEventData tagEventData,
            StudentsEventsDataDbContext context)
        {
            _data = data;
            _tagEventData = tagEventData;
            _context = context;
        }
        public async Task<IQueryable<Event>> GetEventsAsync()
        {
            return _context.Events.Where(x => x.IsDeleted == false)
                .Include("Tags").OrderBy(x => x.StartDate);
        }
        public async Task<IQueryable<Event>> GetPublishedEventsAsync()
        {
            return _context.Events.Where(x => x.IsDeleted == false && x.Published)
                .Include("Tags").OrderBy(x => x.StartDate);
        }
        public async Task<IQueryable<Event>> GetUnpublishedEventsAsync()
        {
            return _context.Events.Where(x => x.IsDeleted == false && !x.Published)
                .Include("Tags").OrderBy(x => x.StartDate);
        }
        public async Task<IQueryable<Event>> GetUnfinishedEventsAsync()
        {
            return _context.Events.Where(x => x.IsDeleted == false && x.EndDate > DateTimeOffset.UtcNow)
                .Include("Tags").OrderBy(x => x.StartDate);
        }
        public async Task<Event> GetEventByIdAsync(Guid id)
        {
            var data = _context.Events.Where(x => x.IsDeleted == false && x.Id == id).Include("Tags").Single();
            return data;
        }
        public async Task CreateEventAsync(EventDatabaseModel model)
        {
            await _data.SaveDataAsync("[dbo].[spEvent_Add]", model);
            await _tagEventData.AddTagsToEvent(model.Tags, model.Id);
        }
        public async Task UpdateEventAsync(EventDatabaseModel model)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteEventAsync(Guid id)
        {
            _context.Events.Where(x => x.IsDeleted == false && x.Id == id).Single().IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }
}
