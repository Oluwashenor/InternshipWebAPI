using InternshipWebAPI.Data;
using InternshipWebAPI.Domain.DTOs;
using InternshipWebAPI.Domain.Models;
using InternshipWebAPI.Repository.Interfaces;
using InternshipWebAPI.Utilities;
using Microsoft.EntityFrameworkCore;

namespace InternshipWebAPI.Repository.Services
{
    public class ProgramTemplateService : IProgramTemplateService
    {
        private readonly AppDbContext _context;
        private readonly IResponseService _responseService;

        public ProgramTemplateService(AppDbContext context,IResponseService responseService)
        {
            _context = context;
            _responseService = responseService;
            //_container = cosmosClient.GetContainer("InternshipDB", "AppDbContext");
        }

        public async Task<APIResponse<ProgramDTO>> GetProgramDetail(string id)
        {
            var program = await _context.ProgramTemplates.FirstOrDefaultAsync(x => x.Id == id);
            if (program == null)
                return _responseService.ErrorResponse<ProgramDTO>("Program not found");
            var workflow = await _context.Workflows.FirstOrDefaultAsync(x => x.ProgramTemplateId == id);
            ApplicationFormTemplate formTemplates = await _context.ApplicationFormTemplates.FirstOrDefaultAsync(x => x.ProgramTemplateId == id);
            var response = program.MapProgramToDTO(workflow, formTemplates);
            return _responseService.SuccessResponse(response);
        }

        public async Task<APIResponse<ProgramDTO>> CreateProgram(CreateProgramDTO model)
        {
            var program = model.MapToModel();
            await _context.AddAsync(program);
            await _context.SaveChangesAsync();
            return _responseService.SuccessResponse(program.MapProgramToDTO(null,null));
        }

        public async Task<APIResponse<ProgramDTO>> PutProgram(string programId,CreateProgramDTO model)
        {
            if (programId == default)
                return _responseService.ErrorResponse<ProgramDTO>("Program ID is required");
            var program = await _context.ProgramTemplates.FirstOrDefaultAsync(x=>x.Id == programId);
            if (program == default)
                return _responseService.ErrorResponse<ProgramDTO>("Program not found");
            ApplicationFormTemplate formTemplate = await _context.ApplicationFormTemplates.FirstOrDefaultAsync(x => x.ProgramTemplateId == program.Id);
            Workflow workFlow = await _context.Workflows.FirstOrDefaultAsync(x => x.ProgramTemplateId == program.Id);
            var updateModel = model.MapToModel();
            if (updateModel.ApplicationTemplate != null)
            {
                updateModel.ApplicationTemplate.ProgramTemplateId = program.Id;
                if (formTemplate != null)
                    _context.ApplicationFormTemplates.Remove(formTemplate);
                program.ApplicationTemplate = updateModel.ApplicationTemplate;

            } 
            if(updateModel.Workflow != null)
            {
                updateModel.Workflow.ProgramTemplateId = program.Id;
                if (workFlow != null)
                    _context.Workflows.Remove(workFlow);
                program.Workflow = updateModel.Workflow;   
            }
            _context.Update(program);
            await _context.SaveChangesAsync();
            return _responseService.SuccessResponse(program.MapProgramToDTO(program.Workflow, program.ApplicationTemplate));
        }
    }
}
