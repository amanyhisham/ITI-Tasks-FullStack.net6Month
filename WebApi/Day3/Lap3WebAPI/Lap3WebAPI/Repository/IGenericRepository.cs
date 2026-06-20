namespace Lap3WebAPI.Repository
{
    //have interfaces of funcation  IGenericRepository (Interface)

    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(int id);
        Task Add(T entity);
        Task Delete(int id);
        Task Save();
    }
}