using StudentsEvents.Library.DBEntityModels;

namespace StudentsEvents.API.Filtering
{
    public class IsOnlineSpecification : ISpecification<Event>
    {
        private readonly bool _isOnline;

        public IsOnlineSpecification(bool isOnline)
        {
            _isOnline = isOnline;
        }
        public bool IsSatisfied(Event entity)
        {
            return entity?.Online == _isOnline;
        }
    }
}
