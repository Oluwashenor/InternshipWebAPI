using InternshipWebAPI.Utilities;
using System.ComponentModel.DataAnnotations;

namespace InternshipWebAPI.Domain.DTOs
{
    public class QuestionDTO
    {
    }

    public class CreateQuestionBlockDTO
    {
        [Required]
        public string? Question { get; set; }
        public bool IsRequired { get; set; }
        [Required]
        public QuestionType QuestionType { get; set; }
        public List<string>? AdditionalField { get; set; }
    }
}
