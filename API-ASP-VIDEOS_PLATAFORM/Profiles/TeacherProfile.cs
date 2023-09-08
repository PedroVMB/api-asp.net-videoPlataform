using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Person;
using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Teacher;
using API_ASP_VIDEOS_PLATAFORM.Model;
using AutoMapper;

namespace API_ASP_VIDEOS_PLATAFORM.Profiles;

public class TeacherProfile : Profile
{
    public TeacherProfile()
    {
        CreateMap<CreateTeacherDto, Teacher>()
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.PersonData));

        CreateMap<Teacher, ReadTeacherDto>()
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person));

        CreateMap<UpdateTeacherDto, Teacher>()
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.isActive))
            .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person));

        // Mapeamento reverso de Teacher para CreateTeacherDto (caso seja necessário)
        CreateMap<Teacher, CreateTeacherDto>()
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            .ForMember(dest => dest.PersonData, opt => opt.MapFrom(src => src.Person));

        // Mapeamento reverso de Teacher para UpdateTeacherDto (caso seja necessário)
        CreateMap<Teacher, UpdateTeacherDto>()
            .ForMember(dest => dest.isActive, opt => opt.MapFrom(src => src.IsActive))
            .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person));
    }
}


