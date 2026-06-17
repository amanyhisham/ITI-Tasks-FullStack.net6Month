using AutoMapper;
using Lap2WepApi.DTOs;
using Lap2WepApI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lap2WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ItiContext _context;
        private readonly IMapper _mapper;

        public DepartmentController(ItiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Department
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _context.Departments
                .Include(d => d.Students)
                .ToListAsync();

            var result = _mapper.Map<List<DepartmentDTO>>(departments);
            return Ok(result);
        }

        // GET: api/Department/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _context.Departments
                .Include(d => d.Students)
                .FirstOrDefaultAsync(d => d.DeptId == id);

            if (department == null) return NotFound();

            return Ok(_mapper.Map<DepartmentDTO>(department));
        }

        // POST: api/Department
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> Add([FromBody] DepartmentDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var dept = new Department
            {
                DeptName = dto.DeptName,
                DeptDesc = dto.DeptDesc
            };

            _context.Departments.Add(dept);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = dept.DeptId }, dto);
        }

        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dept = await _context.Departments.FindAsync(id);
            if (dept == null) return NotFound();

            _context.Departments.Remove(dept);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}