
using API_ASP_VIDEOS_PLATAFORM.Data;
using API_ASP_VIDEOS_PLATAFORM.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API_ASP_VIDEOS_PLATAFORM.services;
using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Student;

namespace API_ASP_VIDEOS_PLATAFORM.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : Controller
{
    private readonly VideoPlataformContext _context;
    private readonly IMapper _mapper;
    private readonly StudentService _service;

    public StudentController(VideoPlataformContext context, IMapper mapper, StudentService service)
    {
        _context = context;
        _mapper = mapper;
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult> AddStudent([FromBody] CreateStudentDto studentDto)
    {
        var studentModel = await _service.RegisterStudent(studentDto);

        return Ok(_mapper.Map<ReadStudentDto>(studentModel));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadStudentDto>>> GetStudents([FromQuery] int skip = 0, [FromQuery] int take = 30)
    {
        var students = await _service.GetActiveStudents(skip, take);

        return Ok(_mapper.Map<List<ReadStudentDto>>(students));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReadStudentDto>> GetStudentById(int id)
    {
        var student = await _service.ReadStudentById(id);
        if (student == null) return NotFound();

        return Ok(student);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ReadStudentDto>> UpdateStudent(int id, [FromBody] UpdateStudentDto studentDto)
    {
        var updatedStudent= await _service.UpdateStudent(id, studentDto);

        if (!updatedStudent.IsSuccess) return NotFound(updatedStudent.ErrorMessage);

        return Ok(updatedStudent);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteStudent(int id)
    {
        var success = await _service.DeleteStudent(id);

        if (!success) return NotFound();

        return Ok(success);
    }
}
