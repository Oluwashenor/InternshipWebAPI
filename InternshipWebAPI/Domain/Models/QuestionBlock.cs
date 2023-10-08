using InternshipWebAPI.Utilities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace InternshipWebAPI.Domain.Models
{
    public class QuestionBlock
    {
        [Required]
        public string? Question { get; set; }
        [Required]
        public bool IsRequired { get; set; }
        [Required]
        public QuestionType? QuestionType { get; set; }
        public List<string>? AdditionalField { get; set; }
    }
}
