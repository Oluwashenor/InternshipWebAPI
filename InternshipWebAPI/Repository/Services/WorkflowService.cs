using InternshipWebAPI.Data;
using InternshipWebAPI.Domain.DTOs;
using InternshipWebAPI.Domain.Models;
using InternshipWebAPI.Repository.Interfaces;
using InternshipWebAPI.Utilities;
using Microsoft.EntityFrameworkCore;

namespace InternshipWebAPI.Repository.Services
{
    public class WorkflowService : IWorkflowService
    {
        private readonly AppDbContext _context;
        private readonly IResponseService _responseService;

        public WorkflowService(AppDbContext context, IResponseService responseService)
        {
            _context = context;
            _responseService = responseService;
        }

        public async Task<APIResponse<WorkflowDTO>> GetWorkflow(string programId)
        {
            var workflow = await _context.Workflows.FirstOrDefaultAsync(x => x.ProgramTemplateId == programId);
            if (workflow == null)
                return _responseService.ErrorResponse<WorkflowDTO>("Workflow not found");
            var response = new WorkflowDTO()
            {
                ProgramTemplateId = workflow.ProgramTemplateId,
                Workflows = workflow.Workflows
            };
            return _responseService.SuccessResponse(response);
        }

        public async Task<APIResponse<bool>> CreateWorkflow(CreateWorkFlowDTO model)
        {
            if (model == null)
                return _responseService.ErrorResponse<bool>("model cannot be empty");
            var workflow = new Workflow()
            {
                ProgramTemplateId = model.ProgramTemplateId,
                Workflows = model.Workflows,
            };
            await _context.Workflows.AddAsync(workflow);
            var saved = await _context.SaveChangesAsync();
            if (saved > 0)
                return _responseService.SuccessResponse(true);
            return _responseService.ErrorResponse<bool>("Something went wrong while saving your data");
        }

        public async Task<APIResponse<bool>> UpdateWorkflow(string programId, CreateWorkFlowDTO model)
        {
            if (model == null)
                return _responseService.ErrorResponse<bool>("model cannot be empty");
            var workflow = await _context.Workflows.FirstOrDefaultAsync(x => x.ProgramTemplateId == programId);
            if (workflow == null)
                return _responseService.ErrorResponse<bool>("Workflow not found");
            var workflowNew = new Workflow()
            {
                ProgramTemplateId = programId,
                Workflows = model.Workflows,
            };
            _context.Remove(workflow);
            await _context.Workflows.AddAsync(workflowNew);
            var saved = await _context.SaveChangesAsync();
            if (saved > 0)
                return _responseService.SuccessResponse(true);
            return _responseService.ErrorResponse<bool>("Something went wrong while saving your data");
        }
    }
}
