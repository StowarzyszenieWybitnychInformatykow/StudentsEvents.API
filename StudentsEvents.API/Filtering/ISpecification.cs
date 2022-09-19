namespace StudentsEvents.API.Filtering
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T entity);
    }
}