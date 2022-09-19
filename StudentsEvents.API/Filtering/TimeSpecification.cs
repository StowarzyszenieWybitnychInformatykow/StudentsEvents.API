using StudentsEvents.Library.DBEntityModels;

namespace StudentsEvents.API.Filtering
{
    public class TimeSpecification : ISpecification<Event>
    {
        private readonly DateTimeOffset? _start;
        private readonly DateTimeOffset? _end;

        public TimeSpecification(DateTimeOffset? start, DateTimeOffset? end)
        {
            _start = start;
            _end = end;
        }
        public bool IsSatisfied(Event entity)
        {
            if(entity.StartDate < _start || entity.EndDate > _end)
            {
                return false;
            }
            return true;
        }
    }
}
