using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace API_ASP_VIDEOS_PLATAFORM.Model;

public class Adress
{
    
    public string logradouro { get; set; }
    public string bairro { get; set; }
    public string cep {  get; set; }
    public string numero { get; set; }
    public string complemento { get; set; }
    public string cidade { get; set; }
    public string uf { get; set; }


}
