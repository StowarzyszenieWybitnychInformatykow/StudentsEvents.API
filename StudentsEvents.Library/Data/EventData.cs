using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentsEvents.Library.DbAccess;
using StudentsEvents.Library.DBEntityModels;
using StudentsEvents.Library.Models;

namespace StudentsEvents.Library.Data
{
    public class EventData : IEventData
    {
        private readonly ISqlDataAccess _data;
        private readonly ITagEventData _tagEventData;
        private readonly StudentsEventsDataDbContext _context;
        private readonly IMapper _mapper;

        public EventData(ISqlDataAccess data, ITagEventData tagEventData,
            StudentsEventsDataDbContext context, IMapper mapper)
        {
            _data = data;
            _tagEventData = tagEventData;
            _context = context;
            _mapper = mapper;
        }
        public async Task<IQueryable<Event>> GetEventsAsync()
        {
            return _context.Events.Where(x => x.IsDeleted == false)
                .Include("Tags");
        }
        public async Task<IQueryable<Event>> GetPublishedEventsAsync()
        {
            return _context.Events.Where(x => x.IsDeleted == false && x.Published)
                .Include("Tags");
        }
        public async Task<IQueryable<Event>> GetUnpublishedEventsAsync()
        {
            return _context.Events.Where(x => x.IsDeleted == false && !x.Published)
                .Include("Tags");
        }
        public async Task<IQueryable<Event>> GetUnfinishedEventsAsync()
        {
            return _context.Events.Where(x => x.IsDeleted == false &&
            x.EndDate > DateTimeOffset.UtcNow &&
            x.Published)
                .Include("Tags");
        }
        public async Task<IQueryable<Event>> GetMyEventsAsync(string Id)
        {
            return _context.Events.Where(x => x.IsDeleted == false && x.OwnerId == Id)
                .Include("Tags");
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
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Published = model.Published,
                OwnerID = model.OwnerID,
                Organization = model.Organization,
                LastModified = DateTimeOffset.Now,
                NewEventId = 0
            });
            await _tagEventData.AddTagsToEvent(model.Tags, model.Id);
        }
        public async Task ApprovedUpdateEventAsync(Guid id)
        {
            var model = _context.UpdateEvents.Where(x => x.Id == id).Single();
            var data = await GetEventByIdAsync(model.Id);
            data.Name = model.Name;
            data.ShortDescription = model.ShortDescription;
            data.Thumbnail = model.Thumbnail;
            data.Background = model.Background;
            data.Facebook = model.Facebook;
            data.Website = model.Website;
            data.Language = model.Language;
            data.Registration = model.Registration;
            data.Tickets = model.Tickets;
            data.Online = model.Online;
            data.Location = model.Location;
            data.Latitude = model.Latitude;
            data.Longitude = model.Longitude;
            data.City = model.City;
            data.StartDate = model.StartDate;
            data.EndDate = model.EndDate;
            data.Published = data.Published;
            data.Tags = _mapper.Map<List<Tag>>(model.Tags);
            data.LastModified = model.LastModified;

            var uModel = _context.UpdateEvents.Where(x => x.Id == data.Id).FirstOrDefault();
            _context.UpdateEvents.Remove(uModel);

            await _context.SaveChangesAsync();
        }
        public async Task UpdateEventAsync(EventDatabaseModel model)
        {
            var data = _mapper.Map<UpdateEvent>(model);
            data.LastModified = DateTimeOffset.Now;
            _context.UpdateEvents.Add(data);
            await _context.SaveChangesAsync();
        }
        public async Task<IQueryable<UpdateEvent>> GetUpdateEventsAsync()
        {
            return _context.UpdateEvents.Where(x => x.IsDeleted == false)
                .Include("Tags");
        }
        public async Task DeleteEventAsync(Guid id)
        {
            _context.Events.Where(x => x.IsDeleted == false && x.Id == id).Single().IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<string>> GetAllDistinctCitysAsync()
        {
            return _context.Events.Select(x => x.City).Distinct();
        }
    }
}
