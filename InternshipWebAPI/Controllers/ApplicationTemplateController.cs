using InternshipWebAPI.Domain.DTOs;
using InternshipWebAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternshipWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationTemplateController : ControllerBase
    {
        private readonly IApplicationTemplateService _applicationService;
        public ApplicationTemplateController(IApplicationTemplateService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet(Name = "Get Program")]
        public async Task<IActionResult> GetApplication(string id)
        {
            var application = await _applicationService.GetApplication(id);
            return Ok(application);
        }

        [HttpPost(Name = "Create Application")]
        public async Task<IActionResult> CreateApplication([FromBody] CreateApplicationTemplateDTO model)
        {
            var created = await _applicationService.CreateApplicationTemplate(model);
            return Ok(created);
        }
    }
}
