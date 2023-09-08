using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace API_ASP_VIDEOS_PLATAFORM.Model;

public class Person
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    public string? Biometry { get; set; }


    public string DateOfBirth { get; set; }

    [Required(ErrorMessage = "O CPF é obrigatório.")]
    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido. O formato correto é XXX.XXX.XXX-XX")]
    public string Cpf { get; set; }

    public string Rg { get; set; }

    public string Telephone { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
    public string Email { get; set; }

    public int AddressId { get; set; }

    public virtual Teacher Teacher { get; set; }
    public virtual Address Address { get; set; }
}
