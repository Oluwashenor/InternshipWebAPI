using InternshipWebAPI.Domain.DTOs;

namespace InternshipWebAPI.Repository.Interfaces
{
    public interface IWorkflowService
    {
        Task<APIResponse<bool>> CreateWorkflow(CreateWorkFlowDTO model);
        Task<APIResponse<WorkflowDTO>> GetWorkflow(string id);
        Task<APIResponse<bool>> UpdateWorkflow(string programId, CreateWorkFlowDTO model);
    }
}