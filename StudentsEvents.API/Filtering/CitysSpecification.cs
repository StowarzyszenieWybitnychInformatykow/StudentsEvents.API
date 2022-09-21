using StudentsEvents.Library.DBEntityModels;

namespace StudentsEvents.API.Filtering
{
    public class CitysSpecification : ISpecification<Event>
    {
        private readonly string[] _city;
        private readonly bool? _isOnline;

        public CitysSpecification(string[]? city, bool? isOnline)
        {
            _city = city;
            _isOnline = isOnline;
        }
        public bool IsSatisfied(Event entity)
        {
            if((_city != null && _city.Contains(entity?.City)) || 
                ((_isOnline != null) && (entity?.Online == _isOnline) && (bool)entity.Online))
                return true;
            return false;
        }
    }
}
