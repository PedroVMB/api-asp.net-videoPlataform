using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Video;
using API_ASP_VIDEOS_PLATAFORM.Data;
using API_ASP_VIDEOS_PLATAFORM.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_ASP_VIDEOS_PLATAFORM.services;

public class VideoService
{
    private readonly IMapper _mapper;
    private readonly VideoPlataformContext _context;

    public VideoService(IMapper mapper, VideoPlataformContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Video> RegisterVideo(CreateVideoDto dto)
    {
        var Video = _mapper.Map<Video>(dto);
        

        _context.Videos.Add(Video);
        await _context.SaveChangesAsync();

        return Video;
    }

    public async Task<List<ReadVideoDto>> GetActiveVideos(int skip, int take)
    {
        var activeVideos = await _context.Videos
            .Where(t => t.IsActive == true)
            .OrderBy(t => t.Id)
            .Skip(skip)
            .Take(take)
            .ToListAsync();

        return _mapper.Map<List<ReadVideoDto>>(activeVideos);
    }

    public async Task<ReadVideoDto> ReadVideoById(int id)
    {
        var Video = await _context.Videos
            .FirstOrDefaultAsync(x => x.Id == id);

        if (Video == null) return null;

        return _mapper.Map<ReadVideoDto>(Video);
    }

    public async Task<ReadVideoDto> UpdateVideo(int id, UpdateVideoDto VideoDto)
    {
        var Video = await _context.Videos
            .FirstOrDefaultAsync(x => x.Id == id);

        if (Video == null) throw new Exception($"Video with this id {id} is not found");

        // Mapeie os dados do DTO de atualização para a entidade Video
        _mapper.Map(VideoDto, Video);

        try
        {
            await _context.SaveChangesAsync();
            return _mapper.Map<ReadVideoDto>(Video);
        }
        catch (Exception ex)
        {
            return new ReadVideoDto { IsSuccess = false, ErrorMessage = ex.Message };
        }
    }

    public async Task<bool> DeleteVideo(int id)
    {
        var Video = await _context.Videos.FirstOrDefaultAsync(t => t.Id == id);
        if (Video == null) throw new Exception($"Video with this id {id} is not found");

        Video.IsActive = false; // Define o estudante como inativo

        await _context.SaveChangesAsync();

        return true;
    }
}
