using System.ComponentModel.DataAnnotations;

namespace InternshipWebAPI.Domain.Models
{
    public class ProgramTemplate : BaseModel
    {
        [Required]
        public string? Title { get; set; }
        [StringLength(250)]
        public string? Summary { get; set; }
        public string? Description { get; set; }
        public List<string>? Benefit { get; set; }
        public string? Criteria { get; set; }
        public List<string>? Skills { get; set; }
        public string? ProgramType { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? Open { get; set; }
        public DateTime? Close { get; set; }
        public string? Duration { get; set; }
        public string? Location { get; set; }
        public string? MinQualification { get; set; }
        public bool Remote { get; set; }
        public int MaxApplicant { get; set; }
        public string? ApplicationTemplateId { get; set; }
        public ApplicationFormTemplate? ApplicationTemplate { get; set; }
        public Workflow? Workflow { get; set; }
    }
}
