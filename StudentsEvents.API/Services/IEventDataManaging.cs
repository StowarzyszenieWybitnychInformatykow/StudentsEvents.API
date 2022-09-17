using StudentsEvents.Library.Models;

namespace StudentsEvents.Library.Services
{
    public interface IEventDataManaging
    {
        Task CreateAsync(EventAddModel data, string userId);
        Task DeleteAsync(Guid id);
        Task<PagedList<EventModel>> GetAllAsync(PagingModel paging);
        Task<PagedList<EventModel>> GetPublishedAsync(PagingModel paging);
        Task<PagedList<EventModel>> GetUnpublishedAsync(PagingModel paging);
        Task<PagedList<EventModel>> GetUnfinishedAsync(PagingModel paging);
        Task PublishEventAsync(EventModel data);
        Task UnpublishEventAsync(EventModel data);
        Task<PagedList<EventModel>> GetMyAsync(PagingModel paging, string Id);
        Task<EventModel> GetByIdAsync(Guid id);
        Task UpdateAsync(EventModel modified);
    }
}