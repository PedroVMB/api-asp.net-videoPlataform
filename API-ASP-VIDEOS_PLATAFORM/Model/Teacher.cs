using System.ComponentModel.DataAnnotations;

namespace API_ASP_VIDEOS_PLATAFORM.Model;

public class Teacher
{
    [Key]
    [Required]
    public int Id { get; set; }

    public virtual Person person { get; set; }
    

}
