using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace API_ASP_VIDEOS_PLATAFORM.Model;

public class Person
{

    [Required]
    public string name { get; set; }
    public string biometry { get; set; }

    [Required] 
    public Adress adress { get; set; }

    [Required]
    public string dateOfBirth { get; set; }

    [Required(ErrorMessage = "O CPF é obrigatório.")]
    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido. O formato correto é XXX.XXX.XXX-XX")]
    public string cpf { get; set; }

    public string rg { get; set; }

    public string telephone { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
    public string email { get; set; }

    public string profission { get; set; }
}
