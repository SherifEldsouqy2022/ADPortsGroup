using System.ComponentModel.DataAnnotations;

namespace ADPortsGroup.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}