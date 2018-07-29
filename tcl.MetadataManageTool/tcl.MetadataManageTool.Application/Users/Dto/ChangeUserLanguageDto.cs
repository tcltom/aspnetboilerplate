using System.ComponentModel.DataAnnotations;

namespace tcl.MetadataManageTool.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}