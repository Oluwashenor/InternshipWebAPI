namespace InternshipWebAPI.Domain.DTOs
{
    public class APIResponse<T>
    {
        public T Data { get; set; }
        public bool Status { get; set; }
        public string? Message { get; set; }
    }
}
