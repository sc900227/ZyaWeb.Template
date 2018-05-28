using System.ComponentModel.DataAnnotations;

namespace ZyaWeb.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}