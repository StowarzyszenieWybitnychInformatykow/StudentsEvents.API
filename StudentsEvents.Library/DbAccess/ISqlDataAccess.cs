namespace StudentsEvents.Library.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionId = "StudentsEventsDataDb");
        Task<IEnumerable<T>> LoadMultipleMapDataAsync<T, U, O>(string storedProcedure, U parameters, Func<T, O, T> func, string connectionId = "StudentsEventsDataDb");
        Task SaveDataAsync<T>(string storedProcedire, T parameters, string connectionId = "StudentsEventsDataDb");
    }
}