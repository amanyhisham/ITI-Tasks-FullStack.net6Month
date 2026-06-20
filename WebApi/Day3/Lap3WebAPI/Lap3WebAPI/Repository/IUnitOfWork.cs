using Lap3WebAPI.Models;

namespace Lap3WebAPI.Repository
{
    public interface IUnitOfWork
    {
        IGenericRepository<Student> Students { get; }
        DepartmentRepository Departments { get; }
        Task Save();
    }
}