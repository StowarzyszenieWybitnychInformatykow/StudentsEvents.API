using StudentsEvents.API.Models;
using StudentsEvents.Library.DBEntityModels;

namespace StudentsEvents.API.Services
{
    public interface IFilterService
    {
        IEnumerable<Event> GetSpecificData(IEnumerable<Event> events, FilterModel filter);
    }
}