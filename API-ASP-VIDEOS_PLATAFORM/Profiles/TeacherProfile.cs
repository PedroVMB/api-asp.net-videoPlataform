using API_ASP_VIDEOS_PLATAFORM.Data.DTO;
using API_ASP_VIDEOS_PLATAFORM.Model;
using AutoMapper;

namespace API_ASP_VIDEOS_PLATAFORM.Profiles;

public class TeacherProfile : Profile
{
    public TeacherProfile()
    {
        CreateMap<CreateTeacherDto, Teacher>();
        CreateMap<Teacher, ReadTeacherDto>();
        CreateMap<UpdateTeacherDto, Teacher>();
    }
}
