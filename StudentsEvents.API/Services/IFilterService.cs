using StudentsEvents.API.Models;
using StudentsEvents.Library.DBEntityModels;

namespace StudentsEvents.API.Services
{
    public interface IFilterService
    {
        IQueryable<Event> GetSpecificData(IQueryable<Event> events, FilterModel filter);
    }
}