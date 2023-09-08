using API_ASP_VIDEOS_PLATAFORM.Data;
using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Person;
using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Teacher;
using API_ASP_VIDEOS_PLATAFORM.Model;

using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace API_ASP_VIDEOS_PLATAFORM.Services;

public class TeacherService
{
    private readonly IMapper _mapper;
    private readonly VideoPlataformContext _context;

    public TeacherService(IMapper mapper, VideoPlataformContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Teacher> RegisterTeacher(CreateTeacherDto dto)
    {
        var teacher = _mapper.Map<Teacher>(dto);
        var address = _mapper.Map<Address>(dto.AddressData);
        teacher.Person.Address = address;

        _context.Teachers.Add(teacher);
        await _context.SaveChangesAsync();

        return teacher;
    }

    public async Task<List<ReadTeacherDto>> GetActiveTeachers(int skip, int take)
    {
        var activeTeachers = await _context.Teachers
            .Include(t => t.Person)
                .ThenInclude(p => p.Address)
            .Where(t => t.IsActive == true)
            .OrderBy(t => t.Id)
            .Skip(skip)
            .Take(take)
            .ToListAsync();

        return _mapper.Map<List<ReadTeacherDto>>(activeTeachers);
    }


    public async Task<ReadTeacherDto> ReadTeacherById(int id)
    {
        var teacher = await _context.Teachers
            .Include(t => t.Person)
                .ThenInclude(p => p.Address)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (teacher == null) return null;

        return _mapper.Map<ReadTeacherDto>(teacher);
    }

    public async Task<ReadTeacherDto> UpdateTeacher(int id, UpdateTeacherDto teacherDto)
    {
        var teacher = await _context.Teachers
            .Include(t => t.Person)
                .ThenInclude(p => p.Address)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (teacher == null) throw new Exception($"Teacher with this id {id} is not found");

        // Mapeie os dados do DTO de atualização para a entidade Teacher
        _mapper.Map(teacherDto, teacher);

        try
        {
            await _context.SaveChangesAsync();
            return _mapper.Map<ReadTeacherDto>(teacher);
        }
        catch (Exception ex)
        {
            return new ReadTeacherDto { IsSuccess = false, ErrorMessage = ex.Message };
        }
    }

    public async Task<bool> DeleteTeacher(int id)
    {
        var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.Id == id);
        if (teacher == null) throw new Exception($"Teacher with this id {id} is not found");

        teacher.IsActive = false; // Define o professor como inativo

        await _context.SaveChangesAsync();

        return true;
    }
}

