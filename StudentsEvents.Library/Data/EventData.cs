using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentsEvents.Library.DbAccess;
using StudentsEvents.Library.DBEntityModels;
using StudentsEvents.Library.Models;
using System.Xml.Linq;

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
        public async Task<IQueryable<Event>> GetMyEventsAsync(string Id)
        {
            return _context.Events.Where(x => x.IsDeleted == false && x.OwnerId == Id)
                .Include("Tags").OrderBy(x => x.StartDate);
        }
        public async Task PublishEventAsync(Guid id)
        {
            var data = await GetEventByIdAsync(id);
            data.Published = true;
            await _context.SaveChangesAsync();
        }
        public async Task UnpublishEventAsync(Guid id)
        {
            var data = await GetEventByIdAsync(id);
            data.Published = false;
            await _context.SaveChangesAsync();
        }
        public async Task<Event> GetEventByIdAsync(Guid id)
        {
            var data = _context.Events.Where(x => x.IsDeleted == false && x.Id == id).Include("Tags").Single();
            return data;
        }
        public async Task CreateEventAsync(EventDatabaseModel model)
        {
            await _data.SaveDataAsync("[dbo].[spEvent_Add]", new 
            {
                ID = model.Id,
                Name = model.Name,
                ShortDescription = model.ShortDescription,
                Thumbnail = model.Thumbnail,
                Background = model.Background,
                Facebook = model.Facebook,
                Website = model.Website,
                Language = model.Language,
                Upvotes = model.Upvotes,
                Registration = model.Registration,
                Tickets = model.Tickets,
                Online = model.Online,
                Location = model.Location,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                City = model.City,
                //Region = model.Region
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                //StudentGovernmentId = model.StudentGovernmentId,
                Published = model.Published,
                OwnerID = model.OwnerID,
                Organization = model.Organization,
                NewEventId = 0
            });
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
