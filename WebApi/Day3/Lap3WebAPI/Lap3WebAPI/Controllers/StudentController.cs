using AutoMapper;
using Lap3WebAPI.DTOs;
using Lap3WebAPI.Models;
using Lap3WebAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lap3WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _unitOfWork.Students.GetAll();
            var result = _mapper.Map<IEnumerable<StudentDTO>>(students);
            return Ok(result);
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _unitOfWork.Students.GetById(id);
            if (student == null) return NotFound();
            return Ok(_mapper.Map<StudentDTO>(student));
        }

        // POST: api/Student
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> Add([FromBody] StudentAddDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var student = _mapper.Map<Student>(dto);
            await _unitOfWork.Students.Add(student);
            await _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById), new { id = student.StId }, dto);
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _unitOfWork.Students.GetById(id);
            if (student == null) return NotFound();
            await _unitOfWork.Students.Delete(id);
            await _unitOfWork.Save();
            return NoContent();
        }
    }
}