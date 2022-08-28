using StudentsEvents.API.Models;
using StudentsEvents.Library.Data;

namespace StudentsEvents.Library.SampleData
{
    public class SampleEventData : IEventData
    {
        List<EventDatabaseModel> events = new();
        public SampleEventData()
        {
            events.Add(new EventDatabaseModel()
            {
                Id = new Guid(),
                Name = "Event1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now + TimeSpan.FromDays(1),
                LastModified = DateTime.Now,
                Latitude = 123,
                Longitude = 123,
                Owner = "UST AGH",
                Published = true,
                ShortDescription = "Event",
                StudentGovernmentId = new Guid(),
                Thumbnail = "Url",
                Tickets = null,
                Tags = new List<TagDatabaseModel>() { new TagDatabaseModel() { Id = 1, Name = "tag1" } }
            });
        }
        public async Task CreateEventAsync(EventDatabaseModel model)
        {
            events.Add(model);
        }

        public async Task DeleteEventAsync(EventDatabaseModel model)
        {
            events.Remove(model);
        }

        public async Task<EventDatabaseModel> GetEventByIdAsync(Guid id)
        {
            return events.Where(x => x.Id == id).First();
        }

        public async Task<IEnumerable<EventDatabaseModel>> GetEventsAsync()
        {
            return events.AsEnumerable();
        }

        public async Task UpdateEventAsync(EventDatabaseModel model)
        {
            var a = events.Single(x => x.Id == model.Id);
            a = model;
        }
    }
}
