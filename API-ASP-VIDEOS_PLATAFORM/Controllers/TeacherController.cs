using API_ASP_VIDEOS_PLATAFORM.Data;
using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Person;
using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Teacher;
using API_ASP_VIDEOS_PLATAFORM.Model;
using API_ASP_VIDEOS_PLATAFORM.Services;
using API_ASP_VIDEOS_PLATAFORM.utils;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API_ASP_VIDEOS_PLATAFORM.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherController : Controller
{
    private readonly VideoPlataformContext _context;
    private readonly IMapper _mapper;
    private readonly TeacherService _service;

    public TeacherController(VideoPlataformContext context, IMapper mapper, TeacherService service)
    {
        _context = context;
        _mapper = mapper;
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult> AddTeacher([FromBody] CreateTeacherDto teacherDto)
    {
        var teacherModel = await _service.RegisterTeacher(teacherDto);

        return Ok(_mapper.Map<ReadTeacherDto>(teacherModel));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadTeacherDto>>> GetTeachers([FromQuery] int skip = 0, [FromQuery] int take = 30)
    {
        var teachers = await _service.GetActiveTeachers(skip, take);

        return Ok(_mapper.Map<List<ReadTeacherDto>>(teachers));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReadTeacherDto>> GetTeacherById(int id)
    {
        var teacher = await _service.ReadTeacherById(id);
        if (teacher == null) return NotFound();

        return Ok(teacher);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ReadTeacherDto>> UpdateTeacher(int id, [FromBody] UpdateTeacherDto teacherDto)
    {
        var updatedTeacher = await _service.UpdateTeacher(id, teacherDto);

        if (!updatedTeacher.IsSuccess) return NotFound(updatedTeacher.ErrorMessage);

        return Ok(updatedTeacher);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteTeacher(int id)
    {
        var success = await _service.DeleteTeacher(id);

        if (!success) return NotFound();

        return Ok(success);
    }
}
