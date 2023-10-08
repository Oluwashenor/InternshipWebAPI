using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace InternshipWebAPI.Domain.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            Id = Guid.NewGuid().ToString();
            IsActive = true;
            IsDeleted = false;
            Created = DateTime.Now;
            Modified = DateTime.Now;
        }
        [Key]
        [JsonProperty("id")]
        public string Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
