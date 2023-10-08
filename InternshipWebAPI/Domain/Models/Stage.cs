using InternshipWebAPI.Utilities;
using System.ComponentModel.DataAnnotations;

namespace InternshipWebAPI.Domain.Models
{
    public class Stage
    {
        public string? Name { get; set; }
        public StageType StageType { get; set; }
        public List<QuestionBlock>? Questions { get; set; }
        public bool Hidden { get; set; }
    }
}
