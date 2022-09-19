namespace StudentsEvents.API.Filtering
{
    public interface IFilter<T>
    {
        IEnumerable<T> Filtration(IEnumerable<T> entitys, ISpecification<T> spec);
    }
}
