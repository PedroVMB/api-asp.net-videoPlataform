using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Addres;
using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Person;
using System.ComponentModel.DataAnnotations;

namespace API_ASP_VIDEOS_PLATAFORM.Data.DTO.Teacher
{
    public class CreateTeacherDto
    {
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Os dados da pessoa são obrigatórios.")]
        public CreatePersonDto PersonData { get; set; }

        [Required(ErrorMessage = "Os dados do endereço são obrigatórios.")]
        public CreateAddressDto? AddressData { get; set; }
    }

}
