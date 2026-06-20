using AutoMapper;
using Lap3WebAPI.DTOs;
using Lap3WebAPI.Models;
using Lap3WebAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Lap3WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all departments",
            Description = "Returns list of all departments with number of students in each department")]
        [SwaggerResponse(200, "Success", typeof(IEnumerable<DepartmentDTO>))]
        [SwaggerResponse(404, "No departments found")]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _unitOfWork.Departments.GetAllWithStudents();
            var result = _mapper.Map<IEnumerable<DepartmentDTO>>(departments);
            return Ok(result);
        }

        

        [HttpPost]
        [Consumes("application/json")]
        [SwaggerOperation(
            Summary = "Add new department",
            Description = "Adds a new department - accepts JSON only")]
        [SwaggerResponse(201, "Department created successfully")]
        [SwaggerResponse(400, "Invalid data")]
        public async Task<IActionResult> Add([FromBody] DepartmentDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var dept = new Department
            {
                DeptName = dto.DeptName,
                DeptDesc = dto.DeptDesc
            };
            await _unitOfWork.Departments.Add(dept);
            await _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById), new { id = dept.DeptId }, dto);
            

        }
 



        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get department by ID", Description = "Returns a single department with number of students")]
        [SwaggerResponse(200, "Success", typeof(DepartmentDTO))]
        [SwaggerResponse(404, "Department not found")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _unitOfWork.Departments.GetByIdWithStudents(id);
            if (department == null) return NotFound();
            return Ok(_mapper.Map<DepartmentDTO>(department));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete department", Description = "Deletes a department by ID")]
        [SwaggerResponse(204, "Department deleted successfully")]
        [SwaggerResponse(400, "Department has related students")]
        [SwaggerResponse(404, "Department not found")]
        public async Task<IActionResult> Delete(int id)
        {
            var dept = await _unitOfWork.Departments.GetByIdWithStudents(id);
            if (dept == null) return NotFound();

            if (dept.Students != null && dept.Students.Count > 0)
            {
                return BadRequest(new
                {
                    message = $"Cannot delete department '{dept.DeptName}' because it contains {dept.Students.Count} student(s). Please delete or transfer the students first."
                });
            }

            await _unitOfWork.Departments.Delete(id);
            await _unitOfWork.Save();
            return NoContent();
        }
    }
}