using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Teacher;
using API_ASP_VIDEOS_PLATAFORM.Data;
using API_ASP_VIDEOS_PLATAFORM.Model;
using AutoMapper;
using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Student;
using Microsoft.EntityFrameworkCore;

namespace API_ASP_VIDEOS_PLATAFORM.services
{
    public class StudentService
    {
        private readonly IMapper _mapper;
        private readonly VideoPlataformContext _context;

        public StudentService(IMapper mapper, VideoPlataformContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Student> RegisterStudent(CreateStudentDto dto)
        {
            var student = _mapper.Map<Student>(dto);
            var address = _mapper.Map<Address>(dto.AddressData);
            student.Person.Address = address;

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<List<ReadStudentDto>> GetActiveStudents(int skip, int take)
        {
            var activeStudents = await _context.Students
                .Include(t => t.Person)
                    .ThenInclude(p => p.Address)
                .Where(t => t.IsActive == true)
                .OrderBy(t => t.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return _mapper.Map<List<ReadStudentDto>>(activeStudents);
        }

        public async Task<ReadStudentDto> ReadStudentById(int id)
        {
            var student = await _context.Students
                .Include(t => t.Person)
                    .ThenInclude(p => p.Address)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (student == null) return null;

            return _mapper.Map<ReadStudentDto>(student);
        }

        public async Task<ReadStudentDto> UpdateStudent(int id, UpdateStudentDto studentDto)
        {
            var student = await _context.Students
                .Include(t => t.Person)
                    .ThenInclude(p => p.Address)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (student == null) throw new Exception($"Student with this id {id} is not found");

            // Mapeie os dados do DTO de atualização para a entidade Student
            _mapper.Map(studentDto, student);

            try
            {
                await _context.SaveChangesAsync();
                return _mapper.Map<ReadStudentDto>(student);
            }
            catch (Exception ex)
            {
                return new ReadStudentDto { IsSuccess = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<bool> DeleteStudent(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(t => t.Id == id);
            if (student == null) throw new Exception($"Student with this id {id} is not found");

            student.IsActive = false; // Define o estudante como inativo

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
