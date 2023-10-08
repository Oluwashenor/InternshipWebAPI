using InternshipWebAPI.Domain.DTOs;
using InternshipWebAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternshipWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkflowController : ControllerBase
    {
        private readonly IWorkflowService _workflowService;
        public WorkflowController(IWorkflowService workflowService)
        {
            _workflowService = workflowService;
        }

        [HttpGet("{programId}")]
        public async Task<IActionResult> GetWorkflow(string programId)
        {
            var application = await _workflowService.GetWorkflow(programId);
            return Ok(application);
        }

        [HttpPost(Name = "Create Workflow")]
        public async Task<IActionResult> CreateWorkFlow([FromBody] CreateWorkFlowDTO model)
        {
            var created = await _workflowService.CreateWorkflow(model);
            return Ok(created);
        }

        [HttpPut("{programId}")]
        public async Task<IActionResult> UpdateWorkFlow(string programId, [FromBody] CreateWorkFlowDTO model)
        {
            var created = await _workflowService.UpdateWorkflow(programId, model);
            return Ok(created);
        }
    }
}
