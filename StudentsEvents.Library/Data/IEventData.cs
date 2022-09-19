using StudentsEvents.Library.Models;
using StudentsEvents.Library.DBEntityModels;

namespace StudentsEvents.Library.Data
{
    public interface IEventData
    {
        Task<IQueryable<Event>> GetEventsAsync();
        Task<IQueryable<Event>> GetPublishedEventsAsync();
        Task<IQueryable<Event>> GetUnpublishedEventsAsync();
        Task<IQueryable<Event>> GetUnfinishedEventsAsync();
        Task<IQueryable<Event>> GetMyEventsAsync(string Id);
        Task PublishEventAsync(Guid id);
        Task UnpublishEventAsync(Guid id);
        Task<Event> GetEventByIdAsync(Guid id);
        Task CreateEventAsync(EventDatabaseModel model);
        Task DeleteEventAsync(Guid id);
        Task UpdateEventAsync(EventDatabaseModel model);
        Task<IQueryable<string>> GetAllDistinctCitysAsync();
    }
}