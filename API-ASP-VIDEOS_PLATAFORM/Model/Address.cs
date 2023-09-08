using System.ComponentModel.DataAnnotations;

namespace API_ASP_VIDEOS_PLATAFORM.Model;

public class Address
{
    [Key]
    [Required]
    public int Id { get; set; }

    public string Logradouro { get; set; }
    public string Bairro { get; set; }
    public string Cep { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Cidade { get; set; }
    public string Uf { get; set; }

    public int PersonId { get; set; }
    public virtual Person Person { get; set; }
}
