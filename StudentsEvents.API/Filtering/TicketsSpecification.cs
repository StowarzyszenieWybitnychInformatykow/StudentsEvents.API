using StudentsEvents.Library.DBEntityModels;

namespace StudentsEvents.API.Filtering
{
    public class TicketsSpecification : ISpecification<Event>
    {
        private readonly bool _tickets;

        public TicketsSpecification(bool tickets)
        {
            _tickets = tickets;
        }
        public bool IsSatisfied(Event entity)
        {
            return _tickets == entity.Tickets;
        }
    }
}
