using InternshipWebAPI.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace InternshipWebAPI.Domain.DTOs
{
    public class WorkflowDTO
    {
        public string Id { get; set; }
        public string ProgramTemplateId { get; set; }
        public List<Stage>? Workflows { get; set; }
    }

    public class CreateWorkFlowDTO
    {
        [Required]
        public string ProgramTemplateId { get; set; }
        [Required]
        public List<Stage>? Workflows { get; set; }
    }
}