using StudentsEvents.API.Models;

namespace StudentsEvents.API.Services
{
    public interface IEventDataManaging
    {
        Task CreateAsync(EventModel data);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<EventModel>> GetAllAsync();
        Task<EventModel> GetByIdAsync(Guid id);
        Task UpdateAsync(Guid id, EventModel modified);
    }
}