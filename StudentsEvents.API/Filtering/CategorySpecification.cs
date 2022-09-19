using StudentsEvents.API.Models;
using StudentsEvents.Library.DBEntityModels;

namespace StudentsEvents.API.Filtering
{
    public class CategorySpecification : ISpecification<Event>
    {
        private readonly IEnumerable<Tag> _tags;

        public CategorySpecification(IEnumerable<Tag> tags)
        {
            _tags = tags;
        }
        public bool IsSatisfied(Event entity)
        {
            foreach (var item in _tags)
            {
                if (entity.Tags.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
