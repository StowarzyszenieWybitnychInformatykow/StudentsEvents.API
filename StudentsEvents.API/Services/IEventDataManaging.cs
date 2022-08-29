using StudentsEvents.API.Models;

namespace StudentsEvents.API.Services
{
    public interface IEventDataManaging
    {
        Task CreateAsync(EventModel data);
        Task DeleteAsync(Guid id);
        Task<PagedList<EventModel>> GetAllAsync(PagingModel paging);
        Task<EventModel> GetByIdAsync(Guid id);
        Task UpdateAsync(EventModel modified);
    }
}