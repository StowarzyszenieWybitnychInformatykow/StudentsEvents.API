using StudentsEvents.API.Models;

namespace StudentsEvents.Library.Data
{
    public interface IEventData
    {
        Task CreateEventAsync(EventDatabaseModel model);
        Task DeleteEventAsync(EventDatabaseModel model);
        Task<IEnumerable<EventDatabaseModel>> GetEventsAsync();
        Task UpdateEventAsync(EventDatabaseModel model);
    }
}