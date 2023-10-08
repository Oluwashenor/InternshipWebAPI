using System.ComponentModel.DataAnnotations;

namespace InternshipWebAPI.Domain.DTOs
{
    public class ProgramDTO
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Created { get; set; }
        public WorkflowDTO? Workflow { get; set; }
        public ApplicationTemplateDTO? ApplicationTemplate { get; set; }
    }
    public class ProgramDetailDTO
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
    }


    public class CreateProgramDTO
    {
        [Required]
        public string? Title { get; set; }
        public string? Summary { get; set; }
        [Required]
        public string? Description { get; set; }
        public List<string>? Benefit { get; set; }
        public string? Criteria { get; set; }
        public List<string>? Skills { get; set; }
        public string? ProgramType { get; set; }
        [Required]
        public DateTime? ProgramStart { get; set; }
        [Required]
        public DateTime? ApplicationOpen { get; set; }
        [Required]
        public DateTime? ApplicationClose { get; set; }
        public string? Duration { get; set; }
        [Required]
        public string? Location { get; set; }
        public string? MinQualification { get; set; }
        public bool Remote { get; set; }
        public int MaxApplicant { get; set; }
        public CreateApplicationTemplateDTO? ApplicationTemplate { get; set; }
    }


}