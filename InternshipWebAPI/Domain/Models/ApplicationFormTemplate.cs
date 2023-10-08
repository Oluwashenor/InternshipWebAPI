using System.ComponentModel.DataAnnotations;

namespace InternshipWebAPI.Domain.Models
{
    public class ApplicationFormTemplate : BaseModel
    {
        [Required]
        public string? ProgramTemplateId { get; set; }
        public List<QuestionBlock>? PersonalInfoQuestions { get; set; }
        public ProgramTemplate? ProgramTemplate { get; set; }
        public ProfileField? Education { get; set; }
        public ProfileField? Experience { get; set; }
        public ProfileField? Resume { get; set; }
    }
}
