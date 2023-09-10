using System.ComponentModel.DataAnnotations;

namespace API_ASP_VIDEOS_PLATAFORM.Data.DTO.Video;

public class ReadVideoDto
{

    public int Id { get; set; }
    
    [Required]
    public string Title { get; set; }

    [Required]
    public string Url { get; set; }

    public bool IsActive { get; set; }

    internal bool IsSuccess;
    internal string ErrorMessage;   
}
