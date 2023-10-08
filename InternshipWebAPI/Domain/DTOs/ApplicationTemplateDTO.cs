using InternshipWebAPI.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace InternshipWebAPI.Domain.DTOs
{
    public class ApplicationTemplateDTO
    {
        public string? Id { get; set; }
        public string? ProgramTitle { get; set; }
        public string? ProgramTemplateId { get; set; }
        public List<QuestionBlock>? Questions { get; set; }
        public ProgramTemplate? ProgramTemplate { get; set; }
        public ProfileField? Education { get; set; }
        public ProfileField? Experience { get; set; }
        public ProfileField? Resume { get; set; }

    }

    public class CreateApplicationTemplateDTO
    {
        [Required]
        public string? ProgramTemplateId { get; set; }
        public List<CreateQuestionBlockDTO>? Questions { get; set; }
        public ProfileField? Education { get; set; }
        public ProfileField? Experience { get; set; }
        public ProfileField? Resume { get; set; }
    }
}