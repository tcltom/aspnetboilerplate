using System.ComponentModel.DataAnnotations;

namespace tcl.MetadataManageTool.Configuration.Dto
{
    public class ChangeUiThemeInput
    {
        [Required]
        [StringLength(32)]
        public string Theme { get; set; }
    }
}
