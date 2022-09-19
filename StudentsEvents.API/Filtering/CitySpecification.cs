using StudentsEvents.Library.DBEntityModels;

namespace StudentsEvents.API.Filtering
{
    public class CitySpecification : ISpecification<Event>
    {
        private readonly string _city;

        public CitySpecification(string city)
        {
            _city = city;
        }
        public bool IsSatisfied(Event entity)
        {
            if(entity?.City == _city)
            {
                return true;
            }
            return false;
        }
    }
}
