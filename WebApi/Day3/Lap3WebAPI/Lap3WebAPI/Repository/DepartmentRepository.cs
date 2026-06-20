using Lap3WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Lap3WebAPI.Repository
{
    public class DepartmentRepository : GenericRepository<Department>
    {
        private readonly ItiContext _context;

        public DepartmentRepository(ItiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllWithStudents()
        {
            return await _context.Departments
                .Include(d => d.Students)
                .ToListAsync();
        }
    }
}