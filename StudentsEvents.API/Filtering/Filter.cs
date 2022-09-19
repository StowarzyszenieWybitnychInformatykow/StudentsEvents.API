using StudentsEvents.API.Models;
using StudentsEvents.Library.DBEntityModels;

namespace StudentsEvents.API.Filtering
{
    public class Filter : IFilter<Event>
    {
        public IQueryable<Event> Filtration(IQueryable<Event> entitys, ISpecification<Event> spec)
        {
            return entitys.Where(x => spec.IsSatisfied(x));
        }
    }
}
