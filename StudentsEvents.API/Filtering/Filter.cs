using StudentsEvents.API.Models;
using StudentsEvents.Library.DBEntityModels;

namespace StudentsEvents.API.Filtering
{
    public class Filter : IFilter<Event>
    {
        public IEnumerable<Event> Filtration(IEnumerable<Event> entitys, ISpecification<Event> spec)
        {
            return entitys.Where(x => spec.IsSatisfied(x));
        }
    }
}
