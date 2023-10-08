namespace InternshipWebAPI.Domain.Models
{
    public class ProfileField
    {
        public bool IsRequired { get; set; }
        public List<QuestionBlock>? Questions { get; set; }
    }
}
