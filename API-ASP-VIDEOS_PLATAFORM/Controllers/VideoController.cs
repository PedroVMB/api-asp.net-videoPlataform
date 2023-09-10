using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Video;
using API_ASP_VIDEOS_PLATAFORM.Data;
using API_ASP_VIDEOS_PLATAFORM.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API_ASP_VIDEOS_PLATAFORM.services;

namespace API_ASP_VIDEOS_PLATAFORM.Controllers;

[ApiController]
[Route("[controller]")]
public class VideoController : Controller
{
    private readonly VideoPlataformContext _context;
    private readonly IMapper _mapper;
    private readonly VideoService _service;

    public VideoController(VideoPlataformContext context, IMapper mapper, VideoService service)
    {
        _context = context;
        _mapper = mapper;
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult> AddVideo([FromBody] CreateVideoDto VideoDto)
    {
        var VideoModel = await _service.RegisterVideo(VideoDto);

        return Ok(_mapper.Map<ReadVideoDto>(VideoModel));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadVideoDto>>> GetVideos([FromQuery] int skip = 0, [FromQuery] int take = 30)
    {
        var Videos = await _service.GetActiveVideos(skip, take);

        return Ok(_mapper.Map<List<ReadVideoDto>>(Videos));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReadVideoDto>> GetVideoById(int id)
    {
        var Video = await _service.ReadVideoById(id);
        if (Video == null) return NotFound();

        return Ok(Video);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ReadVideoDto>> UpdateVideo(int id, [FromBody] UpdateVideoDto VideoDto)
    {
        var updatedVideo = await _service.UpdateVideo(id, VideoDto);

        if (!updatedVideo.IsSuccess) return NotFound(updatedVideo.ErrorMessage);

        return Ok(updatedVideo);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteVideo(int id)
    {
        var success = await _service.DeleteVideo(id);

        if (!success) return NotFound();

        return Ok(success);
    }
}
