﻿using API_ASP_VIDEOS_PLATAFORM.Data.DTO.Person;

namespace API_ASP_VIDEOS_PLATAFORM.Data.DTO.Student
{
    public class ReadStudentDto
    {
        internal bool IsSuccess;
        internal string ErrorMessage;

        public ReadPersonDto Person { get; set; }
        public bool IsActive { get; set; }
    }
}
