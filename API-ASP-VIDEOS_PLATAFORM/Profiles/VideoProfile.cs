using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Video;
using API_ASP_VIDEOS_PLATAFORM.Model;
using AutoMapper;

namespace API_ASP_VIDEOS_PLATAFORM.Profiles;

public class VideoProfile : Profile
{
    public VideoProfile()
    {
        CreateMap<CreateVideoDto, Video>();
        CreateMap<Video, ReadVideoDto>();
        CreateMap<UpdateVideoDto, Video>();
    }
}
