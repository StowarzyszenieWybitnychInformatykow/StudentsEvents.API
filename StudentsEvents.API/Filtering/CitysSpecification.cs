using StudentsEvents.Library.DBEntityModels;

namespace StudentsEvents.API.Filtering
{
    public class CitysSpecification : ISpecification<Event>
    {
        private readonly string[] _city;

        public CitysSpecification(string[] city)
        {
            _city = city;
        }
        public bool IsSatisfied(Event entity)
        {
            return _city.Contains(entity?.City);
        }
    }
}
