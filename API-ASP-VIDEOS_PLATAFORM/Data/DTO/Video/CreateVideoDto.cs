using System.ComponentModel.DataAnnotations;

namespace API_ASP_VIDEOS_PLATAFORM.Data.DTO.Video;

public class CreateVideoDto
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string Url { get; set; }

    public bool IsActive { get; set; }
}
