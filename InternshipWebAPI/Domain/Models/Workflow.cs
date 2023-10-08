using System.ComponentModel.DataAnnotations;

namespace InternshipWebAPI.Domain.Models
{
    public class Workflow : BaseModel
    {
        [Required]
        public string ProgramTemplateId { get; set; }
        public List<Stage>? Workflows { get; set; }
    }
}
