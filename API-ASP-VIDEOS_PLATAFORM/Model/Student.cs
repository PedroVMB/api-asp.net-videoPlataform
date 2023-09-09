using System.ComponentModel.DataAnnotations;

namespace API_ASP_VIDEOS_PLATAFORM.Model;

public class Student
{
    [Key]
    [Required]
    public int Id { get; set; }

    public bool IsActive { get; set; }

    public int PersonId { get; set; }
    public virtual Person Person { get; set; }
}
