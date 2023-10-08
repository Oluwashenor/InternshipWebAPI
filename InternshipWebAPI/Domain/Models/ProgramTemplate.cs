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
        public DateTime? ProgramStart { get; set; }
        public DateTime? ApplicationOpen { get; set; }
        public DateTime? ApplicationClose { get; set; }
        public string? Duration { get; set; }
        public string? Location { get; set; }
        public string? MinimumQualification { get; set; }
        public bool Remote { get; set; }
        public long MaxApplicant { get; set; }
        public ApplicationFormTemplate? ApplicationTemplate { get; set; }
        public Workflow? Workflow { get; set; }
    }
}
