using AutoMapper;
using Lap2WepApi.DTOs;
 using Lap2WepApI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lap2WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ItiContext _context;
        private readonly IMapper _mapper;

        public StudentController(ItiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10, string search = "")
        {
            var query = _context.Students
                .Include(s => s.Dept)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(s =>
                    (s.StFname != null && s.StFname.Contains(search)) ||
                    (s.StLname != null && s.StLname.Contains(search))
                ); var total = await query.CountAsync();

            var students = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var result = _mapper.Map<List<StudentDTO>>(students);
            return Ok(new { total, page, pageSize, data = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _context.Students
                .Include(s => s.Dept)
                .FirstOrDefaultAsync(s => s.StId == id);

            if (student == null) return NotFound();

            return Ok(_mapper.Map<StudentDTO>(student));
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> Add([FromBody] StudentAddDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var student = _mapper.Map<Student>(dto);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = student.StId }, dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}