using System.ComponentModel.DataAnnotations;

namespace API_ASP_VIDEOS_PLATAFORM.Data.DTO;

public class UpdateTeacherDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
    public string DateOfBirth { get; set; }

    [Required(ErrorMessage = "O CPF é obrigatório.")]
    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido. O formato correto é XXX.XXX.XXX-XX")]
    public string Cpf { get; set; }

    public string Rg { get; set; }

    public string Telephone { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
    public string Email { get; set; }

    public string Profission { get; set; }

    [Required(ErrorMessage = "O logradouro é obrigatório.")]
    public string AdressLogradouro { get; set; }

    [Required(ErrorMessage = "O bairro é obrigatório.")]
    public string AdressBairro { get; set; }

    [Required(ErrorMessage = "O CEP é obrigatório.")]
    public string AdressCep { get; set; }

    [Required(ErrorMessage = "O número é obrigatório.")]
    public string AdressNumero { get; set; }

    [Required(ErrorMessage = "O complemento é obrigatório.")]
    public string AdressComplemento { get; set; }

    [Required(ErrorMessage = "A cidade é obrigatória.")]
    public string AdressCidade { get; set; }

    [Required(ErrorMessage = "A UF é obrigatória.")]
    public string AdressUf { get; set; }

    // Você pode adicionar a propriedade Biometry aqui se também for obrigatória para atualização de professores.
}
