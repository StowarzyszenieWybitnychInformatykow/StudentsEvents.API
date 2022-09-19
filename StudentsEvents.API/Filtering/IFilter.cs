namespace StudentsEvents.API.Filtering
{
    public interface IFilter<T>
    {
        IQueryable<T> Filtration(IQueryable<T> entitys, ISpecification<T> spec);
    }
}
