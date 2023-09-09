using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Addres;
using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Person;
using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Student;
using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Teacher;
using API_ASP_VIDEOS_PLATAFORM.Model;
using AutoMapper;

namespace API_ASP_VIDEOS_PLATAFORM.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<CreateStudentDto, Student>()
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.PersonData));


            CreateMap<Student, ReadStudentDto>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person));

         

            CreateMap<UpdateStudentDto, Student>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.isActive))
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person));

            CreateMap<Student, CreateStudentDto>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.PersonData, opt => opt.MapFrom(src => src.Person));

            CreateMap<Student, UpdateStudentDto>()
                .ForMember(dest => dest.isActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person));
        }
    }
}
