using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Person;

namespace API_ASP_VIDEOS_PLATAFORM.Data.DTO.Teacher
{
    public class UpdateTeacherDto
    {
        public bool isActive { get; set; }
        public UpdatePersonDto Person { get; set; }
    }
}
