using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Person;

namespace API_ASP_VIDEOS_PLATAFORM.utils
{
    public class ReadTeacherResults
    {
        public bool IsSuccess { get; set; }
        public ReadPersonDto teacher { get; set; }
        public string ErrorMessage { get; set; }
    }
}
