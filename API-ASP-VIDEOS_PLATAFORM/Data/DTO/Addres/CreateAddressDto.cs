using System.ComponentModel.DataAnnotations;

namespace API_ASP_VIDEOS_PLATAFORM.Data.DTO.Addres
{
        public class CreateAddressDto
        {
            [Required(ErrorMessage = "O logradouro do endereço é obrigatório.")]
            public string Logradouro { get; set; }

            [Required(ErrorMessage = "O bairro do endereço é obrigatório.")]
            public string Bairro { get; set; }

            [Required(ErrorMessage = "O CEP do endereço é obrigatório.")]
            public string Cep { get; set; }

            public string Numero { get; set; }

            public string Complemento { get; set; }

            [Required(ErrorMessage = "A cidade do endereço é obrigatória.")]
            public string Cidade { get; set; }

            public string Uf { get; set; }
        }
}
