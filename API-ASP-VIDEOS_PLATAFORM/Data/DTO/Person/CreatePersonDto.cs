using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Addres;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API_ASP_VIDEOS_PLATAFORM.Data.DTO.Person;

public class CreatePersonDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
    public string DateOfBirth { get; set; }

    public string? Biometry { get; set; }

    [Required(ErrorMessage = "O CPF é obrigatório.")]
    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido. O formato correto é XXX.XXX.XXX-XX")]
    public string Cpf { get; set; }

    public string Rg { get; set; }

    public string Telephone { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
    public string Email { get; set; }

    [Required]
    [PasswordPropertyText]
    public string Password { get; set; }

    public string Profission { get; set; }

    public CreateAddressDto? Address{ get; set; }

    public int AddresId { get; set; }
}
