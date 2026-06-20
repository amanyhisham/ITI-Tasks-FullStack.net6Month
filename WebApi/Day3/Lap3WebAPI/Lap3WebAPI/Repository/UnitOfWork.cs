using Lap3WebAPI.Models;

namespace Lap3WebAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ItiContext _context;

        public IGenericRepository<Student> Students { get; private set; }
        public DepartmentRepository Departments { get; private set; }

        public UnitOfWork(ItiContext context)
        {
            _context = context;
            Students = new GenericRepository<Student>(context);
            Departments = new DepartmentRepository(context);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}