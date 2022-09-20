using StudentsEvents.API.Models;

namespace StudentsEvents.API.Services
{
    public interface IEventDataManaging
    {
        Task<Guid> CreateAsync(EventAddModel data, string userId);
        Task DeleteAsync(Guid id);
        Task<PagedList<EventModel>> GetAllAsync(PagingModel paging, FilterModel filter);
        Task<PagedList<EventModel>> GetPublishedAsync(PagingModel paging, FilterModel filter);
        Task<PagedList<EventModel>> GetUnpublishedAsync(PagingModel paging, FilterModel filter);
        Task<PagedList<EventModel>> GetUnfinishedAsync(PagingModel paging, FilterModel filter);
        Task PublishEventAsync(Guid id);
        Task UnpublishEventAsync(Guid id);
        Task<PagedList<EventModel>> GetMyAsync(PagingModel paging, FilterModel filter, string Id);
        Task<EventModel> GetByIdAsync(Guid id);
        Task UpdateAsync(EventUpdateModel modified);
        Task<IEnumerable<string>> GetDistinctCitys();
    }
}