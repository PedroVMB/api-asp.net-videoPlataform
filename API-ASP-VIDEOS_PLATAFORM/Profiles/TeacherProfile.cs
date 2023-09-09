using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Addres;
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

        CreateMap<CreatePersonDto, Person>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address)); 

        CreateMap<CreateAddressDto, Address>()
        .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(src => src.Logradouro))
        .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Cidade))
        .ForMember(dest => dest.Uf, opt => opt.MapFrom(src => src.Uf))
        .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep))
        .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Bairro))
        .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Numero))
        .ForMember(dest => dest.Complemento, opt => opt.MapFrom(src => src.Complemento));


        CreateMap<Teacher, ReadTeacherDto>()
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person));

        CreateMap<Person, ReadPersonDto>();
        CreateMap<Address, ReadAddressDto>();








        CreateMap<UpdateTeacherDto, Teacher>()
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.isActive))
            .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person));

        CreateMap<Teacher, CreateTeacherDto>()
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            .ForMember(dest => dest.PersonData, opt => opt.MapFrom(src => src.Person));

        CreateMap<Teacher, UpdateTeacherDto>()
            .ForMember(dest => dest.isActive, opt => opt.MapFrom(src => src.IsActive))
            .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person));
    }
}


