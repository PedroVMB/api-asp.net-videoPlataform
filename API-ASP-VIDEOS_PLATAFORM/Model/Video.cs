using System.ComponentModel.DataAnnotations;

namespace API_ASP_VIDEOS_PLATAFORM.Model;

public class Video
{
    [Key]
    [Required]
    public int Id { get; set; }

    public bool IsActive { get; set; }

    [Required]
    public string Title {  get; set; }

    [Required]
    public string Url { get; set; }
}
