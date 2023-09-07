using System;

namespace API_ASP_VIDEOS_PLATAFORM.Data.DTO;

public class ReadTeacherDto
{
    public string Name { get; set; }
    public string DateOfBirth { get; set; }
    public string Cpf { get; set; }
    public string Rg { get; set; }
    public string Telephone { get; set; }
    public string Email { get; set; }
    public string Profission { get; set; }

    public string AdressLogradouro { get; set; }
    public string AdressBairro { get; set; }
    public string AdressCep { get; set; }
    public string AdressNumero { get; set; }
    public string AdressComplemento { get; set; }
    public string AdressCidade { get; set; }
    public string AdressUf { get; set; }

    public string Biometry { get; set; }

}
