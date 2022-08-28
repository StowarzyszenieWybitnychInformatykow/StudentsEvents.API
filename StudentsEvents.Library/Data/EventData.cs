using StudentsEvents.API.Models;
using StudentsEvents.Library.DbAccess;

namespace StudentsEvents.Library.Data
{
    public class EventData : IEventData
    {
        private readonly ISqlDataAccess _data;

        public EventData(ISqlDataAccess data)
        {
            _data = data;
        }
        public async Task<IEnumerable<EventDatabaseModel>> GetEventsAsync()
        {
            throw new NotImplementedException();
        }
        public async Task CreateEventAsync(EventDatabaseModel model)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateEventAsync(EventDatabaseModel model)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteEventAsync(EventDatabaseModel model)
        {
            throw new NotImplementedException();
        }
    }
}
