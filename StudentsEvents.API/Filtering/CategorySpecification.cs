using StudentsEvents.Library.DBEntityModels;

namespace StudentsEvents.API.Filtering
{
    public class CategorySpecification : ISpecification<Event>
    {
        private readonly IEnumerable<int> _tags;

        public CategorySpecification(IEnumerable<int> tags)
        {
            _tags = tags;
        }
        public bool IsSatisfied(Event entity)
        {
            foreach (var item in _tags)
            {
                if (entity.Tags.Select(x => x.Id).Contains(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
