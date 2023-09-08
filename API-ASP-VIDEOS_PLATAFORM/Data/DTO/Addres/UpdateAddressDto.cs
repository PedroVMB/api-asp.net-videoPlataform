using System.ComponentModel.DataAnnotations;

namespace API_ASP_VIDEOS_PLATAFORM.Data.DTO.Addres
{
    public class UpdateAddressDto
    {
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        public string Cep { get; set; }


        public string Numero { get; set; }

        [Required(ErrorMessage = "O complemento é obrigatório.")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "A UF é obrigatória.")]
        public string Uf { get; set; }
    }
}
