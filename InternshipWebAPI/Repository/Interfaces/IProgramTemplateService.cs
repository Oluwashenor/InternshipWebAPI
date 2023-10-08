using InternshipWebAPI.Domain.DTOs;

namespace InternshipWebAPI.Repository.Interfaces
{
    public interface IProgramTemplateService
    {
        Task<APIResponse<ProgramDTO>> CreateProgram(CreateProgramDTO model);
        Task<APIResponse<ProgramDTO>> GetProgram(string id);
        Task<APIResponse<ProgramDTO>> GetProgramDetail(string id);
        Task<APIResponse<ProgramDTO>> PutProgram(string programId, CreateProgramDTO model);
    }
}