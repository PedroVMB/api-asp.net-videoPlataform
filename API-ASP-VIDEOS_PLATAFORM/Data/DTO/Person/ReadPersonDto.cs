using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Addres;
using System;

namespace API_ASP_VIDEOS_PLATAFORM.Data.DTO.Person;

public class ReadPersonDto
{
    internal string ErrorMessage;

    public int Id { get; set; }
    public string Name { get; set; }
    public string DateOfBirth { get; set; }
    public string Cpf { get; set; }
    public string Rg { get; set; }
    public string Telephone { get; set; }
    public string Email { get; set; }
    public string Profission { get; set; }

    public ReadAddressDto Address{ get; set; }
    
    public bool IsSuccess { get; internal set; }
}
