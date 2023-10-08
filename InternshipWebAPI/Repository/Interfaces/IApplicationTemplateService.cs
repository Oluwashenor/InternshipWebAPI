using InternshipWebAPI.Domain.DTOs;

namespace InternshipWebAPI.Repository.Interfaces
{
    public interface IApplicationTemplateService
    {
        Task<APIResponse<bool>> CreateApplicationTemplate(CreateApplicationTemplateDTO model);
        Task<APIResponse<ApplicationTemplateDTO>> GetApplication(string id);
        Task<APIResponse<bool>> UpdateApplicationTemplate(string programId, CreateApplicationTemplateDTO model);
    }
}